using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Minigame.Models
{
    public class User
    {
        public string UserName;
        public int ID;
        public int TotalScore;
        public Character UserCharacter;
        public int SectorsHold;
        public int HelpsMade;
        public int FactionId;
        public List<string> Badges = new List<string>();

    }
}
