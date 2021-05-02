using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public Vector3 center;
    public Vector3 size;
    [SerializeField] GameController gameController;

    public GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        int count = gameController.level;
        SpawnEnemies();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDrawGizmosSelected(){ //draw where the objject will be
        Gizmos.color = Color.blue; //make color blue
        Gizmos.DrawCube(center, size); //create cube for things to spawn in 
    }

    public void SpawnEnemies(){
        Vector3 position = center + new Vector3(Random.Range(-size.x/2, size.x/2), 5, Random.Range(-size.z/2, size.z/2)); //make random point at where to spawn object
        Instantiate(enemyPrefab, position, Quaternion.identity); //instantiate object
    }

}
