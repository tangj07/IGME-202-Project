using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    //public bool isCurrentlyColliding = false;

    public float x, y, width, height;

    //[HideInInspector]
    //public List<CollisionDetection> collisions = new List<CollisionDetection>();

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        x = gameObject.transform.position.x;
        y = gameObject.transform.position.y;
        width = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
        height = gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
    }

    //public void RegisterCollision(CollisionDetection other)
    //{
    //    isCurrentlyColliding = true;
    //    collisions.Add(other);
    //}

    //public void ResetCollision()
    //{
    //    isCurrentlyColliding = false;
    //    collisions.Clear();
    //}

    //public void ColorSprite()
    //{
    //    //if currently colliding turn red
    //    var render = gameObject.GetComponent<Renderer>();
    //    render.material.SetColor("_Color",Color.red);
    //}

    //public bool AABBCollision(CollisionDetection otherCollider)
    //{
    //    return false;
    //}
    //bool CircleCollision(GameObject, GameObject)
    //{

    //}
}
