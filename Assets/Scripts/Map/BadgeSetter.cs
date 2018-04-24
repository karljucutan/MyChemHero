using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using UnityEngine.UI;

public class BadgeSetter : MonoBehaviour {
    public GameObject BadgeManager;
    public GameObject[] Achievements;
    //arrangement points, sectors, helpsmade

    public void Start()
    {
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
                    Achievements[j].transform.GetChild(3).gameObject.SetActive(true);
                }
            }
        }
    }
}
