using Assets.Scripts.Minigame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public class ListOfCity
    {
        public static List<City> Cities = new List<City>()
        {
            new City()
            {
                //White ( 255, 255, 255)
                Id = 1,
                Name = "Group1",
                ConquerorTeam = -1,
                Sectors = new List<Sector>()
                {   new Sector(){sectorNumber=1, conqueror = new User()},
                    new Sector(){sectorNumber=3, conqueror = new User()},
                    new Sector(){sectorNumber=11,conqueror = new User()},
                    new Sector(){sectorNumber=19,conqueror = new User()},
                    new Sector(){sectorNumber=37,conqueror = new User()},
                    new Sector(){sectorNumber=55,conqueror = new User()}
                }
            },
            new City()
            {   //{ 255, 153, 153 }
                Id = 2,
                Name = "Group2",
                ConquerorTeam = -1,
                Sectors = new List<Sector>()
                {
                    new Sector{sectorNumber=4, conqueror = new User()},
                    new Sector{sectorNumber=12,conqueror = new User()},
                    new Sector{sectorNumber=20,conqueror = new User()},
                    new Sector{sectorNumber=38,conqueror = new User()},
                    new Sector{sectorNumber=56,conqueror = new User()},
                    new Sector{sectorNumber=88,conqueror = new User()}
                }
            },
            new City()
            {   // {188, 122, 255 }
                Id = 3,
                Name = "Group3",
                ConquerorTeam = -1,
                Sectors = new List<Sector>()
                {
                    new Sector{sectorNumber=21,conqueror = new User()},
                    new Sector{sectorNumber=39,conqueror = new User()},
                    new Sector{sectorNumber=22,conqueror = new User()},
                    new Sector{sectorNumber=40,conqueror = new User()},
                    new Sector{sectorNumber=72,conqueror = new User()},
                }
            },
            new City()
            {   //{ 118, 255, 116 }
                Id = 4,
                Name = "Group4",
                ConquerorTeam = -1,
                Sectors = new List<Sector>()
                {
                    new Sector{sectorNumber=23,conqueror = new User()},
                    new Sector{sectorNumber=41,conqueror = new User()},
                    new Sector{sectorNumber=73,conqueror = new User()},
                    new Sector{sectorNumber=24,conqueror = new User()},
                    new Sector{sectorNumber=42,conqueror = new User()},
                    new Sector{sectorNumber=74,conqueror = new User()}
                }
            },
            new City()
            {   //{ 250, 0, 240 }
                Id = 5,
                Name = "Group5",
                ConquerorTeam = -1,
                Sectors = new List<Sector>()
                {
                    new Sector{sectorNumber=25,conqueror  = new User()},
                    new Sector{sectorNumber=43,conqueror  = new User()},
                    new Sector{sectorNumber=75,conqueror  = new User()},
                    new Sector{sectorNumber=26,conqueror  = new User()},
                    new Sector{sectorNumber=44,conqueror  = new User()},
                    new Sector{sectorNumber=76,conqueror  = new User()}
                }
            },
            new City()
            {
                //{ 184, 227, 255 }
                Id = 6,
                Name = "Group6",
                ConquerorTeam = -1,
                Sectors = new List<Sector>()
                {
                    new Sector{sectorNumber=27,conqueror = new User()},
                    new Sector{sectorNumber=45,conqueror = new User()},
                    new Sector{sectorNumber=77,conqueror = new User()},
                    new Sector{sectorNumber=28,conqueror = new User()},
                    new Sector{sectorNumber=46,conqueror = new User()},
                    new Sector{sectorNumber=78,conqueror = new User()}
                }
            },
            new City()
            {   //{ 255, 166, 64 }
                Id = 7,
                Name = "Group7",
                ConquerorTeam = -1,
                Sectors = new List<Sector>()
                {
                    new Sector{sectorNumber=29,conqueror = new User()},
                    new Sector{sectorNumber=47,conqueror = new User()},
                    new Sector{sectorNumber=79,conqueror = new User()},
                    new Sector{sectorNumber=30,conqueror = new User()},
                    new Sector{sectorNumber=48,conqueror = new User()},
                    new Sector{sectorNumber=80,conqueror = new User()}
                }
            },
            new City()
            {
                //{ 0, 255, 255 }
                Id = 8,
                Name = "Group8",
                ConquerorTeam = -1,
                Sectors = new List<Sector>()
                {
                    new Sector{sectorNumber=5,conqueror = new User()},
                    new Sector{sectorNumber=13,conqueror = new User()},
                    new Sector{sectorNumber=31,conqueror = new User()},
                    new Sector{sectorNumber=49,conqueror = new User()},
                    new Sector{sectorNumber=81,conqueror = new User()}
                }
            },
            new City()
            {   
                //{ 255, 102, 255 }
                Id = 9,
                Name = "Group9",
                ConquerorTeam = -1,
                Sectors = new List<Sector>()
                {
                    new Sector{sectorNumber=6,conqueror = new User()},
                    new Sector{sectorNumber=14,conqueror = new User()},
                    new Sector{sectorNumber=32,conqueror = new User()},
                    new Sector{sectorNumber=50,conqueror = new User()},
                    new Sector{sectorNumber=82,conqueror = new User()}
                }
            },
            new City()
            {
                //{ 174, 255, 187 }
                Id = 10,
                Name = "Group10",
                ConquerorTeam = -1,
                Sectors = new List<Sector>()
                {
                    new Sector{sectorNumber=7,conqueror = new User()},
                    new Sector{sectorNumber=15,conqueror = new User()},
                    new Sector{sectorNumber=33,conqueror = new User()},
                    new Sector{sectorNumber=51,conqueror = new User()},
                    new Sector{sectorNumber=83,conqueror = new User()}
                }
            },
            new City()
            {   
                //{ 255, 173, 173 }
                Id = 11,
                Name = "Group11",
                ConquerorTeam = -1,
                Sectors = new List<Sector>()
                {
                    new Sector{sectorNumber=8,conqueror = new User()},
                    new Sector{sectorNumber=16,conqueror = new User()},
                    new Sector{sectorNumber=34,conqueror = new User()},
                    new Sector{sectorNumber=52,conqueror = new User()},
                    new Sector{sectorNumber=84,conqueror = new User()}
                }
            },
            new City()
            {
                //{ 113, 217, 255 }
                Id = 12,
                Name = "Group12",
                ConquerorTeam = -1,
                Sectors = new List<Sector>()
                {
                    new Sector{sectorNumber=9,conqueror = new User()},
                    new Sector{sectorNumber=17,conqueror = new User()},
                    new Sector{sectorNumber=35,conqueror = new User()},
                    new Sector{sectorNumber=53,conqueror = new User()},
                    new Sector{sectorNumber=85,conqueror = new User()}
                }
            },
            new City()
            {
                //{ 255, 204, 153 }
                Name = "Group13",
                Id = 13,
                ConquerorTeam = -1,
                Sectors = new List<Sector>()
                {
                    new Sector{sectorNumber=2,conqueror = new User()},
                    new Sector{sectorNumber=10,conqueror = new User()},
                    new Sector{sectorNumber=18,conqueror = new User()},
                    new Sector{sectorNumber=36,conqueror = new User()},
                    new Sector{sectorNumber=54,conqueror = new User()},
                    new Sector{sectorNumber=86,conqueror = new User()}
                }
            },
            new City()
            {   
                //{ 204, 255, 153 }
                Id = 14,
                Name = "Group14",
                ConquerorTeam = -1,
                Sectors = new List<Sector>()
                {
                    new Sector{sectorNumber=57,conqueror = new User()},
                    new Sector{sectorNumber=58,conqueror = new User()},
                    new Sector{sectorNumber=59,conqueror = new User()},
                    new Sector{sectorNumber=60,conqueror = new User()},
                    new Sector{sectorNumber=61,conqueror = new User()}
                }
            },
            new City()
            {   
                //{ 102, 178, 255 }
                Id = 15,
                Name = "Group15",
                ConquerorTeam = -1,
                Sectors = new List<Sector>()
                {
                    new Sector{sectorNumber=89,conqueror = new User()},
                    new Sector{sectorNumber=90,conqueror = new User()},
                    new Sector{sectorNumber=91,conqueror = new User()},
                    new Sector{sectorNumber=92,conqueror = new User()},
                    new Sector{sectorNumber=93,conqueror = new User()}
                }
            },
            new City()
            {   
                //{ 190, 190, 190 }
                Id = 16,
                Name = "Group16",
                ConquerorTeam = -1,
                Sectors = new List<Sector>()
                {
                    new Sector{sectorNumber=62,conqueror = new User()},
                    new Sector{sectorNumber=63,conqueror = new User()},
                    new Sector{sectorNumber=64,conqueror = new User()},
                    new Sector{sectorNumber=65,conqueror = new User()},
                    new Sector{sectorNumber=66,conqueror = new User()}
                }
            },
            new City()
            {
                //{ 153, 255, 204 }
                Id = 17,
                Name = "Group17",
                ConquerorTeam = -1,
                Sectors = new List<Sector>()
                {
                    new Sector{sectorNumber=94,conqueror = new User()},
                    new Sector{sectorNumber=95,conqueror = new User()},
                    new Sector{sectorNumber=96,conqueror = new User()},
                    new Sector{sectorNumber=97,conqueror = new User()},
                    new Sector{sectorNumber=98,conqueror = new User()}
                }
            },
            new City()
            {
                //{ 255, 231, 147 }
                Id = 18,
                Name = "Group18",
                ConquerorTeam = -1,
                Sectors = new List<Sector>()
                {
                    new Sector{sectorNumber=67,conqueror = new User()},
                    new Sector{sectorNumber=68,conqueror = new User()},
                    new Sector{sectorNumber=69,conqueror = new User()},
                    new Sector{sectorNumber=70,conqueror = new User()},
                    new Sector{sectorNumber=71,conqueror = new User()}
                }
            },
            new City()
            {
                //{ 255, 141, 141 }
                Id = 19,
                Name = "Group19",
                ConquerorTeam = -1,
                Sectors = new List<Sector>()
                {
                    new Sector{sectorNumber=99,conqueror = new User()},
                    new Sector{sectorNumber=100,conqueror = new User()},
                    new Sector{sectorNumber=101,conqueror = new User()},
                    new Sector{sectorNumber=102,conqueror = new User()},
                    new Sector{sectorNumber=103,conqueror = new User()}
                }
            }
        };
    }
}
