
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Minigame
{
    class PairOfElementCompound
    {
              
        public static List<ElementCompound> listOfPairElementCompound = new List<ElementCompound>()
        {
            new ElementCompound(){  elementcompound = new KeyValuePair<string, string>("H2O","Water")},
            new ElementCompound(){  elementcompound = new KeyValuePair<string, string>("NaCl","Salt")},
            new ElementCompound(){  elementcompound = new KeyValuePair<string, string>("C6H8O6","Ascorbic Acid")},
            new ElementCompound(){  elementcompound = new KeyValuePair<string, string>("H2O2","Agua Oxinada")},
            new ElementCompound(){  elementcompound = new KeyValuePair<string, string>("HCl","Muriatic Acid")},
            new ElementCompound(){  elementcompound = new KeyValuePair<string, string>("C2H6O","Alcohol")},
            new ElementCompound(){  elementcompound = new KeyValuePair<string, string>("NaHCO3","Baking Soda")},
            new ElementCompound(){  elementcompound = new KeyValuePair<string, string>("C4H10","Butane")},
            new ElementCompound(){  elementcompound = new KeyValuePair<string, string>("N2O","Nitro")},
            new ElementCompound(){  elementcompound = new KeyValuePair<string, string>("NaF","Sodium Fluoride")},

        };
    }
}
