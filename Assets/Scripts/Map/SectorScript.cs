using Assets.Scripts.Minigame.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class SectorScript : MonoBehaviour {
    
    public int sectorNumber;
    GameObject confirm;
    private GameObject resettimerMiniGameDragDrop;
    private GameObject resettimerMinigameFreeThrow;
    private GameObject resettimerMinigameTapTapCompound;
    // Use this for initialization
    //public GameObject sectorName;
    private GameObject elements;
    private GameObject[] columns;
    private List<Button> buttons;

    private int highScore;
    private string[] sectorInfo;
    private GameObject profilesetter;
    private User conqueror;

    public Dictionary<string, string> elementNumberDictionary;

    void Awake()
    {
       
        confirm = GameObject.Find("ConfirmDialog");
        
      
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

        string numberString;
        elementNumberDictionary.TryGetValue(gameObject.name, out numberString);
        sectorNumber = int.Parse(numberString);
    }

    // Update is called once per frame
    void Update()
    {

        sectorInfo = DataPersistor.persist.values[sectorNumber - 1].Split(';');
        if (sectorInfo[0] != "")
        {
            conqueror = ListOfUser.ALLUSERS.Where(u => u.ID.Equals(int.Parse(sectorInfo[0]))).FirstOrDefault();


            // gameObject.transform.Find("Conqueror").GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("BannerRed");
            ChangeColorAlpha(gameObject.transform.Find("ImageUserCharacterContainer/ImageUserCharacterFace").GetComponent<Image>(), 255, 255, 255, 255);
            ChangeColorAlpha(gameObject.transform.Find("ImageUserCharacterContainer/ImageUserCharacterHair").GetComponent<Image>(), 255, 255, 255, 255);
            ChangeColorAlpha(gameObject.transform.Find("ImageUserCharacterContainer/ImageUserCharacterEyes").GetComponent<Image>(), 255, 255, 255, 255);
            ChangeColorAlpha(gameObject.transform.Find("ImageUserCharacterContainer/ImageUserCharacterNose").GetComponent<Image>(), 255, 255, 255, 255);
            ChangeColorAlpha(gameObject.transform.Find("ImageUserCharacterContainer/ImageUserCharacterMouth").GetComponent<Image>(), 255, 255, 255, 255);
            ChangeColorAlpha(gameObject.transform.Find("Flag").GetComponent<Image>(), 255, 255, 255, 255);

            gameObject.transform.Find("ImageUserCharacterContainer/ImageUserCharacterFace").GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().FaceChoices[conqueror.UserCharacter.Face];
            gameObject.transform.Find("ImageUserCharacterContainer/ImageUserCharacterHair").GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().HairChoices[conqueror.UserCharacter.Hair];
            gameObject.transform.Find("ImageUserCharacterContainer/ImageUserCharacterEyes").GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().EyesChoices[conqueror.UserCharacter.Eyes];
            gameObject.transform.Find("ImageUserCharacterContainer/ImageUserCharacterNose").GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().NoseChoices[conqueror.UserCharacter.Nose];
            gameObject.transform.Find("ImageUserCharacterContainer/ImageUserCharacterMouth").GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().MouthChoices[conqueror.UserCharacter.Mouth];
            gameObject.transform.Find("Flag").GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().TeamFlag[conqueror.TeamId - 1];

            //yung mga parts pa ng character        

        }
        else
        {
            ChangeColorAlpha(gameObject.transform.Find("ImageUserCharacterContainer/ImageUserCharacterFace").GetComponent<Image>(), 255, 255, 255, 0);
            ChangeColorAlpha(gameObject.transform.Find("ImageUserCharacterContainer/ImageUserCharacterHair").GetComponent<Image>(), 255, 255, 255, 0);
            ChangeColorAlpha(gameObject.transform.Find("ImageUserCharacterContainer/ImageUserCharacterEyes").GetComponent<Image>(), 255, 255, 255, 0);
            ChangeColorAlpha(gameObject.transform.Find("ImageUserCharacterContainer/ImageUserCharacterNose").GetComponent<Image>(), 255, 255, 255, 0);
            ChangeColorAlpha(gameObject.transform.Find("ImageUserCharacterContainer/ImageUserCharacterMouth").GetComponent<Image>(), 255, 255, 255, 0);
            ChangeColorAlpha(gameObject.transform.Find("Flag").GetComponent<Image>(), 255, 255, 255, 0);
        }


   


    }

    public void clicked()
    {
        confirm.SetActive(true);
    
        switch(gameObject.tag)
        {
            case "Metals": resettimerMiniGameDragDrop.GetComponent<ResetTimerSetter>().ResetTimer(); DataPersistor.persist.bagCompounds.Clear(); break;
            case "NonMetals": resettimerMinigameFreeThrow.GetComponent<ResetTimerSetter>().ResetTimer(); break;
            //case "Metalloids": resettimerMiniGameDragDrop.GetComponent<ResetTimerSetter>().ResetTimer(); break;
            case "Unknown": resettimerMinigameTapTapCompound.GetComponent<ResetTimerSetter>().ResetTimer(); break;
        }
       // resettimer.GetComponent<ResetTimerSetter>().ResetTimer();
        DataPersistor.persist.currentSectorNumber = sectorNumber;
        DataPersistor.persist.sectorCity = gameObject.tag;

        Debug.Log(DataPersistor.persist.sectorCity);

        if (sectorInfo[0] != "")
        {
            conquerorsProfile(conqueror.TeamId, conqueror.UserCharacter.Face, conqueror.UserCharacter.Hair, conqueror.UserCharacter.Eyes, conqueror.UserCharacter.Nose, conqueror.UserCharacter.Mouth, conqueror.UserName, sectorInfo[1].ToString());
            //GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/ImageUserCharacterContainer/ImageUserFlag").GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().TeamFlag[conqueror.TeamId];
            //GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/ImageUserCharacterContainer/ImageUserCharacterFace").GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().FaceChoices[conqueror.UserCharacter.Face];
            //GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/ImageUserCharacterContainer/ImageUserCharacterHair").GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().HairChoices[conqueror.UserCharacter.Hair];
            //GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/ImageUserCharacterContainer/ImageUserCharacterEyes").GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().EyesChoices[conqueror.UserCharacter.Eyes];
            //GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/ImageUserCharacterContainer/ImageUserCharacterNose").GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().NoseChoices[conqueror.UserCharacter.Nose];
            //GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/ImageUserCharacterContainer/ImageUserCharacterMouth").GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().MouthChoices[conqueror.UserCharacter.Mouth];
            //GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/TextUserName").GetComponent<Text>().text = conqueror.UserName;
            //GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/TextScore").GetComponent<Text>().text = sectorInfo[1].ToString();


        }
        else
        {
            conquerorsProfile(0, 0, 0, 0, 0, 0, "???", "00");
        }



        //Debug.Log("ID: "+sectorInfo[0]+" SCORE: "+sectorInfo[1]);


        gameObject.GetComponentInParent<DisablerEnabler>().btnDisabler(gameObject.GetComponent<Button>());
    }

    private void conquerorsProfile(int factionId, int face, int hair, int eyes, int nose, int mouth, string username, string score)
    {
        //GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/ImageUserCharacterContainer/ImageUserFlag").GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().TeamFlag[factionId];
        //GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/ImageUserCharacterContainer/ImageUserCharacterFace").GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().FaceChoices[face];
        //GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/ImageUserCharacterContainer/ImageUserCharacterHair").GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().HairChoices[hair];
        //GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/ImageUserCharacterContainer/ImageUserCharacterEyes").GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().EyesChoices[eyes];
        //GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/ImageUserCharacterContainer/ImageUserCharacterNose").GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().NoseChoices[nose];
        //GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/ImageUserCharacterContainer/ImageUserCharacterMouth").GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().MouthChoices[mouth];
        GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/TextUserName").GetComponent<Text>().text = username;
        GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/TextScore").GetComponent<Text>().text = score;

        if(username.Equals("???"))
        {
            ChangeColorAlpha(GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/ImageUserCharacterContainer/ImageUserFlag").GetComponent<Image>(), 255, 255, 255, 0);
            ChangeColorAlpha(GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/ImageUserCharacterContainer/ImageUserCharacterFace").GetComponent<Image>(), 255, 255, 255, 0);
            ChangeColorAlpha(GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/ImageUserCharacterContainer/ImageUserCharacterHair").GetComponent<Image>(), 255, 255, 255, 0);
            ChangeColorAlpha(GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/ImageUserCharacterContainer/ImageUserCharacterEyes").GetComponent<Image>(), 255, 255, 255, 0);
            ChangeColorAlpha(GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/ImageUserCharacterContainer/ImageUserCharacterNose").GetComponent<Image>(), 255, 255, 255, 0);
            ChangeColorAlpha(GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/ImageUserCharacterContainer/ImageUserCharacterMouth").GetComponent<Image>(), 255, 255, 255, 0);
        }
        else
        {
            ChangeColorAlpha(GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/ImageUserCharacterContainer/ImageUserFlag").GetComponent<Image>(), 255, 255, 255, 255);
            ChangeColorAlpha(GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/ImageUserCharacterContainer/ImageUserCharacterFace").GetComponent<Image>(), 255, 255, 255, 255);
            ChangeColorAlpha(GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/ImageUserCharacterContainer/ImageUserCharacterHair").GetComponent<Image>(), 255, 255, 255, 255);
            ChangeColorAlpha(GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/ImageUserCharacterContainer/ImageUserCharacterEyes").GetComponent<Image>(), 255, 255, 255, 255);
            ChangeColorAlpha(GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/ImageUserCharacterContainer/ImageUserCharacterNose").GetComponent<Image>(), 255, 255, 255, 255);
            ChangeColorAlpha(GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/ImageUserCharacterContainer/ImageUserCharacterMouth").GetComponent<Image>(), 255, 255, 255, 255);
            GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/ImageUserCharacterContainer/ImageUserFlag").GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().TeamFlag[factionId];
            GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/ImageUserCharacterContainer/ImageUserCharacterFace").GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().FaceChoices[face];
            GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/ImageUserCharacterContainer/ImageUserCharacterHair").GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().HairChoices[hair];
            GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/ImageUserCharacterContainer/ImageUserCharacterEyes").GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().EyesChoices[eyes];
            GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/ImageUserCharacterContainer/ImageUserCharacterNose").GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().NoseChoices[nose];
            GameObject.Find("Dashboard/ConfirmDialog/PanelUserHolder/ImageUserCharacterContainer/ImageUserCharacterMouth").GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().MouthChoices[mouth];
        }
    }

    private void ChangeColorAlpha(Image img, int r, int g, int b, int a)
    {
        img.color = new Color(r, g, b, a);
    }
}
