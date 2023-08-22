using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeInteraction : MonoBehaviour
{
    private Renderer cubeRend;
    private AudioSource cubeAS;

    public AudioClip crowSound;

    // Start is called before the first frame update
    void Start()
    {
        cubeRend = GetComponent<Renderer>();
        cubeAS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void OnMouseEnter()
    {
        cubeRend.enabled = true;
        cubeAS.PlayOneShot(crowSound, 1f);
    }
    void OnMouseExit()
    {
        cubeRend.enabled = false;
    }
}
