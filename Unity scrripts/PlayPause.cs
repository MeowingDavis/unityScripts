using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayPause : MonoBehaviour
{
    private VideoPlayer vid;
    private bool isPaused = false;

    void Start()
    {
        vid = GetComponent<VideoPlayer>();

        if (vid == null)
        {
            Debug.LogError("VideoPlayer component not found!");
        }
    }

    void OnMouseDown()
    {
        if (!isPaused)
        {
            vid.Pause();
            isPaused = true;
        }
        else
        {
            vid.Play();
            isPaused = false;
        }
    }
}
