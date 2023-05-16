using System.Collections.Generic;

using UnityEngine;



public class PlayerCameraMovment : MonoBehaviour

{

    [SerializeField] private float lookSensitivity;

    [SerializeField] private float smoothing;



    private GameObject player;

    private Vector2 smoothedVelocity;

    private Vector2 currentLookingPos;

    private void Start()

    {

        player = transform.parent.gameObject;

        Cursor.lockState = CursorLockMode.Locked;

        Cursor.visible = false;

    }



    private void Update()

    {

        RotateCamera();

    }



    private void RotateCamera()

    {

        Vector2 inputeValues = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        inputeValues = Vector2.Scale(inputeValues, new Vector2(lookSensitivity * smoothing, lookSensitivity * smoothing));





        smoothedVelocity.x = Mathf.Lerp(smoothedVelocity.x, inputeValues.x, 1f / smoothing);

        smoothedVelocity.y = Mathf.Lerp(smoothedVelocity.y, inputeValues.y, 1f / smoothing);



        currentLookingPos += smoothedVelocity;
        currentLookingPos.y = Mathf.Clamp(currentLookingPos.y, -60f, 90f);





        transform.localRotation = Quaternion.AngleAxis(-currentLookingPos.y, Vector3.right);

        player.transform.localRotation = Quaternion.AngleAxis(currentLookingPos.x, player.transform.up);



    }

}
