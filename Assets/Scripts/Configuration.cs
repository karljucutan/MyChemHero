using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class Configuration
    {
        
        public const string BASE_ADDRESS = "http://localhost/ChemHero/";
        //public const string BASE_ADDRESS = "//192.168.0.5/ChemHero/";
        //public const string BASE_ADDRESS = "http://leaderboardtry.000webhostapp.com/";

        public static string VideoURL = Application.streamingAssetsPath + "/MCH_OP.mp4"; //"file://C:/Users/Kenneth/Documents/MCH_OP.mp4";
        public const string NAME = "kealu";
        public const int ID = 2;
    }
}
