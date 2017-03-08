using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevStormMvc.Identity_Management
{
    public class AccountServices 
    {
        // User Credential Attribute
        private UserCredential _userCredential;

        // Principal context instance
        private PrincipalContext _adContext;

        // Principal context instance for OU specific utilization
        //private PrincipalContext _adOuContext;

        public PrincipalContext adContext
        {
            get {
                return _adContext;
            }
        }

        /// <summary>
        /// This constructor of this class used only to instanciate the principal context 
        /// </summary>
        public AccountServices()
        {
            _adContext = AMAuthentication.getContext();
            //_adOuContext = AMAuthentication.getOuContext("ZARA");
        }

        /// <summary>
        /// The constructor of this class instanciate the principal context and the user credential
        /// </summary>
        /// <param name="userName">The username of the user here</param>
        /// <param name="password">He's password</param>
        public AccountServices(string userName, string password)
        {
            _adContext = AMAuthentication.getContext();
            //_adOuContext = AMAuthentication.getOuContext("ZARA");
            _userCredential = new UserCredential(userName, password,_adContext);
        }
        public AccountServices(string userName)
        {
            _adContext = AMAuthentication.getContext();
            //_adOuContext = AMAuthentication.getOuContext("ZARA");
            _userCredential = new UserCredential(userName, _adContext);

        }
        public bool ValidateCredentials()
        {
            return _adContext.ValidateCredentials(_userCredential._userName, _userCredential._password);
        }


        /// <summary>
        /// This method it only edit the user default attribute 
        /// </summary>
        /// <param name="firstname">The username here</param>
        /// <param name="lastname">He's password</param>
        /// <param name="email">He's email address</param>
        public void UpdateAdUser(string firstname, string lastname, string email)
        {
            UserPrincipal user = _userCredential.GetUser(_userCredential._userName);
            user.GivenName = firstname;
            user.Surname = lastname;
            user.EmailAddress = email;
            user.Save();
        }

        /// <summary>
        ///  This Method set the password of the user and check if the password is compatible with
        ///  active directory credential security level and it return an error message as an output
        ///  of the method to explain what it doesn't matter.
        /// </summary>
        public void SetUserPassword(string newPassword, out string message)
        {
            try
            {
                _userCredential.GetUser(_userCredential._userName).SetPassword(newPassword);
                message = "";
            }
            catch (Exception ex)
            {
                message = ex.ToString();
            }
        }

        public UserPrincipal ShowUser()
        {
            return _userCredential.GetUser(_userCredential._userName);

        }

        /// <summary>
        /// Gets a certain group on Active Directory
        /// </summary>
        /// <param name="sGroupName">The group to get</param>
        /// <returns>Returns the GroupPrincipal Object</returns>
        public GroupPrincipal GetGroup(string sGroupName)
        {
            GroupPrincipal oGroupPrincipal =
               GroupPrincipal.FindByIdentity(_adContext, sGroupName);
            return oGroupPrincipal;
        }

        /// <summary>
        /// Checks if user is a member of a given group
        /// </summary>
        /// <param name="sUserName">The user you want to validate</param>
        /// <param name="sGroupName">The group you want to check the 
        /// membership of the user</param>
        /// <returns>Returns true if user is a group member</returns>
        public bool IsUserGroupMember(string sUserName, string sGroupName)
        {
            UserPrincipal oUserPrincipal = _userCredential.GetUser(sUserName);
            GroupPrincipal oGroupPrincipal = GetGroup(sGroupName);

            if (oUserPrincipal == null || oGroupPrincipal == null)
            {
                return oGroupPrincipal.Members.Contains(oUserPrincipal);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Adds the user for a given group
        /// </summary>
        /// <param name="sUserName">The user you want to add to a group</param>
        /// <param name="sGroupName">The group you want the user to be added in</param>
        /// <returns>Returns true if successful</returns>
        public bool AddUserToGroup(string sUserName, string sGroupName)
        {
            try
            {
                UserPrincipal oUserPrincipal = _userCredential.GetUser(sUserName);
                GroupPrincipal oGroupPrincipal = GetGroup(sGroupName);
                if (oUserPrincipal == null || oGroupPrincipal == null)
                {
                    if (!IsUserGroupMember(sUserName, sGroupName))
                    {
                        oGroupPrincipal.Members.Add(oUserPrincipal);
                        oGroupPrincipal.Save();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Checks if user exists on AD
        /// </summary>
        /// <param name="sUserName">The username to check</param>
        /// <returns>Returns true if username Exists</returns>
        public bool IsUserExisiting(string sUserName)
        {
            if (_userCredential. GetUser(sUserName) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        public UserPrincipal CreateNewUser(string sUserName, string sPassword, string sGivenName, string sSurname,string email,string phone)
        {
            if (!IsUserExisiting(sUserName))
            {
                
                PrincipalContext ctx = new PrincipalContext(ContextType.Domain,
                    "wad.devstorm.tn",
                    "OU=ZARA,"+AMAuthentication.adRoot,
                    AMAuthentication.adUserName,
                    AMAuthentication.adUserPassword); 
                

                UserPrincipal oUserPrincipal = new UserPrincipal
                   (ctx, sUserName, AMAuthentication.adUserPassword, true);

                //User Log on Name
                oUserPrincipal.UserPrincipalName = sUserName;
                oUserPrincipal.GivenName = sGivenName;
                oUserPrincipal.Surname = sSurname;
                oUserPrincipal.EmailAddress = email;
                oUserPrincipal.VoiceTelephoneNumber = phone;
                oUserPrincipal.Save();

                return oUserPrincipal;
            }
            else
            {
                return _userCredential.GetUser(sUserName);
            }

        }

        public List<Principal> GetAllOuUsers()
        {
            List<Principal> Users = new List<Principal>() ;
            
            UserPrincipal qbeUser = new UserPrincipal(_adContext);
           // qbeUser.Enabled = true;

            PrincipalSearcher srch = new PrincipalSearcher(qbeUser);
           
            // find all matches
            foreach (var found in srch.FindAll())
            {
                Users.Add(found);
            }
            return Users;
        }

        /// <summary>
        /// Enables a disabled user account
        /// </summary>
        /// <param name="sUserName">The username to enable</param>
        public void EnableUserAccount(string sUserName)
        {
            UserPrincipal oUserPrincipal = _userCredential.GetUser(sUserName);
            oUserPrincipal.Enabled = true;
            oUserPrincipal.Save();
        }


    }
}
