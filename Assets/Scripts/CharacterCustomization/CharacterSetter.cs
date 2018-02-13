using Assets.Scripts;
using Assets.Scripts.Minigame.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class CharacterSetter : MonoBehaviour {

    public GameObject FeatureManager;
    private int face_index;
    private int hair_index;
    private int eyes_index;
    private int nose_index;
    private int mouth_index;

    private bool postteam_running = false;
    private bool postpresets_running = false;

    public void SendCharacterPreSet()
    {
        face_index = FeatureManager.GetComponent<FeatureManager>().features[0].currIndex;
        hair_index = FeatureManager.GetComponent<FeatureManager>().features[1].currIndex;
        eyes_index = FeatureManager.GetComponent<FeatureManager>().features[2].currIndex;
        nose_index = FeatureManager.GetComponent<FeatureManager>().features[3].currIndex;
        mouth_index = FeatureManager.GetComponent<FeatureManager>().features[4].currIndex;
        StartCoroutine(PostTeam());
        StartCoroutine(PostPresets());
    }

    
    IEnumerator PostTeam()
    {
        postteam_running = true;
        Debug.Log("POSTTEAM");
        //string post_url = Configuration.BASE_ADDRESS + "InsertUser.php?userid="+DataPersistor.persist.user.ID+
        
        string post_url = Configuration.BASE_ADDRESS + "InsertUser.php?playerid=" + DataPersistor.persist.id+ "&team_id=" + DataPersistor.persist.teamId;
        WWW hs_post = new WWW(post_url);
        yield return hs_post; // Wait until the download is done

        if (hs_post.error != null)
        {
            print("There was an error posting the high score: " + hs_post.error);
        }
        postteam_running = false;
    }

    IEnumerator PostPresets()
    {
        while (postteam_running)
        {
            yield return new WaitForSeconds(0.1f);
        }

        Debug.Log("POSTPRESETS");
        string post_url = Configuration.BASE_ADDRESS + "AddPlayerPreset.php?playerid=" + DataPersistor.persist.id + "&face=" + face_index + "&hair=" + hair_index + "&eyes=" + eyes_index + "&nose=" + nose_index + "&mouth=" + mouth_index;

        // Post the URL to the site and create a download object to get the result.
        WWW hs_post = new WWW(post_url);
        yield return hs_post; // Wait until the download is done

        if (hs_post.error != null)
        {
            print("There was an error posting the high score: " + hs_post.error);
        }

        SceneManager.LoadScene("MainMenu");
    }

    
}
