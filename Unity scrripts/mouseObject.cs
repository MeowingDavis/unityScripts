using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseObject : MonoBehaviour
{
    Camera mainCam;
        Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
        pos = new Vector3(0f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        pos = Input.mousePosition;
        pos.z = pos.z + 10;
        transform.position = mainCam.ScreenToWorldPoint(pos);
    }
}
