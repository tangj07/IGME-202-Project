using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Vehicle : MonoBehaviour
{
    [SerializeField]
    float speed = 1f;

    Vector3 position = Vector3.zero;
    Vector3 direction = Vector3.zero;
    Vector3 velocity = Vector3.zero;

    private float delay = 0.3f, bullettime=-1;
    public GameObject bullet;
    bool fire;
    string lastkey;
    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Make sure direction is normalized
        direction.Normalize();
        //turn the vehicle by some angle
        //Calculate velocity
        velocity = direction * speed * Time.deltaTime;
        // Add velocity to postition
        position += velocity;

        if (direction != Vector3.zero)
        {
            //Draw the vehicle at that position
            transform.position = position;
        }
        //warping stuff
        Camera camera = Camera.main;
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float cameraHeight = camera.orthographicSize * 2;
        Bounds bounds = new Bounds(
            camera.transform.position,
            new Vector3(cameraHeight * screenAspect, cameraHeight, 0)); 
        float height = cameraHeight*0.5f;
        float width = cameraHeight * screenAspect/2;
        if (position.y > height)
        {
            position.y = -1*height;
        }
        else if (position.y < -1 * height)
        {
            position.y = height;
        }
        else if (position.x > width)
        {
            position.x = -1 * width;
        }
        else if (position.x < -1 * width)
        {
            position.x = width;
        }
        if (fire && bullettime>0)
        {
            bullettime -= Time.deltaTime;
        }
        else if (bullettime <= 0)
        {
            fire = false;
        }
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
        }
    }
    public void Pewpew()
    {
        if(bullettime <= 0)
        {
            Instantiate(bullet, new Vector3(position.x, position.y, 0), transform.rotation);
            bullettime = delay;
        }
        fire = true;
    }
}
