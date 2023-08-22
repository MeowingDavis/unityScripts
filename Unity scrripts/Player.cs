using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    CharacterController cc;
    AudioSource footstepSound;

    public float speed = 10f;
    public float jumpForce = 10f;
    float ySpeed = 0f;
    float gravity = -50f;
    bool isGrounded = false;
    public Transform fpsCamera;
    public float mouseSensitivity = 10f;
    float pitch = 0f;

    public float swayAmount = 0.05f;
    public float swaySpeed = 1f;
    public float swayRotationAmount = 0.25f;
    public float swayRotationSpeed = 1f;

    public float fovModulationAmount = 5f; // Field of view modulation amount
    public float fovModulationSpeed = 1f; // Field of view modulation speed
    private float timeOffset;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cc = GetComponent<CharacterController>();
        ySpeed = gravity * Time.deltaTime * 10f;

        footstepSound = GetComponent<AudioSource>();
        footstepSound.loop = true;

        if (footstepSound.clip == null)
        {
            Debug.LogError("Footstep AudioClip is missing on the AudioSource component!");
        }

        timeOffset = Random.Range(0f, 100f);
    }

    void Update()
    {
        float xInput = Input.GetAxis("Horizontal") * speed;
        float zInput = Input.GetAxis("Vertical") * speed;

        Vector3 move = new Vector3(xInput, 0, zInput);
        move = Vector3.ClampMagnitude(move, speed);
        move = transform.TransformVector(move);

        isGrounded = cc.isGrounded;

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            ySpeed = jumpForce;
        }

        ySpeed += gravity * Time.deltaTime;

        cc.Move((move + new Vector3(0, ySpeed, 0)) * Time.deltaTime);

        float xMouse = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, xMouse, 0);

        float swayX = Mathf.PerlinNoise(timeOffset + Time.time * swaySpeed, 0) * 2 - 1;
        float swayY = Mathf.PerlinNoise(0, timeOffset + Time.time * swaySpeed) * 2 - 1;

        pitch -= (Input.GetAxis("Mouse Y") * mouseSensitivity + swayY * swayAmount);
        pitch = Mathf.Clamp(pitch, -55f, 55f);

        float swayRotation = Mathf.Sin(Time.time * swayRotationSpeed) * swayRotationAmount;

        Quaternion camRotation = Quaternion.Euler(pitch + swayRotation, 0, 0) * Quaternion.Euler(-swayX * swayAmount, 0, 0);
        fpsCamera.localRotation = camRotation;

        // Calculate field of view modulation
        float fovModulation = Mathf.Sin(Time.time * fovModulationSpeed) * fovModulationAmount;
        Camera.main.fieldOfView = 60f + fovModulation;

        bool isMoving = xInput != 0f || zInput != 0f;
        if (isGrounded && isMoving)
        {
            if (!footstepSound.isPlaying)
            {
                footstepSound.Play();
            }
        }
        else
        {
            footstepSound.Stop();
        }
    }
}
