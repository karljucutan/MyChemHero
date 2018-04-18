using Assets.Scripts.Minigame.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using Assets.Scripts;

public class SectorScript : MonoBehaviour {
    
    public int sectorNumber;
    GameObject confirm;
    private GameObject resettimerMiniGameDragDrop;
    private GameObject resettimerMinigameFreeThrow;
    private GameObject resettimerMinigameTapTapCompound;
    // Use this for initialization
    //public GameObject sectorName;
   
    private string[] sectorInfo;
    private GameObject profilesetter;
    private User conqueror;

    public Dictionary<string, string> elementNumberDictionary;

    void Awake()
    {
       
        confirm = GameObject.Find("ConfirmDialog");
        conqueror = new User();
        conqueror.UserCharacter = new Character();
      
    }
    void Start()
    {
        resettimerMiniGameDragDrop = GameObject.Find("MinigameFullDragDropResetTimer");
        resettimerMinigameFreeThrow = GameObject.Find("MinigameFreeThrowResetTimer");
        resettimerMinigameTapTapCompound = GameObject.Find("MinigameTapTapCompound");
        // yung 1 games pa
        gameObject.GetComponentInChildren<Text>().text = gameObject.name;
        profilesetter = GameObject.Find("ProfileSetter");

        elementNumberDictionary = new Dictionary<string, string>
        {   
            {"H","1"},
            {"He","2"},
            {"Li","3"},
            {"Be","4"},
            {"B","5"},
            {"C","6"},
            {"N","7"},
            {"O","8"},
            {"F","9"},
            {"Ne","10"},
            {"Na","11"},
            {"Mg","12"},
            {"Al","13"},
            {"Si","14"},
            {"P","15"},
            {"S","16"},
            {"Cl","17"},
            {"Ar","18"},
            {"K","19"},
            {"Ca","20"},
            {"Sc","21"},
            {"Ti","22"},
            {"V","23"},
            {"Cr","24"},
            {"Mn","25"},
            {"Fe","26"},
            {"Co","27"},
            {"Ni","28"},
            {"Cu","29"},
            {"Zn","30"},
            {"Ga","31"},
            {"Ge","32"},
            {"As","33"},
            {"Se","34"},
            {"Br","35"},
            {"Kr","36"},
            {"Rb","37"},
            {"Sr","38"},
            {"Y","39"},
            {"Zr","40"},
            {"Nb","41"},
            {"Mo","42"},
            {"Tc","43"},
            {"Ru","44"},
            {"Rh","45"},
            {"Pd","46"},
            {"Ag","47"},
            {"Cd","48"},
            {"In","49"},
            {"Sn","50"},
            {"Sb","51"},
            {"Te","52"},
            {"I","53"},
            {"Xe","54"},
            {"Cs","55"},
            {"Ba","56"},
            {"La","57"},
            {"Ce","58"},
            {"Pr","59"},
            {"Nd","60"},
            {"Pm","61"},
            {"Sm","62"},
            {"Eu","63"},
            {"Gd","64"},
            {"Tb","65"},
            {"Dy","66"},
            {"Ho","67"},
            {"Er","68"},
            {"Tm","69"},
            {"Yb","70"},
            {"Lu","71"},
            {"Hf","72"},
            {"Ta","73"},
            {"W","74"},
            {"Re","75"},
            {"Os","76"},
            {"Ir","77"},
            {"Pt","78"},
            {"Au","79"},
            {"Hg","80"},
            {"Tl","81"},
            {"Pb","82"},
            {"Bi","83"},
            {"Po","84"},
            {"At","85"},
            {"Rn","86"},
            {"Fr","87"},
            {"Ra","88"},
            {"Ac","89"},
            {"Th","90"},
            {"Pa","91"},
            {"U","92"},
            {"Np","93"},
            {"Pu","94"},
            {"Am","95"},
            {"Cm","96"},
            {"Bk","97"},
            {"Cf","98"},
            {"Es","99"},
            {"Fm","100"},
            {"Md","101"},
            {"No","102"},
            {"Lr","103"},
            {"Rf","104"},
            {"Db","105"},
            {"Sg","106"},
            {"Bh","107"},
            {"Hs","108"},
            {"Mt","109"},
            {"Ds","110"},
            {"Rg","111"},
            {"Cn","112"},
            {"Nh","113"},
            {"Fl","114"},
            {"Mc","115"},
            {"Lv","116"},
            {"Ts","117"},
            {"Og","118"},
            
        };

        string numberString;                                                    //
        elementNumberDictionary.TryGetValue(gameObject.name, out numberString); //
        sectorNumber = int.Parse(numberString);                                 //setting of sector number; dependent with individual, manually encoded button names
    }

