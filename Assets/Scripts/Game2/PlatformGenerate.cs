using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerate : MonoBehaviour
{
    public GameObject[] platformPrefab; 

    void Start()
    {
        Vector3 SpawnerPosition = new Vector3();

        for (int i = 0; i < 10; i++) 
        {
            SpawnerPosition.x = Random.Range(-1.7f, 1.7f);
            SpawnerPosition.y += Random.Range(2f, 4f);

            Instantiate(platformPrefab[Random.Range(0, platformPrefab.Length)], SpawnerPosition, Quaternion.identity); 
        }
    }

}
