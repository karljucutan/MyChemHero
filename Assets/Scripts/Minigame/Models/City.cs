using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Minigame.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Sector> Sectors;
        public int ConquerorTeam;
    }
}
