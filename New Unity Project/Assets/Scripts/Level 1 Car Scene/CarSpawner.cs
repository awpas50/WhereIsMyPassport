using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject[] carList;
    public GameObject[] spawnLocations;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCars());
    }

    IEnumerator SpawnCars()
    {
        while(true)
        {
            int seed = 0;
            int seed2 = 0;
            seed = Random.Range(0, spawnLocations.Length);
            seed2 = Random.Range(0, spawnLocations.Length);
            yield return new WaitForSeconds(1f);
            for(int i = 0; i < spawnLocations.Length; i++)
            {
                GameObject carObject = Instantiate(carList[Random.Range(0, carList.Length)], spawnLocations[i].transform.position, Quaternion.identity);
                yield return new WaitForSeconds(0.05f);
                if (i == seed || i == seed2)
                {
                    Destroy(carObject);
                }
            }
        }
    }
}
