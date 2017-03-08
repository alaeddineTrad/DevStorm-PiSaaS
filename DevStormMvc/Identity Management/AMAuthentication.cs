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
        // Private attribute to make this class singleton and obtain only OuContext
        //private static AMAuthentication _amAuthenticationOu;

        // Private attribute to return a one context if initiated
        private static PrincipalContext _adContext;

        // The public attribute which contain the private value of contexts
        public static PrincipalContext adContext;

        // Attribute used by the context
        // Marouane Attributes
        //private static string _adServerName = "192.168.126.189:389";
        //private static string _adRoot = "dc=devstorm,dc=tn";
        //private static string _adUserName = "Administrateur";
        //private static string _adUserPassword = "KingHolding2007.";

        // AWS Attributes
        private static string _adServerName = "34.249.163.90:389";
        private static string _adRoot = "dc=devstorm,dc=tn";
        private static string _adUserName = "Administrator";
        private static string _adUserPassword = "Ci%c9vG!$q";



        // Sedki Attributes
        //private string _adServerName = "windowsserverad.devstorm.tn:389";
        //private string _adRoot = "dc=devstorm,dc=tn";
        //private string _adUserName = "Administrator";
        //private string _adUserPassword = "Devstorm/2016";

        // This the public static attributes of the principal context
        public static string adServerName { get { return _adServerName; } }
        public static string adRoot { get { return _adRoot; } }
        public static string adUserName { get { return _adUserName; } }
        public static string adUserPassword { get { return _adUserPassword; } }

        private AMAuthentication()
        {
            _adContext = new PrincipalContext(ContextType.Domain,
                _adServerName,
                _adRoot,
                _adUserName,
                _adUserPassword);
        }

        //private AMAuthentication(string adUserOU)
        //{
        //    _adUserOU = adUserOU;
        //    _adContext = new PrincipalContext(ContextType.Domain,
        //       _adServerName,
        //       "OU=" + _adUserOU + "," + _adRoot,
        //       _adUserName,
        //       _adUserPassword);
        //}

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

        //public static PrincipalContext getOuContext(string ou)
        //{
        //    if (_amAuthenticationOu == null)
        //    {
        //        _amAuthenticationOu = new AMAuthentication(ou);
        //        adContext = _adContext;
        //        return adContext;
        //    }
        //    return adContext;
        //}

    }
}