    // Update is called once per frame
    void Update()
    {
        sectorInfo = DataPersistor.persist.values[sectorNumber - 1].Split(';');
        if (sectorInfo[0] != "")
        {
            conqueror = ListOfUser.ALLUSERS.Where(u => u.ID.Equals(int.Parse(sectorInfo[0]))).FirstOrDefault();

            var city = ListOfCity.Cities.FirstOrDefault(c => c.Sectors.Any(s => s.sectorNumber.Equals(sectorNumber)));
            var sector = city.Sectors.Where(s => s.sectorNumber.Equals(sectorNumber)).FirstOrDefault();
            sector.conqueror.ID = conqueror.ID;
            sector.conqueror.TeamId = conqueror.TeamId;
            sector.conqueror.UserName = conqueror.UserName;

            ChangeColorAlpha(gameObject.transform.Find("ImageUserCharacterContainer/Character/Body").GetComponent<Image>(), 255, 255, 255, 255);
            ChangeColorAlpha(gameObject.transform.Find("ImageUserCharacterContainer/Character/Body/Hair").GetComponent<Image>(), 255, 255, 255, 255);
            ChangeColorAlpha(gameObject.transform.Find("ImageUserCharacterContainer/Character/Body/Eyebrows").GetComponent<Image>(), 255, 255, 255, 255);
            ChangeColorAlpha(gameObject.transform.Find("ImageUserCharacterContainer/Character/Body/Eyes").GetComponent<Image>(), 255, 255, 255, 255);
            ChangeColorAlpha(gameObject.transform.Find("ImageUserCharacterContainer/Character/Body/Nose").GetComponent<Image>(), 255, 255, 255, 255);
            ChangeColorAlpha(gameObject.transform.Find("ImageUserCharacterContainer/Character/Body/Mouth").GetComponent<Image>(), 255, 255, 255, 255);
            ChangeColorAlpha(gameObject.transform.Find("Flag").GetComponent<Image>(), 255, 255, 255, 255);

            gameObject.transform.Find("ImageUserCharacterContainer/Character/Body").GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().GetCharacterBody(conqueror.UserCharacter.Gender, conqueror.UserCharacter.Body);
            gameObject.transform.Find("ImageUserCharacterContainer/Character/Body/Hair").GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().GetCharacterHair(conqueror.UserCharacter.Gender, conqueror.UserCharacter.Hair);
            gameObject.transform.Find("ImageUserCharacterContainer/Character/Body/Eyebrows").GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().GetCharacterEyebrows(conqueror.UserCharacter.Gender, conqueror.UserCharacter.EyeBrows);
            gameObject.transform.Find("ImageUserCharacterContainer/Character/Body/Eyes").GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().GetCharacterEyes(conqueror.UserCharacter.Gender, conqueror.UserCharacter.Eyes);
            gameObject.transform.Find("ImageUserCharacterContainer/Character/Body/Nose").GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().GetCharacterNose(conqueror.UserCharacter.Gender, conqueror.UserCharacter.Nose);
            gameObject.transform.Find("ImageUserCharacterContainer/Character/Body/Mouth").GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().GetCharacterMouth(conqueror.UserCharacter.Gender, conqueror.UserCharacter.Mouth);
            gameObject.transform.Find("Flag").GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().TeamFlag[conqueror.TeamId - 1];

             

        }
        else
        {
            ChangeColorAlpha(gameObject.transform.Find("ImageUserCharacterContainer/Character/Body").GetComponent<Image>(), 255, 255, 255, 0);
            ChangeColorAlpha(gameObject.transform.Find("ImageUserCharacterContainer/Character/Body/Hair").GetComponent<Image>(), 255, 255, 255, 0);
            ChangeColorAlpha(gameObject.transform.Find("ImageUserCharacterContainer/Character/Body/Eyebrows").GetComponent<Image>(), 255, 255, 255, 0);
            ChangeColorAlpha(gameObject.transform.Find("ImageUserCharacterContainer/Character/Body/Eyes").GetComponent<Image>(), 255, 255, 255, 0);
            ChangeColorAlpha(gameObject.transform.Find("ImageUserCharacterContainer/Character/Body/Nose").GetComponent<Image>(), 255, 255, 255, 0);
            ChangeColorAlpha(gameObject.transform.Find("ImageUserCharacterContainer/Character/Body/Mouth").GetComponent<Image>(), 255, 255, 255, 0);
            ChangeColorAlpha(gameObject.transform.Find("Flag").GetComponent<Image>(), 255, 255, 255, 0);
        }


   


    }

    public void clicked()
    {
        var sad = ListOfCity.Cities;
        var asd = ListOfUser.ALLUSERS;
        confirm.SetActive(true);
    
        switch(gameObject.tag)
        {
            case "Metals": resettimerMiniGameDragDrop.GetComponent<ResetTimerSetter>().ResetTimer(); DataPersistor.persist.bagCompounds.Clear(); break;
            case "NonMetals": resettimerMinigameFreeThrow.GetComponent<ResetTimerSetter>().ResetTimer(); break;
            //case "Metalloids": resettimerMiniGameDragDrop.GetComponent<ResetTimerSetter>().ResetTimer(); break;
            case "Unknown": resettimerMinigameTapTapCompound.GetComponent<ResetTimerSetter>().ResetTimer(); break;
        }
     
        DataPersistor.persist.currentSectorNumber = sectorNumber;
        DataPersistor.persist.sectorCity = gameObject.tag;

        Debug.Log(DataPersistor.persist.sectorCity);

        if (sectorInfo[0] != "")
        {
            conquerorsProfile(conqueror.UserName, sectorInfo[1].ToString());
        }
        else
        {
            conquerorsProfile("???", "00");
        }

        gameObject.GetComponentInParent<DisablerEnabler>().btnDisabler(gameObject.GetComponent<Button>());
    }

