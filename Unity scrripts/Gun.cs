using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour
{
    public UnityEvent OnGunShoot;
    public float FireCooldown;
    public bool Automatic;
    public AudioClip ShootSound;
    public AudioSource AudioSource;

    private float CurrentCooldown;

    // Start is called before the first frame update
    void Start()
    {
        CurrentCooldown = FireCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (Automatic)
        {
            if (Input.GetMouseButton(0) || Input.GetButton("Fire2"))
            {
                if (CurrentCooldown <= 0f)
                {
                    PlayShootSound();
                    OnGunShoot?.Invoke();
                    CurrentCooldown = FireCooldown;
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0) || Input.GetButtonDown("Fire2"))
            {
                if (CurrentCooldown <= 0f)
                {
                    PlayShootSound();
                    OnGunShoot?.Invoke();
                    CurrentCooldown = FireCooldown;
                }
            }
        }

        CurrentCooldown -= Time.deltaTime;
    }

    void PlayShootSound()
    {
        if (AudioSource != null && ShootSound != null)
        {
            AudioSource.PlayOneShot(ShootSound);
        }
    }
}
