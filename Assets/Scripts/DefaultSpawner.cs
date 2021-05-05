using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultSpawner : MonoBehaviour
{

    public GameObject enemyPrefab;

    public bool spawnMoster = false;
    public bool respawn = false;
    public bool spawn = true;
    public int floorLevel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnEnemies()
    {
        Instantiate(enemyPrefab, gameObject.transform.position, Quaternion.identity); //instantiate object
    }

}
