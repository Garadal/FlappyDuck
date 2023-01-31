using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    double nextPrint = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        double timeAsDouble = Time.timeAsDouble;
        if (timeAsDouble > nextPrint) {
            Debug.Log("Time.timeAsDouble: " + timeAsDouble);
            nextPrint++;
        }
    }
}
