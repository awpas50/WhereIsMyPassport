using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject[] carList;
    public int policeCarCount;
    public int ambulanceCount;

    public GameObject[] spawnLocations;

    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(SpawnCars());
    }

    private void Update()
    {
        policeCarCount = GameObject.FindGameObjectsWithTag("PoliceCar").Length;
        ambulanceCount = GameObject.FindGameObjectsWithTag("Ambulance").Length;
    }

    IEnumerator SpawnCars()
    {
        while(true)
        {
            int seed = Random.Range(0, spawnLocations.Length);
            int seed2 = Random.Range(0, spawnLocations.Length);
            yield return new WaitForSeconds(1f / (2 - player.GetComponent<PlayerCar>().screenPos.x));
            
            for(int i = 0; i < spawnLocations.Length; i++)
            {
                GameObject carObject = Instantiate(carList[Random.Range(0, carList.Length)], spawnLocations[i].transform.position, Quaternion.identity);
                if(carObject.tag == "PoliceCar" && policeCarCount >= 1)
                {
                    Destroy(carObject);
                }
                if(carObject.tag == "Ambulance" && ambulanceCount >= 1)
                {
                    Destroy(carObject);
                }
                if (i == seed || i == seed2)
                {
                    Destroy(carObject);
                }
                yield return new WaitForSeconds(0.05f / (2 - player.GetComponent<PlayerCar>().screenPos.x));
                
            }
        }
    }

    
}
