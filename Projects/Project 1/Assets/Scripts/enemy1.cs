using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1 : MonoBehaviour
{
    float speed = 3f;
    Vector3 position = Vector3.zero, direction = Vector3.left, velocity = Vector3.zero;

    public float x, y, width, height;
    public CollisionDetection temp;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        direction.Normalize();
        velocity = direction * speed * Time.deltaTime;
        position += velocity;

        if (direction != Vector3.zero)
        {
            transform.position = position;
        }
        //warping stuff
        Camera camera = Camera.main;
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float cameraHeight = camera.orthographicSize * 2;
        Bounds bounds = new Bounds(
            camera.transform.position,
            new Vector3(cameraHeight * screenAspect, cameraHeight, 0));
        float height = cameraHeight * 0.5f;
        float width = cameraHeight * screenAspect / 2;

        if (position.y > height)
        {
            position.y = -1 * height;
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

        temp = gameObject.GetComponent(typeof(CollisionDetection)) as CollisionDetection;
        x = temp.x;
        y = temp.y;
        width = temp.width;
        height = temp.height;
    }
}
