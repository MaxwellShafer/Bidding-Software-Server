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
        public FetchStateDEL FetchStateDEL { get; set; }

        
        /// <summary>
        /// dictates what file the admin login info is read from
        /// </summary>
        private string _adminFilepath = "AdminLoginInfo";

        /// <summary>
        /// a dictionary to load in and check admin logins
        /// </summary>
        private Dictionary<string, string> _adminLoginInfo;

        /// <summary>
        /// delegate to be called to show a sucsessfull login
        /// </summary>
        public LoginSuccessDEL LoginSuccessDEL { get; set; }

        public ServerLoginController()
        {
            //load dictionaries from given filepaths
            _adminLoginInfo = BuildDictonary(_adminFilepath);
            
        }

        /// <summary>
        /// A method to check if the given username is valid, depending if its an admin login or not
        /// </summary>
        /// <param name="username">the username</param>
        /// <param name="password">password</param>
        /// <param name="IsAdmin">True if the attempt is an admin</param>
        public void NewLoginAttempt(string username, string password)
        {
          
           if (_adminLoginInfo[username] == password)
           {
                LoginSuccessDEL();
           }
           else
           {
               //invoke unsucessfull
               FetchStateDEL(LoginState.DECLINED);
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
            Dictionary<string, string> TempDictionary = new Dictionary<string, string>();
            TempDictionary.Add("admin", "password");
            File.WriteAllText(filepath, JsonConvert.SerializeObject(TempDictionary));
            string json = File.ReadAllText(filepath);
            Dictionary<string, string> dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            return dict;
        }
        

        public void SetDEL(LoginSuccessDEL LoginSuccess, FetchStateDEL fetchState)
        {
            LoginSuccessDEL = LoginSuccess;
            FetchStateDEL = fetchState;
        }

        

    }
}
