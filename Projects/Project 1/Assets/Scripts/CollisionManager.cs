using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    public List<CollisionDetection> collidableObjects = new List<CollisionDetection>();
    public CollisionDetection player;
    //what collision method is being used
    public bool isCurrentlyColliding = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //reset collision
        foreach (CollisionDetection collision in collidableObjects)
        {
            isCurrentlyColliding = AABBCollision(player, collision);
            ColorSprite(player, collision);
            if (isCurrentlyColliding) { break; }
        }
    }
    //methods for collision
    private bool AABBCollision(CollisionDetection objecta, CollisionDetection objectb)
    {
        if (objecta.x < objectb.x + objectb.width &&
            objecta.x + objecta.width > objectb.x &&
            objecta.y < objectb.y + objectb.height &&
            objecta.y + objecta.height > objectb.y) { return true; }
        else { return false; }
    }
    void ColorSprite(CollisionDetection objecta, CollisionDetection objectb)
    {
        if (isCurrentlyColliding)
        {
            var colora = objecta.GetComponent<Renderer>();
            colora.material.SetColor("_Color",Color.red); 
            var colorb = objectb.GetComponent<Renderer>();
            colorb.material.SetColor("_Color", Color.red);
        }
        else
        {
            var colora = objecta.GetComponent<Renderer>();
            colora.material.SetColor("_Color", Color.white);
            var colorb = objectb.GetComponent<Renderer>();
            colorb.material.SetColor("_Color", Color.white);
        }
    }
}
