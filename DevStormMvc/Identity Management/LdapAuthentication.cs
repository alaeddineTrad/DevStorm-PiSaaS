using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Web;

namespace DevStormMvc.Identity_Management
{
    public class LdapAuthentication
    {
        private String _path;
        private String _filterAttribute;
        private String _domainAndUsername;
        private String _pwd;
        private String _username;
        private String _domain;
        //private Label _errLabel;

        public object another { get; private set; }

        public LdapAuthentication(String path, String domain, String username, String pwd)
        {
            _path = path;
            _domainAndUsername = domain + @"\" + username;
            _pwd = pwd;
            _username = username;
            _domain = domain;
        }

        public bool IsAuthenticated()
        {
            DirectoryEntry entry = new DirectoryEntry(_path, _domainAndUsername, _pwd);

            try
            {//Bind to the native AdsObject to force authentication.
                Object obj = entry.NativeObject;

                DirectorySearcher search = new DirectorySearcher(entry);

                search.Filter = "(SAMAccountName=" + _username + ")";
                search.PropertiesToLoad.Add("cn");


                SearchResult result = search.FindOne();

                if (null == result)
                {
                    return false;
                }

                //Update the new path to the user in the directory.
                _filterAttribute = (String)result.Properties["cn"][0];

            }
            catch (Exception ex)
            {
                throw new Exception("Error authenticating user. " + ex.Message);
            }

            return true;
        }

        public String GetGroups()
        {
            String domainAndUsername = _domain + @"\" + _username;
            DirectoryEntry entry = new DirectoryEntry(_path, domainAndUsername, _pwd);
            DirectorySearcher search = new DirectorySearcher(entry);

            search.Filter = "(cn=" + _filterAttribute + ")";
            search.PropertiesToLoad.Add("memberOf");
            StringBuilder groupNames = new StringBuilder();


            try
            {
                SearchResult result = search.FindOne();
                int propertyCount = result.Properties["memberOf"].Count;
                //_errLabel.Text = _errLabel.Text + "Count : " + propertyCount ;
                String dn;
                int equalsIndex, commaIndex;

                for (int propertyCounter = 0; propertyCounter < propertyCount; propertyCounter++)
                {
                    dn = (String)result.Properties["memberOf"][propertyCounter];

                    equalsIndex = dn.IndexOf("=", 1);
                    commaIndex = dn.IndexOf(",", 1);
                    if (-1 == equalsIndex)
                    {
                        return null;
                    }

                    groupNames.Append(dn.Substring((equalsIndex + 1), (commaIndex - equalsIndex) - 1));
                    groupNames.Append("|");

                }
                //errorLabel.Text = errorLabel.Text + groupNames + "  -|-  ";
            }
            catch (Exception ex)
            {
                throw new Exception("Error obtaining group names. " + ex.Message);
            }
            return groupNames.ToString();
        }
    }
}