using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Vehicle : MonoBehaviour
{
    [SerializeField]
    float speed = 1f;

    Vector3 vehicleposition = Vector3.zero;

    Vector3 direction = Vector3.zero;

    Vector3 velocity = Vector3.zero;

    //[SerializeField]
    //float turnamount = 0f;

    // Start is called before the first frame update
    void Start()
    {
        vehicleposition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Make sure direction is normalized
        direction.Normalize();
        //turn the vehicle by some angle
        //direction = Quaternion.EulerAngles(0, 0, turnamount * Time.deltaTime) * direction;
        //Calculate velocity
        velocity = direction * speed * Time.deltaTime;
        // Add velocity to postition
        //if (Input.anyKeyDown) { }
        vehicleposition += velocity;

        if (direction != Vector3.zero)
        {
            //Draw the vehicle at that position
            transform.position = vehicleposition;
        }
        //warping stuff
        Camera camera = Camera.main;
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float cameraHeight = camera.orthographicSize * 2;
        Bounds bounds = new Bounds(
            camera.transform.position,
            new Vector3(cameraHeight * screenAspect, cameraHeight, 0));
        //float height = 2f * cam.orthographicSize;
        //float width = height * cam.aspect;
        //float height = Screen.currentResolution.height;
        //float width = Screen.currentResolution.width;
        float height = cameraHeight*0.5f;
        float width = cameraHeight * screenAspect/2;
        //float height = 5.6f;
        //float width = 9.6f;
        if (vehicleposition.y > height)
        {
            vehicleposition.y = -1*height;
        }
        else if (vehicleposition.y < -1 * height)
        {
            vehicleposition.y = height;
        }
        else if (vehicleposition.x > width)
        {
            vehicleposition.x = -1 * width;
        }
        else if (vehicleposition.x < -1 * width)
        {
            vehicleposition.x = width;
        }
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.back, direction);
        }
    }
}
