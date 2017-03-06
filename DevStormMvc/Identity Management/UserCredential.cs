using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevStormMvc.Identity_Management
{
    public class UserCredential
    {
        private PrincipalContext _adContext;
        public string _userName { get; set; }
        public string _password { get; set; }

        public UserCredential(string userName, string password, PrincipalContext adContext)
        {
            _userName = userName;
            _password = password;
            _adContext = adContext;
        }

        public UserCredential(string userName, PrincipalContext adContext)
        {
            _userName = userName;
            _adContext = adContext;
        }

        public UserPrincipal GetUser(string userName)
        {
            UserPrincipal user = UserPrincipal.FindByIdentity(_adContext, userName);
            return user;
        }
        
    }
}
