using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1 : MonoBehaviour
{
    float speed = 3f;
    Vector3 position = Vector3.zero, direction = Vector3.left, velocity = Vector3.zero;
    public float hp;
    bool dead = false;
    public Animator animator;
    [HideInInspector]
    public float x, y, width, height;
    [HideInInspector]
    public CollisionDetection temp;

    // Start is called before the first frame update
    void Start()
    {
        hp = 1f;
        position = transform.position;
        StartCoroutine(deathdelay());
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("dead", death());
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
        float width = (camera.orthographicSize * 2) * screenAspect / 2;
        if (position.x > width)
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
    bool death()
    {
        if(hp <= 0) { dead = true; }
        return dead;
    }
    IEnumerator deathdelay()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (death())
            {
                Destroy(gameObject);
            }
        }
    }
}
