using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private double nextPrint = 0;
    //private List
    public Spawner obstacleSpawner;
    public PlayerSpawner playerSpawner;
    
    // Start is called before the first frame update
    void Start()
    {
        //obstacleSpawner.subscribeToSpawnAction(this);
        playerSpawner.subscribeToSpawnAction(this);
    }

    // called on every obstacle GameObject spawn
    void OnObstacleSpawnAction() { 
    }

    //called when new player character is spawned
    void OnPlayerSpawnAction() {
        //called when new player character is spawned
        //allow 

    }
    void OnPlayerDeathAction() {
        //turn off player visibility
        //turn off collision
        //resset position
    }

    // Update is called once per frame
    void Update()
    {
        double timeAsDouble = Time.timeAsDouble;
        if (timeAsDouble > nextPrint) {
            //Debug.Log("Time.timeAsDouble: " + timeAsDouble);
            nextPrint++;
        }
    }
}
