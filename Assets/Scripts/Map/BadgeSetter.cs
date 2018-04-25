using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using UnityEngine.UI;

public class BadgeSetter : MonoBehaviour {
    public GameObject BadgeManager;
    public GameObject[] Achievements;
    //arrangement points, sectors, helpsmade

    private Sprite[] medals;

    public void Start()
    {
        medals = Resources.LoadAll<Sprite>("Badges/Medals");
        //Achievements[0].transform.GetChild(3).gameObject.SetActive(true);
        StartCoroutine(waitRetrieve());
    }
    private IEnumerator waitRetrieve()
    {
        if (!DataPersistor.persist.doneLoadingAllUsers)
            yield return new WaitForSeconds(0.1f);
        if (!BadgeManager.GetComponent<BadgeManager>().doneRetrieveUserBadge)
            yield return new WaitForSeconds(0.1f);

        for (int i = 0; i < DataPersistor.persist.user.Badges.Count; i++)
        {
            for (int j = 0; j < ListOfBadges.BadgesList.Count; j++)
            {
                if (DataPersistor.persist.user.Badges[i].Equals(ListOfBadges.BadgesList[j]))
                {
                    //PAG MAY EMPTY IMAGE NA NG BADGE CHANGE IMAGE
                    if (j == 0 || j == 3 || j == 6)
                    {
                        Achievements[j].transform.GetChild(1).gameObject.GetComponent<Image>().overrideSprite = medals[1];
                    }
                    else if (j == 1 || j == 4 || j == 7)
                    {
                        Achievements[j].transform.GetChild(1).gameObject.GetComponent<Image>().overrideSprite = medals[2];
                    }
                    else if (j == 2 || j ==5 || j == 8)
                    {
                        Achievements[j].transform.GetChild(1).gameObject.GetComponent<Image>().overrideSprite = medals[3];
                    }
                    Achievements[j].transform.GetChild(3).gameObject.SetActive(true);
                }
            }
        }
    }
}
