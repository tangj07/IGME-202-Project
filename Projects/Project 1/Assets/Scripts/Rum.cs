using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rum : MonoBehaviour
{
    [HideInInspector]
    public float x, y, width, height;
    [HideInInspector]
    public CollisionDetection temp;
    public bool hit = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        temp = gameObject.GetComponent(typeof(CollisionDetection)) as CollisionDetection;
        x = temp.x;
        y = temp.y;
        width = temp.width;
        height = temp.height;
        if(hit)
        {
            Destroy(gameObject);
        }
    }
}
