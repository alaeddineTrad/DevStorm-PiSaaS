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

        public PrincipalContext adContext
        {
            get {
                return _adContext;
            }
        }

        /// <summary>
        /// The constructor of this class instanciate the principal context and the user credential
        /// </summary>
        /// <param name="userName">The username of the user here</param>
        /// <param name="password">He's password</param>
        public AccountServices(string userName, string password)
        {
            _adContext = AMAuthentication.getContext();
            _userCredential = new UserCredential(userName, password,_adContext);
        }

        public AccountServices(string username)
        {
            _adContext = AMAuthentication.getContext();
            _userCredential = new UserCredential(username,_adContext);
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

    }
}
