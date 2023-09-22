using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proceduralForest : MonoBehaviour
{
    public GameObject treePrefab;

    public int numberOfTrees;

    public int min;
    public int max;


    
    void Start()
    {
        for (var i = 0; i < numberOfTrees; i++)
        {
            Instantiate(treePrefab, new Vector3(Random.Range(min, max), 1, Random.Range(min, max)), Quaternion.identity);
        }
    }

  
}
