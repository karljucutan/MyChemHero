using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Minigame.Models
{
    public class Team
    {
        public int teamId;
        public int teamColorId;
        public string teamName;
        public int teamLeaderId;
        public List<User> members;
        public List<int> conqueredCities = new List<int>();
    }
}
