using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public GameObject playerBody;
    public float xSensitivity = 15;
    public float ySensitivity = 15;
    public float minimumX = -360;
    public float maximumX = 360;
    public float minimumY = -90;
    public float maximumY = 90;
    float rotationX = 0;
    float rotationY = 0;

    Quaternion originalRotation; //stores the original rotation of the camera before updating rotation
    Quaternion originalBodyRotation;
    Vector3 cameraOffset;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb)
        {
            rb.freezeRotation = true;
        }
        originalRotation = transform.localRotation;
        cameraOffset = transform.position - playerBody.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        GetCameraInput();
        UpdateCameraPosition();
    }

    void GetCameraInput()
    {
        rotationX += Input.GetAxis("Mouse X") * xSensitivity;
        rotationY += Input.GetAxis("Mouse Y") * ySensitivity;

        //keeps the camera from going out of bounds
        rotationY    = ClampAngle(rotationY, minimumY, maximumY);
        //rotAverageX = ClampAngle(rotAverageX, minimumX, maximumX);

        //Angle Axis: "Creates a rotation which rotates angle degrees around axis."
        Quaternion yQuaternion = Quaternion.AngleAxis(rotationY, Vector3.left);
        Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);

        GetComponent<Camera>().transform.localRotation = originalRotation * xQuaternion * yQuaternion;
        originalBodyRotation.eulerAngles = new Vector3(playerBody.transform.rotation.x, transform.rotation.eulerAngles.y, playerBody.transform.rotation.z);
        playerBody.transform.rotation = originalBodyRotation;
    }

    void UpdateCameraPosition()
    {
        transform.position = playerBody.transform.position + cameraOffset;
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        angle = angle % 360.0f; //makes sure angle never goes beyond 360; 'n' % 'm' results in the remainder of n/m; ex:10%6 = 4
        if ((angle >= -360.0f) && (angle <= 360.0f))
        {
            if (angle < -360.0f)
            {
                Debug.Log("WHY");
                angle += 360.0f;
            }
            if (angle > 360.0f)
            {
                Debug.Log("WHY");
                angle -= 360.0f;
            }
        }

        return Mathf.Clamp(angle, min, max);
    }
}
