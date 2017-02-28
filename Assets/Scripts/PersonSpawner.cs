using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonSpawner : MonoBehaviour {

    public uint MaxPersons = 15;
    List<GameObject> Persons = new List<GameObject>();
    public GameObject PFPerson;
    public Vector2[] SpawnRegion = new Vector2[2];
    
	void Start () {
        StartCoroutine(SpawnerLoop());
	}
	
	IEnumerator SpawnerLoop()
    {
        while (true)
        {
            foreach(GameObject GO in Persons)
            {
                PersonController controller = GO.GetComponent<PersonController>();
                if (!controller.isAlive)
                    Persons.Remove(GO);
            }
            if(Persons.Count < MaxPersons)
            {
                Vector2 location = new Vector2(Random.Range(SpawnRegion[0].x, SpawnRegion[1].x), Random.Range(SpawnRegion[0].y, SpawnRegion[1].y));
                Persons.Add(Instantiate(PFPerson, location, Quaternion.identity));
            }
            yield return new WaitForSeconds(0.25f);
        }
    }
}
