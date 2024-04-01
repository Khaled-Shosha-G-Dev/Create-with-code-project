using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject [] objectPrefabs;
    private float xRange = 7.0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObjects", 2, 1f);
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void SpawnObjects()
    { 
        int Index = Random.Range(0, objectPrefabs.Length);
        float spawnXRange= Random.Range(-xRange, xRange);
        Vector3 spawnPos = new (spawnXRange, 1, 8);
        Instantiate(objectPrefabs[Index], spawnPos, objectPrefabs[Index].transform.rotation);
    }
}
