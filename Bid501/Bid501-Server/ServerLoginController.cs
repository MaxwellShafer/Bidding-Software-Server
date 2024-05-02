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
    public class ServerLoginController
    {        

        /// <summary>
        /// A delegate that is called in the controller to invoke the method to update the state in the view
        /// </summary>
        public FetchStateDEL FetchStateDEL { get; set; }

        
        /// <summary>
        /// dictates what file the admin login info is read from
        /// </summary>
        private string _adminFilepath = "../../adminLoginInfo.txt";

        /// <summary>
        /// a dictionary to load in and check admin logins
        /// </summary>
        private Dictionary<string, string> _adminLoginInfo;

        /// <summary>
        /// delegate to be called to show a sucsessfull login
        /// </summary>
        public LoginSuccessDEL LoginSuccessDEL { get; set; }

        /// <summary>
        /// constructor for login controller
        /// </summary>
        public ServerLoginController()
        {
            
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
            
          
           if (_adminLoginInfo.TryGetValue(username, out var pw))
           {
                if(pw == password)
                {
                    LoginSuccessDEL();
                }
                else
                {
                    MessageBox.Show("Wrong password idiot");
                }
                
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
            
            string json = File.ReadAllText(filepath);
            Dictionary<string, string> dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            return dict;
        }
        

        /// <summary>
        /// sets delegates for cuurrent instance
        /// </summary>
        /// <param name="LoginSuccess">delegate to be set</param>
        /// <param name="fetchState">delegate to be set</param>
        public void SetDEL(LoginSuccessDEL LoginSuccess, FetchStateDEL fetchState)
        {
            LoginSuccessDEL = LoginSuccess;
            FetchStateDEL = fetchState;
        }

        

    }
}
