using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class Configuration
    {

        //public const string BASE_ADDRESS = "http://www.mychemhero.com/";
        public const string BASE_ADDRESS = "http://192.168.43.43/ChemHero/";
        //public const string BASE_ADDRESS = "http://localhost/ChemHero/";

        public static string VideoURL = Application.streamingAssetsPath + "/MCH_OP.mp4"; //"file://C:/Users/Kenneth/Documents/MCH_OP.mp4";
        //public static string VideoURL = "http://mychemhero.com/assets/MCH_OP.mp4";
        //public const string NAME = "kealu";
        public const int ID = 1;
    }
}
