using Domain.Entities;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Web;

namespace DevStormMvc.Identity_Management
{
    public class ADCrud
    {

        public string AddUser(string username, string firstname, string lastname,string pwd)
        {
            DirectoryEntry objADAM; // Binding object.
            DirectoryEntry objUser; // User object.

            string strDisplayName = firstname + " " + lastname;
            string strUser = username;
            string strUserPrincipalName = strUser + "@devstorm.tn";
            string pw = pwd;
            string strGroup = "CN=Users,OU=ZARA";
            string samacct;


            const long ADS_OPTION_PASSWORD_PORTNUMBER = 6;
            const long ADS_OPTION_PASSWORD_METHOD = 7;
            const int ADS_PASSWORD_ENCODE_REQUIRE_SSL = 0;
            const int ADS_PASSWORD_ENCODE_CLEAR = 1;

            string strServer = "34.249.163.90"; //IP to your ad server
            string strUserOu = "OU=ZARA,DC=devstorm,DC=tn";
            string strPort = "389";
            int intPort = Int32.Parse(strPort);

            AuthenticationTypes AuthTypes = AuthenticationTypes.Signing | AuthenticationTypes.Sealing | AuthenticationTypes.Secure;

            try
            {
                objADAM = new DirectoryEntry("LDAP://" + strServer + ":" + strPort + "/" + strUserOu, "Administrator", "Ci%c9vG!$q", AuthTypes);
                objADAM.RefreshCache();
            }
            catch (Exception e)
            {
                return e.Message + "3asba";
            }

            try
            {
                //Make sure same account is 20 chars or less
                if (strUser.Length > 19)
                {
                    samacct = strUser.Substring(0, 19);
                }
                else
                {
                    samacct = strUser;
                }

                //Create new user
                objUser = objADAM.Children.Add("CN=" + strUser/* + ",ou=ZARA"*/, "user");
                objUser.Properties["displayName"].Add(strDisplayName);
                objUser.Properties["userPrincipalName"].Add(strUserPrincipalName);
                objUser.Properties["mail"].Add(strUserPrincipalName);
                objUser.Properties["sAMAccountName"].Add(samacct);
                objUser.Properties["givenName"].Add(firstname);
                objUser.Properties["sn"].Add(lastname);
                objUser.CommitChanges();
                objUser.RefreshCache();

                //Set default password
                objUser.Invoke("SetOption", new object[] { ADS_OPTION_PASSWORD_PORTNUMBER, intPort });
                objUser.Invoke("SetOption", new object[] { ADS_OPTION_PASSWORD_METHOD, ADS_PASSWORD_ENCODE_CLEAR });
                objUser.Invoke("SetPassword", new object[] { pw });
                objUser.CommitChanges();
                objUser.RefreshCache();

                //Enable account and change password on first logon flag
                //objUser.Properties["userAccountControl"].Value = 0x200;
                //objUser.Properties["pwdLastSet"].Value = 0;
                //objUser.CommitChanges();
                //objUser.RefreshCache();

            }
            catch (Exception e)
            {
                return e.Message + "sormek";
            }

            //Add user to students group
            try
            {
                DirectoryEntry dom = new DirectoryEntry("LDAP://" + strUserOu, null, null, AuthTypes);
                DirectoryEntry group = dom.Children.Find(strGroup);
                group.Properties["member"].Add("CN=" + strUser + ",OU=ZARA,DC=devstorm,DC=tn");
                group.CommitChanges();
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return "done";
        }

        public string GetOrganisationUnit(string userName)
        {
            String domainAndUsername = "DEVSTORM" + @"\" + userName;
            PrincipalContext domainContext = new PrincipalContext(ContextType.Domain, "192.168.126.189:389", "dc=devstorm,dc=tn", domainAndUsername, "KingHolding2007.");

            UserPrincipal user = UserPrincipal.FindByIdentity(domainContext, userName);

            /* Retreive the container
             */
            DirectoryEntry deUser = user.GetUnderlyingObject() as DirectoryEntry;
            DirectoryEntry deUserContainer = deUser.Parent;
            string aa = deUserContainer.Properties["distinguishedName"].Value.ToString();
            string[] one = aa.Split(',');
            foreach (var it in one)
            {
                if (it.Contains("OU"))
                {
                    return it.Replace("OU=", " ");
                }
            }
            return aa;


        }
    }
}