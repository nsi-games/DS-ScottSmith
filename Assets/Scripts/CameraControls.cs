using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{

 [SerializeField]
float mouseSensitivity;

    Transform camRig;

    [SerializeField]
    float maxHeight;
    [SerializeField]
    float minHieght;

float rotX;

    void Start()
    {
        camRig = transform.Find("Camera Rig");
        if (camRig == null)
        {
            Debug.LogError("Camera Rig not found. Did you change it's name?");
        }
    }

    void Update()
    {
        transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * mouseSensitivity);

        rotX += Input.GetAxisRaw("Mouse Y") * mouseSenitivity;
        rotX = Mathf.Clamp(rotX, minHeight, maxHeight);
        camRig.transform.localEulerAngles = Vector3.left * rotX;
    }
}