using UnityEngine;

public class WalkSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    
    void Start()
    {
        audioSource.loop = true;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            audioSource.PlayOneShot(audioClip);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            audioSource.Stop();
        }
    }
}