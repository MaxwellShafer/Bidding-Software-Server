﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Server
{
    public class ServerController
    {
        /// <summary>
        /// current state of the server controller
        /// </summary>
        public ServerState State { get; set; }

        /// <summary>
        /// delegate that we call to return the updated product and if they are winning and such
        /// </summary>
        public BidUpdateDEL BidUpdateDEL { get; set; }

        /// <summary>
        /// A delegate to hold the method that handles when we return login result
        /// </summary>
        public LoginReturnDEL LoginReturnDEL { get; set; }

        /// <summary>
        /// A delegate to send changes in the database so i can be reflected in the 
        /// </summary>
        public UpdateStateDEL UpdateStateDEL { get; set; }

        /// <summary>
        /// private field to hold the product database
        /// </summary>
        private ProductDB _productDB = new ProductDB();

        /// <summary>
        /// dictates what file the user information should be read/writen to
        /// </summary>
        private string _userFilepath = "UserLoginInfo";

        /// <summary>
        /// a dictionary to load and check user logins
        /// </summary>
        private Dictionary<string, string> _userLoginInfo;

        /// <summary>
        /// constuctor for server controller
        /// </summary>
        public ServerController()
        {
            _userLoginInfo = BuildDictonary(_userFilepath);
        }

        /// <summary>
        /// A method to check if the given username is valid, depending if its an admin login or not
        /// </summary>
        /// <param name="username">the username</param>
        /// <param name="password">password</param>
        /// <param name="IsAdmin">True if the attempt is an admin</param>
        public void NewLoginAttempt(string username, string password)
        {

            //if it does not contain create new and return sucsessfull
            if (!(_userLoginInfo.ContainsKey(username)))
            {
                _userLoginInfo.Add(username, password); // add to dict
                WriteToJson(_userLoginInfo, "UserLoginInfo"); //overwrite with new dict
                LoginReturnDEL(true);
            }
            else
            {
                if (_userLoginInfo[username] == password)
                {
                    LoginReturnDEL(true);
                }
                else
                {
                    LoginReturnDEL(false);
                }

            }



        }

        /// <summary>
        /// reads the dictionary saved at given filepath and returns the built Dictionary
        /// </summary>
        /// <param name="filepath">whhat file to read from</param>
        /// <returns></returns>
        private Dictionary<string, string> BuildDictonary(string filepath)
        {
            string json = File.ReadAllText(filepath);
            Dictionary<string, string> dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            return dict;
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
        /// The method Invoked in the com controller, handles a new bid coming in
        /// </summary>
        /// <param name="bid">the bid amount</param>
        /// <param name="productID">The productID</param>
        /// <param name="clientID"> the clients username</param>
        public void HandleNewBid(decimal bid, string productID, string clientID)
        {
            foreach(Product p in _productDB.Products)
            {
                if(p.Id == productID)
                {
                    if(p.MinBid < bid)
                    {
                        p.MinBid = bid;
                        BidUpdateDEL(bid, productID, clientID); // comunicating back to the clients
                        UpdateStateDEL(AdminState.EXPIRE, _productDB);
                    }
                    else
                    {
                        //supposedly do nothing and the other bid that causes this one to fail should update the view to alert them that they are not winning
                    }
                }
            }
        }
    }
}
