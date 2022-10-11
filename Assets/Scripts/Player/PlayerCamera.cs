using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public int vSensitivity;


    // Update is called once per frame
    void Update()
    {
        VerticalRotation();
    }

    private void VerticalRotation() {
        if (transform.position.y - transform.parent.position.y >= 1.5 && Input.GetAxis("Mouse Y") <= 0) return;
        if (transform.position.y - transform.parent.position.y <= -1 && Input.GetAxis("Mouse Y") >= 0) return;
        transform.RotateAround(transform.parent.position, Vector3.Cross(transform.parent.forward, Vector3.up), Input.GetAxis("Mouse Y") * vSensitivity);
    }
}
