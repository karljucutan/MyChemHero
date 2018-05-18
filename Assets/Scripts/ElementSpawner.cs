using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Assets.Scripts;
using System.Linq;

public class ElementSpawner : MonoBehaviour {

	// Use this for initialization
    [SerializeField]
  
    private BoxCollider collider;
    public Image queue;
    public GameObject queuer;
    public GameObject element;
    float x1, x2;
    public List<Element> elementos=new List<Element>();
    
    private void Awake()
    {
        //magkakarooon ng if statement dito based dun sa randomized segregation game nakalagay naman sa data persistor e
        /*
         for example:
         if(random==solidliquidgas){
            var elemento = ListElementGroup.SOLIDLIQUIDGAS.Where(x => x.cityNum == UNG CITY NA SELECTED).SingleOrDefault();
         }
         ListElementGroup.SOLIDLIQUIDGAS=for solidliquidgas
         ListElementGroup.METALS=for metals
         ListElementGroup.TOXICNONTOXIC=for toxicity
         ETC.....
         */
        var elemento = ListElementGroup.SOLIDLIQUIDGAS.Where(x => x.cityNum == 5).SingleOrDefault(); //change 5 depends sa citynum nung icoconquer
        foreach (Element ele in elemento.elements)
        {
            elementos.Add(ele);
        }
        
        collider = GetComponent<BoxCollider>();
        x1 = transform.position.x - collider.bounds.size.x / 2f;
        x2 = transform.position.x + collider.bounds.size.x / 2f;
    }
    public void queueElement(float time)
    {
        var randomizedElem=elementos[Random.Range(0,elementos.Count)];
        //element = elements[Random.Range(0, elements.Length)];
        element = Resources.Load("Segregation/"+randomizedElem.name) as GameObject;
        //element = Resources.Load("carbon") as GameObject;
        element.tag = randomizedElem.tag;
        queue.sprite = element.GetComponent<SpriteRenderer>().sprite;
        
    }
    IEnumerator spawnElement(float time,GameObject element)
    {
        yield return new WaitForSecondsRealtime(time);
        
        Vector3 temp = transform.position;
        temp.x = Random.Range(x1, x2);

        Instantiate(element, temp, Quaternion.identity);
        
    }
	void Start () {
        queueElement(1);
	}
	

}
