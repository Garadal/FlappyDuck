using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float time = 0f;
    public float spawnTimer = 1.5f;
    public float height;
    public GameObject obstacle;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (time > spawnTimer) {
            GameObject newObstacle = Instantiate(obstacle);
            Vector3 heightOffset = new Vector3(0, Random.Range(-height, height), 0);
            newObstacle.transform.position = transform.position + heightOffset;
            Destroy(newObstacle, 10);
            time = 0f;
        }
        time += Time.deltaTime;    
    }
}
