using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateBonsai : MonoBehaviour
{
    public GameObject sphere;

    public int minX;
    public int maxX;
    public int minY;
    public int maxY;
    public int minZ;
    public int maxZ;

    public List<Vector3> sphereList = new List<Vector3>();

    public Transform trailObject;
   


    void Start()
    {
        int randomNumber = Random.Range(3, 5);

        for (int i = 0; i < randomNumber; i++)
        {
            GameObject spawnedSphere;

            int xPos = Random.Range(minX, maxX);
            int yPos = Random.Range(minY, maxY);
            int zPos = Random.Range(minZ, maxZ);

            Vector3 randomPostion = new Vector3(xPos, yPos, zPos);

            spawnedSphere = Instantiate(sphere, randomPostion, Quaternion.identity);

            sphereList.Add(spawnedSphere.transform.position);
        }
        
    }

}