    private void conquerorsProfile(string username, string score)
    {
        //GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/ImageUserCharacterContainer/ImageUserFlag").GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().TeamFlag[teamId];
        //GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/ImageUserCharacterContainer/ImageUserCharacterFace").GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().FaceChoices[face];
        //GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/ImageUserCharacterContainer/ImageUserCharacterHair").GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().HairChoices[hair];
        //GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/ImageUserCharacterContainer/ImageUserCharacterEyes").GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().EyesChoices[eyes];
        //GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/ImageUserCharacterContainer/ImageUserCharacterNose").GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().NoseChoices[nose];
        //GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/ImageUserCharacterContainer/ImageUserCharacterMouth").GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().MouthChoices[mouth];
        GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/TextUserName").GetComponent<Text>().text = username;
        GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/TextScore").GetComponent<Text>().text = score;

        if(username.Equals("???"))
        {
            ChangeColorAlpha(GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/ImageUserCharacterContainer/Flag").GetComponent<Image>(), 255, 255, 255, 0);
            ChangeColorAlpha(GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/ImageUserCharacterContainer/Character/Body").GetComponent<Image>(), 255, 255, 255, 0);
            ChangeColorAlpha(GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/ImageUserCharacterContainer/Character/Body/Hair").GetComponent<Image>(), 255, 255, 255, 0);
            ChangeColorAlpha(GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/ImageUserCharacterContainer/Character/Body/Eyebrows").GetComponent<Image>(), 255, 255, 255, 0);
            ChangeColorAlpha(GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/ImageUserCharacterContainer/Character/Body/Eyes").GetComponent<Image>(), 255, 255, 255, 0);
            ChangeColorAlpha(GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/ImageUserCharacterContainer/Character/Body/Nose").GetComponent<Image>(), 255, 255, 255, 0);
            ChangeColorAlpha(GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/ImageUserCharacterContainer/Character/Body/Mouth").GetComponent<Image>(), 255, 255, 255, 0);
        }
        else
        {
            ChangeColorAlpha(GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/ImageUserCharacterContainer/Flag").GetComponent<Image>(), 255, 255, 255, 255);
            ChangeColorAlpha(GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/ImageUserCharacterContainer/Character/Body").GetComponent<Image>(), 255, 255, 255, 255);
            ChangeColorAlpha(GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/ImageUserCharacterContainer/Character/Body/Hair").GetComponent<Image>(), 255, 255, 255, 255);
            ChangeColorAlpha(GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/ImageUserCharacterContainer/Character/Body/Eyebrows").GetComponent<Image>(), 255, 255, 255, 255);
            ChangeColorAlpha(GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/ImageUserCharacterContainer/Character/Body/Eyes").GetComponent<Image>(), 255, 255, 255, 255);
            ChangeColorAlpha(GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/ImageUserCharacterContainer/Character/Body/Nose").GetComponent<Image>(), 255, 255, 255, 255);
            ChangeColorAlpha(GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/ImageUserCharacterContainer/Character/Body/Mouth").GetComponent<Image>(), 255, 255, 255, 255);

            GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/ImageUserCharacterContainer/Flag").GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().TeamFlag[conqueror.TeamId - 1];
            GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/ImageUserCharacterContainer/Character/Body").GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().GetCharacterBody(conqueror.UserCharacter.Gender, conqueror.UserCharacter.Body);
            GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/ImageUserCharacterContainer/Character/Body/Hair").GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().GetCharacterHair(conqueror.UserCharacter.Gender, conqueror.UserCharacter.Hair);
            GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/ImageUserCharacterContainer/Character/Body/Eyebrows").GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().GetCharacterEyebrows(conqueror.UserCharacter.Gender, conqueror.UserCharacter.EyeBrows);
            GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/ImageUserCharacterContainer/Character/Body/Eyes").GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().GetCharacterEyes(conqueror.UserCharacter.Gender, conqueror.UserCharacter.Eyes);
            GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/ImageUserCharacterContainer/Character/Body/Nose").GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().GetCharacterNose(conqueror.UserCharacter.Gender, conqueror.UserCharacter.Nose);
            GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/ImageUserCharacterContainer/Character/Body/Mouth").GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().GetCharacterMouth(conqueror.UserCharacter.Gender, conqueror.UserCharacter.Mouth);
          
        }
    }

    private void ChangeColorAlpha(Image img, int r, int g, int b, int a)
    {
        img.color = new Color(r, g, b, a);
    }

   
}
