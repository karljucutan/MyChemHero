using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelDisablerTeamProfile : MonoBehaviour {
    public GameObject PanelTeamStats;
    public GameObject PanelTeamMembers;
    public GameObject PanelTeamAchievements;
    
    void OnEnable()
    {
        if (gameObject.name.Equals("PanelTeamStats"))
        {
            
            PanelTeamMembers.SetActive(false);
            PanelTeamAchievements.SetActive(false);
        }
        else if (gameObject.name.Equals("PanelTeamMembers"))
        {
           
            PanelTeamStats.SetActive(false);
            PanelTeamAchievements.SetActive(false);
        }
        else if (gameObject.name.Equals("PanelTeamAchivements"))
        {
            PanelTeamStats.SetActive(false);
            PanelTeamMembers.SetActive(false);
        }
 
    }
}
