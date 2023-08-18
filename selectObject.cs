using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectObject : MonoBehaviour
{
    public GameObject[] objectList;
    public GameObject currentObject;

    private int index;

    void OnMouseDown()
    {
        currentObject.SetActive(false);

        currentObject = objectList[index];

        currentObject.SetActive(true);

        index++;

    }

    void Update()
    {
        if (index >= objectList.Length)
        {
            index = 0;
        }
    }
}