using Bid501_Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp.Server;

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
        /// a delegate to call so we can get clients
        /// </summary>
        public GetClientDEL GetClientDEL { get; set; }

        /// <summary>
        /// A delegate to send changes in the database so i can be reflected in t
        /// </summary>
        public UpdateStateDEL UpdateStateDEL { get; set; }

        /// <summary>
        /// private field to hold the product database
        /// </summary>
        private ProductDB _productDB;


        /// <summary>
        /// dictates what file the user information should be read/writen to
        /// </summary>
        private string _userFilepath = "../../userLoginInfo.txt";

        /// <summary>
        /// a dictionary to load and check user logins
        /// </summary>
        private Dictionary<string, string> _userLoginInfo;

        /// <summary>
        /// a private field to hold the server com controller
        /// </summary>
        public ServerCommCtrl ServerCommCtrl;

        /// <summary>
        /// a dictionary to hold the id and usernaim kvp
        /// </summary>
        private Dictionary<string, string> _userIdPair = new Dictionary<string, string>();

        /// <summary>
        /// constuctor for server controller
        /// </summary>
        public ServerController(ProductDB productDB)
        {
            _productDB = productDB;
            ServerCommCtrl = new ServerCommCtrl(this.NewLoginAttempt,this.HandleNewBid, this.GetClientID);
            WebSocketServer socket = new WebSocketServer(8002);
            socket.AddWebSocketService<ServerCommCtrl>("/server", () => ServerCommCtrl);
            socket.Start();
            ServerLoginController serverLoginController = new ServerLoginController();
            ServerLoginView serverLoginView = new ServerLoginView(serverLoginController.NewLoginAttempt);
            serverLoginController.SetDEL(this.LoginSuccess, serverLoginView.DisplayState);
            this.BidUpdateDEL = ServerCommCtrl.HandleBidUpdated;
            this.LoginReturnDEL = ServerCommCtrl.HandleLoginAttempt;
            this.GetClientDEL = ServerCommCtrl.GetClientIds;
            

            _userLoginInfo = BuildDictonary(_userFilepath);
            Application.Run(serverLoginView);
        }

        /// <summary>
        /// A method to check if the given username is valid, depending if its an admin login or not
        /// </summary>
        /// <param name="username">the username</param>
        /// <param name="password">password</param>
        /// <param name="IsAdmin">True if the attempt is an admin</param>
        public void NewLoginAttempt(string username, string password, string clientID)
        {
            //if it does not contain create new and return sucsessfull
            if (!(_userLoginInfo.ContainsKey(username)))
            {
                _userIdPair.Add(username, clientID);
                _userLoginInfo.Add(username, password); // add to dict
               
                WriteToJson(_userLoginInfo, _userFilepath); //overwrite with new dict
                LoginReturnDEL(true, clientID, _productDB.Products);
                UpdateStateDEL(AdminState.NEWCLIENT, _productDB, clientID);
            }
            else
            {
                if (_userLoginInfo[username] == password)
                {
                    if(_userIdPair.ContainsKey(username))
                        _userIdPair[username] = clientID;
                    else
                        _userIdPair.Add(username, clientID);
                    LoginReturnDEL(true, clientID, _productDB.Products );
                    UpdateStateDEL(AdminState.NEWCLIENT, _productDB, clientID);
                }
                else
                {
                    LoginReturnDEL(false,clientID, _productDB.Products);
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
        private void WriteToJson(object obj, string filePath)
        {
            string objStr = JsonConvert.SerializeObject(obj);
            File.WriteAllText(filePath, objStr);
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
                    if(p.MinBid < bid && !p.IsExpired)
                    {
                        p.BidCount++;
                        p.MinBid = bid;
                        BidUpdateDEL(bid, productID, clientID); // comunicating back to the clients
                        UpdateStateDEL(AdminState.EXPIREDBID, _productDB, null);
                    }
                    else
                    {
                        //supposedly do nothing and the other bid that causes this one to fail should update the view to alert them that they are not winning
                    }
                }
            }
        }

        /// <summary>
        /// method to be invoked on a sucsessfull login
        /// </summary>
        public void LoginSuccess()
        {
            
            List<Product> products = new List<Product>
            {
                new Product("", "Mini Corn Dogs (40 ct)", 300.0m, 0, false),
                new Product("", "Half-eaten banana", 10.0m, 0, false),
                new Product("", "30 ft. HDMI cable", 30.0m, 0, false),
                new Product("", "Blades of grass (5 pack)", 10000.0m, 0, false),
                new Product("", "Electric Guitar", 400.0m, 0, false),
            };
            




            AdminViewController adminViewController = new AdminViewController(_productDB);
            AdminView adminView = new AdminView(_productDB, GetClientDEL(), products, adminViewController.handleAddProduct, adminViewController.handleExpireProduct);
            adminViewController.addDels(ServerCommCtrl.SendProduct, adminView.DisplayState, ServerCommCtrl.HandleExpiringBid);
            adminView.ShowDialog();
            this.UpdateStateDEL = adminView.DisplayState;
            
        }

        /// <summary>
        /// A method to set the delegates
        /// </summary>
        /// <param name="bidUpdate">the bidUpdateDEL</param>
        /// <param name="LoginReturn">the LoginReturnDEL</param>
        /// <param name="GetClient"> the getClientDEL</param>
        /// <param name="UpdateState"> the UpdateStateDEL</param>
        public void SetDEL(BidUpdateDEL bidUpdate, LoginReturnDEL LoginReturn, GetClientDEL GetClient, UpdateStateDEL UpdateState)
        {
            BidUpdateDEL = bidUpdate;
            LoginReturnDEL = LoginReturn;
            GetClientDEL = GetClient;
            UpdateStateDEL = UpdateState;
        }

        public string GetClientID(string username)
        {
            string id;
            if(_userIdPair.TryGetValue(username, out id))
                return id;
            else
                return null;
        }

        
    }
}
