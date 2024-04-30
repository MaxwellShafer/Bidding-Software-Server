using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;


namespace Bid501_Server
{
    /// <summary>
    /// The controller that handles the LogIn
    /// </summary>
    internal class ServerLoginController
    {
        /// <summary>
        /// a private field to hold a logInAttempt
        /// </summary>
        private LoginAttempt LoginAttempt;

        /// <summary>
        /// A delegate that is called in the controller to invoke the method to update the state in the view
        /// </summary>
        public FetchStateDEL fetchStateDEL { get; set; }

        /// <summary>
        /// dictates what file the user information should be read/writen to
        /// </summary>
        private string _userFilepath = "UserLoginInfo";

        /// <summary>
        /// dictates what file the admin login info is read from
        /// </summary>
        private string _adminFilepath = "AdminLoginInfo";

        /// <summary>
        /// a dictionary to load in and check admin logins
        /// </summary>
        private Dictionary<string, string> _adminLoginInfo;

        /// <summary>
        /// a dictionary to load and check user logins
        /// </summary>
        private Dictionary<string, string> _userLoginInfo;

        public ServerLoginController()
        {
            //load dictionaries from given filepaths
            _adminLoginInfo = BuildDictonary(_adminFilepath);
            _userLoginInfo = BuildDictonary(_userFilepath);
        }

        /// <summary>
        /// A method to check if the given username is valid, depending if its an admin login or not
        /// </summary>
        /// <param name="username">the username</param>
        /// <param name="password">password</param>
        /// <param name="IsAdmin">True if the attempt is an admin</param>
        public void NewLoginAttempt(string username, string password, bool IsAdmin)
        {
            if (IsAdmin)
            {
                if (_adminLoginInfo[username] == password)
                {
                    //invoke sucsessfull login send state back
                    fetchStateDEL(LoginState.SUCCESS);
                }
                else
                {
                    //invoke unsucessfull
                    fetchStateDEL(LoginState.DECLINED);
                }
            }
            else // if its not an admin login
            {
                //if it does not contain create new and return sucsessfull
                if ( !(_userLoginInfo.ContainsKey(username)) )
                {
                    _userLoginInfo.Add(username, password); // add to dict
                    WriteToJson(_userLoginInfo, "UserLoginInfo"); //overwrite with new dict
                    fetchStateDEL(LoginState.SUCCESS);
                }

                if (_userLoginInfo[username] == password)
                {
                    fetchStateDEL(LoginState.SUCCESS);
                }
                else
                {
                    fetchStateDEL(LoginState.DECLINED);
                }
            }
            
        }

        /// <summary>
        /// Serializes and Writes the given dictionary to a filepath given
        /// </summary>
        /// <param name="dict">the dictionary</param>
        /// <param name="filePath">the filepath</param>
        private void WriteToJson(Dictionary<string, string> dict, string filePath)
        {
            string obj = JsonConvert.SerializeObject(dict);
            File.WriteAllText(filePath, obj);
        }

        /// <summary>
        /// reads the dictionary saved at given filepath and returns the built Dictionary
        /// </summary>
        /// <param name="filepath">whhat file to read from</param>
        /// <returns></returns>
        private Dictionary<string,string> BuildDictonary(string filepath)
        {
            string json = File.ReadAllText(filepath);
            Dictionary<string, string> dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            return dict;
        }
        

    }
}
