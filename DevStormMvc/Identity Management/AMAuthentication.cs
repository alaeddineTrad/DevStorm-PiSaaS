using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices.AccountManagement;

namespace DevStormMvc.Identity_Management
    {
    public class AMAuthentication
    {
        //private PrincipalContext _adContext;

        // Private attribute to make this class singleton
        private static AMAuthentication _amAuthentication;

        // Private attribute to return a one context if initiated
        private static PrincipalContext _adContext;

        // The public attribute which contain the private value of contexts
        public static PrincipalContext adContext;

        // Attribute used by the context
        // Marouane Attributes
        //private string _adServerName = "192.168.126.189:389";
        //private string _adRoot = "dc=devstorm,dc=tn";
        //private string _adUserName = "Administrateur";
        //private string _adUserPassword = "KingHolding2007.";


        // Sedki Attributes
        private string _adServerName = "windowsserverad.devstorm.tn:389";
        private string _adRoot = "dc=devstorm,dc=tn";
        private string _adUserName = "Administrator";
        private string _adUserPassword = "Devstorm/2016";
        private string _adUserOU = "";

        private AMAuthentication()
        {
            _adContext = new PrincipalContext(ContextType.Domain,
                _adServerName,
                _adRoot,
                _adUserName,
                _adUserPassword);
        }


        public static PrincipalContext getContext()
        {
            if (_amAuthentication == null)
            {
                _amAuthentication = new AMAuthentication();
                adContext = _adContext;
                return adContext;
            }
            return adContext;
        }

    }
}
