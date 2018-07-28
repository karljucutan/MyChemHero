using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Assets.Scripts;
using System.Linq;
using UnityEngine.SceneManagement;

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
        Debug.Log(SceneManager.GetActiveScene().name);
        if (SceneManager.GetActiveScene().name.Equals("SegregationVer1"))
        {
            var elemento = ListElementGroup.TOXICNONTOXIC.Where(x => x.city.Equals(DataPersistor.persist.sectorCity)).SingleOrDefault();
            var eles = elemento.elements.Take(3);
            //foreach (Element ele in elemento.elements)
            //{
            //    elementos.Add(ele);
            //}
            for (int x = 0; x <= 3; x++)
            {
                elementos.Add(Randomizer(elemento.elements));
            }

            
        }
        else if (SceneManager.GetActiveScene().name.Equals("SegregationVer2"))
        {
            var elemento = ListElementGroup.METALS.Where(x => x.city.Equals(DataPersistor.persist.sectorCity)).SingleOrDefault();
            //foreach (Element ele in elemento.elements)
            //{
            //    elementos.Add(ele);
            //}
            for (int x = 0; x <= 3; x++)
            {
                elementos.Add(Randomizer(elemento.elements));
            }
        }
        else if (SceneManager.GetActiveScene().name.Equals("SegregationVer3"))
        {
            var elemento = ListElementGroup.SOLIDLIQUIDGAS.Where(x => x.city.Equals(DataPersistor.persist.sectorCity)).SingleOrDefault();
            //foreach (Element ele in elemento.elements)
            //{
            //    elementos.Add(ele);
            //}
            for (int x = 0; x <= 3; x++)
            {
                elementos.Add(Randomizer(elemento.elements));
            }
        }
        var asd = elementos;
        // var elemento = ListElementGroup.SOLIDLIQUIDGAS.Where(x => x.cityNum == 5).SingleOrDefault(); //change 5 depends sa citynum nung icoconquer


        collider = GetComponent<BoxCollider>();
        x1 = transform.position.x - collider.bounds.size.x / 2f;
        x2 = transform.position.x + collider.bounds.size.x / 2f;
    }
    private Element Randomizer(List<Element> elements)
    {
        var randomnum = Random.Range(0, elements.Count);
        return elements[randomnum];
    }
    public void queueElement()
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
        AudioManager.instance.StopAll();//stops music playing from previous scene

        Scene scene = SceneManager.GetActiveScene();
        switch (scene.name) //plays BGM based on version randomized
        {
            case "SegregationVer1": AudioManager.instance.Play("Segregation1"); break;
            case "SegregationVer2": AudioManager.instance.Play("Segregation2"); break;
            case "SegregationVer3": AudioManager.instance.Play("Segregation3"); break;
        }
        
        queueElement();
	}
	

}
