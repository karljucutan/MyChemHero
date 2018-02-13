using Assets.Scripts;
using Assets.Scripts.Minigame.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class DataPersistor : MonoBehaviour {

    public static DataPersistor persist;
    public Dictionary<string, string> elementDictionary;

    public Color color;
    public string compoundNeeded;
    public ModelTime mTime;

    public User user;
    public User TempUser;
    public string[] values;

    //teamselection and character customization
    public int teamSelecetionFactionId;// TEAM ID NA GAGAMITIN
    public int teamId;
    //public string teamName;
    //public int teamColorId;

    //end scene
    public string endSceneBG;
    public string endSceneHeroImage;
    public string[] endSceneDialogueString; // dito nilalagay yung dialogue para sa endscene na galing sa unity editor
    public int accumulatedPoints = 0;
    public int totalPoints = 0;
    public int helpsMade = 0;

    private bool gettingSession = false;
    private bool gettingid = false;
    //setting of ConquerorsProfile
    public int currentSectorNumber;
    private string name = "";
    public int id = 0;

    //list of gameobjects para mapersist sa next scene in MinigameDragDrop
    public List<string> bagCompounds;// = new List<GameObject>();
    public string sectorCity = "";

    //state kung may team na
    public string state = "";

    void Awake()
    {
        if (persist == null)
        {
            
            DontDestroyOnLoad(gameObject);
            persist = this;
               
        }
        else if (persist != this)
        {
            
            Destroy(gameObject);
            
        }
        user = new User();
        user.UserCharacter = new Character();
        StartCoroutine(GetPlayerSession());
        StartCoroutine(GetPlayerId());
        //StartCoroutine(RetrieveUserInfo());
        StartCoroutine(RetrieveAllUsersInfo());
       
        StartCoroutine(starPolling());
        StartCoroutine(starPollingNewUsers());
        StartCoroutine(starPollingUser());
    }

    void Start()
    {
        DataPersistor.persist.bagCompounds = new List<string>();
        mTime = new ModelTime();

        elementDictionary = new Dictionary<string, string>
        {
            {"H","Hydrogen"},
            {"He","Helium"},
            {"Li","Lithium"},
            {"Be","Beryllium"},
            {"B","Boron"},
            {"C","Carbon"},
            {"N","Nitrogen"},
            {"O","Oxygen"},
            {"F","Fluorine"},
            {"Ne","Neon"},
            {"Na","Sodium"},
            {"Mg","Magnesium"},
            {"Al","Aluminum"},
            {"Si","Silicon"},
            {"P","Phosphorus"},
            {"S","Sulfur"},
            {"Cl","Chlorine"},
            {"Ar","Argon"},
            {"K","Potassium"},
            {"Ca","Calcium"},
            {"Sc","Scandium"},
            {"Ti","Titanium"},
            {"V","Vanadium"},
            {"Cr","Chromium"},
            {"Mn","Manganese"},
            {"Fe","Iron"},
            {"Co","Cobalt"},
            {"Ni","Nickel"},
            {"Cu","Copper"},
            {"Zn","Zinc"},
            {"Ga","Gallium"},
            {"Ge","Germanium"},
            {"As","Arsenic"},
            {"Se","Selenium"},
            {"Br","Bromine"},
            {"Kr","Krypton"},
            {"Rb","Rubidium"},
            {"Sr","Strontium"},
            {"Y","Yttrium"},
            {"Zr","Zirconium"},
            {"Nb","Niobium"},
            {"Mo","Molybdenur"},
            {"Tc","Technetium"},
            {"Ru","Ruthenium"},
            {"Rh","Rhodium"},
            {"Pd","Palladium"},
            {"Ag","Silver"},
            {"Cd","Cadmium"},
            {"In","Indium"},
            {"Sn","Tin"},
            {"Sb","Antimony"},
            {"Te","Tellurium"},
            {"I","Iodine"},
            {"Xe","Xenon"},
            {"Cs","Caesium"},
            {"Ba","Barium"},
            {"La","Lanthanum"},
            {"Ce","Cerium"},
            {"Pr","Praseodymium"},
            {"Nd","Neodymium"},
            {"Pm","Promethium"},
            {"Sm","Samarium"},
            {"Eu","Europium"},
            {"Gd","Gadolinium"},
            {"Tb","Terbium"},
            {"Dy","Dysprosium"},
            {"Ho","Holmium"},
            {"Er","Erbium"},
            {"Tm","Thulium"},
            {"Yb","Ytterbium"},
            {"Lu","Lutetium"},
            {"Hf","Hafnium"},
            {"Ta","Tantalum"},
            {"W","Tungsten"},
            {"Re","Rhenium"},
            {"Os","Osmium"},
            {"Ir","Iridium"},
            {"Pt","Platinum"},
            {"Au","Gold"},
            {"Hg","Mercury"},
            {"Tl","Thallium"},
            {"Pb","Lead"},
            {"Bi","Bismuth"},
            {"Po","Polonium"},
            {"At","Astatine"},
            {"Rn","Radon"},
            {"Fr","Francium"},
            {"Ra","Radium"},
            {"Ac","Actinium"},
            {"Th","Thorium"},
            {"Pa","Protactinium"},
            {"U","Uranium"},
            {"Np","Neptunium"},
            {"Pu","Plutonium"},
            {"Am","Americium"},
            {"Cm","Curium"},
            {"Bk","Berkelium"},
            {"Cf","Californium"},
            {"Es","Einsteinium"},
            {"Fm","Fermium"},
            {"Md","Mendelevium"},
            {"No","Nobelium"},
            {"Lr","Lawrencium"},
            {"Rf","Rutherfordium"},
            {"Db","Dubnium"},
            {"Sg","Seaborgium"},
            {"Bh","Bohrium"},
            {"Hs","Hassium"},
            {"Mt","Meitnerium"},
            {"Ds","Darmstadtium"},
            {"Rg","Roentgenium"},
            {"Cn","Copernicium"},
            {"Nh","Nihonium"},
            {"Fl","Flerovium"},
            {"Mc","Moscovium"},
            {"Lv","Livermorium"},
            {"Ts","Tennessine"},
            {"Og","Oganesson"},
        };

    }

    void OnGUI()
    {
      //  GUI.Label(new Rect(10, 10, 200, 50), "Color: " + color.ToString());
    }

    public void setColor(string _color)
    {
        Color newColor = new Color();
        switch(_color)
        {
            case "blue": newColor = Color.blue; SetTeamId(1); break;
            case "red": newColor = Color.red; SetTeamId(2); break;
            case "green": newColor = Color.green; SetTeamId(3); break;
            case "yellow": newColor = Color.yellow; SetTeamId(4); break;
        }
        color = newColor;
    }
    // 1 = blue 2 = red 3 = green 4 = yellow
    private void SetTeamId(int colorId)
    {
        teamId = ListOfTeams.TeamList.Where(t => t.teamColorId.Equals(colorId)).Select(t => t.teamId).SingleOrDefault();
    }

    private IEnumerator starPolling ()
    {
        while(true)
        {
            StartCoroutine(GetSectorHolderScores());
           
            yield return new WaitForSeconds(2);
        }
    }
    private IEnumerator starPollingNewUsers()
    {
        while (true)
        {
            StartCoroutine(RetrieveAllUsersInfo());

            yield return new WaitForSeconds(3);
        }
    }
    private IEnumerator starPollingUser()
    {
        while (true)
        {
            StartCoroutine(RetrieveUserInfo());
            StartCoroutine(RetrieveUserBadges());
            yield return new WaitForSeconds(2);
        }
    }
    IEnumerator GetPlayerSession()
    {
        gettingSession = true;
        WWW get = new WWW(Configuration.BASE_ADDRESS + "unityLink.php");
        yield return get;

        if (get.error != null)
        {
            Debug.Log("There was an error getting the high score: " + get.error);

        }
        else
        {
            // name =get.text;
            name = "Karl";
            Debug.Log("name is: "+name);
        }

        gettingSession = false;
    }
    IEnumerator GetPlayerId()
    {
        while (gettingSession)
        {
            yield return new WaitForSeconds(0.1f);
        }
            gettingid = true;
            Debug.Log("name is: " + name);
            gettingid = false;
            WWW get = new WWW(Configuration.BASE_ADDRESS + "getplayerid.php?name="+name);
            yield return get;

            if (get.error != null)
            {
                Debug.Log("There was an error getting the high score: " + get.error);

            }
            else
            {
                user.ID = int.Parse(get.text);
                id = user.ID;
                Debug.Log("id is" + user.ID+"we done here");
            }
            gettingid = false;
            StartCoroutine(RetrieveUserInfo());
        
    }
    IEnumerator GetSectorHolderScores()
    {
        
        WWW get = new WWW(Configuration.BASE_ADDRESS + "GetSectorHolders.php");
        yield return get;

        if (get.error != null)
        {
            Debug.Log("There was an error getting the high score: " + get.error);

        }
        else
        {
            string help = get.text;
            Debug.Log(help + "");
            values = help.Split('+');

        }

    }

    public IEnumerator RetrieveUserInfo()//FOR USERS INFO
    {
    
            WWW hs_get = new WWW(Configuration.BASE_ADDRESS + "RetrieveInfo.php?pid=" + user.ID);
            yield return hs_get;

            if (hs_get.error != null)
            {
                Debug.Log("There was an error getting the high score: " + hs_get.error);

            }
            else
            {
                string help = hs_get.text;
                string[] userInfo = help.Split(';');

                //temporary lng to kukuha pa sa php session ng value
                if (userInfo[1] != "")
                {
                    user.UserName = userInfo[0];
                    user.UserCharacter.Face = int.Parse(userInfo[1]);
                    user.UserCharacter.Hair = int.Parse(userInfo[2]);
                    user.UserCharacter.Eyes = int.Parse(userInfo[3]);
                    user.UserCharacter.Nose = int.Parse(userInfo[4]);
                    user.UserCharacter.Mouth = int.Parse(userInfo[5]);
                    user.TotalScore = int.Parse(userInfo[6]);
                    user.HelpsMade = int.Parse(userInfo[7]);
                    user.SectorsHold = int.Parse(userInfo[8]);
                    user.FactionId = int.Parse(userInfo[9]);
                }
                //user.SectorsHold = int.Parse();


            }
        
    }

    private IEnumerator RetrieveAllUsersInfo()
    {
        WWW hs_get = new WWW(Configuration.BASE_ADDRESS + "GetAllUsers.php");
        yield return hs_get;

        if (hs_get.error != null)
        {
            Debug.Log("There was an error getting the high score: " + hs_get.error);

        }
        else
        {
            string help = hs_get.text;

            string[] userInfo = help.Split('+');
            for (int i = 0; i < userInfo.Length-1; i++)
            {
                string[] individualValues = userInfo[i].Split(';');
                TempUser = new User();
                TempUser.UserCharacter = new Character();
                TempUser.ID = int.Parse(individualValues[0]);
                TempUser.UserName = individualValues[1];
                TempUser.FactionId = int.Parse(individualValues[2]);
                TempUser.TotalScore = int.Parse(individualValues[3]);
                TempUser.UserCharacter.Face = int.Parse(individualValues[4]);
                TempUser.UserCharacter.Hair = int.Parse(individualValues[5]);
                TempUser.UserCharacter.Eyes = int.Parse(individualValues[6]);
                TempUser.UserCharacter.Nose = int.Parse(individualValues[7]);
                TempUser.UserCharacter.Mouth = int.Parse(individualValues[8]);

                ListOfUser.ALLUSERS.Add(TempUser);

               
            }

        }
    }

    private IEnumerator RetrieveUserBadges()
    {
        WWW get = new WWW(Configuration.BASE_ADDRESS + "GetBadges.php?playerid="+user.ID);
        yield return get;

        if (get.error != null)
        {
            Debug.Log("There was an error getting the high score: " + get.error);
        }
        else
        {
            user.Badges.Clear();
            string help = get.text;
            //Debug.Log(help + "");
            string[] badges = help.Split(';');
            
            for(int i = 0; i < badges.Length-1; i++)
            {
               user.Badges.Add(badges[i]);
               Debug.Log(user.Badges[i]+"BADGETO");
            }

        }
    }

   

   

  
}
