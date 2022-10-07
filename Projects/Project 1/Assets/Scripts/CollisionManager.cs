using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    //everything manager

    //public List<CollisionDetection> collidableObjects = new List<CollisionDetection>();
    public enemy1[] _enemy1;
    public Shooting[] bullets;
    public CollisionDetection player;
    //what collision method is being used
    public bool isCurrentlyColliding = false, bullethit = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        bullets = GameObject.FindObjectsOfType<Shooting>();
        _enemy1 = GameObject.FindObjectsOfType<enemy1>();
        //reset collision
        foreach (enemy1 collision in _enemy1)
        {
            isCurrentlyColliding = CircleCollision(player, collision);
            ColorSprite(player, collision);
            if (isCurrentlyColliding) { break; }
        }
        foreach (enemy1 collision in _enemy1)
        {
            foreach (Shooting temp in bullets)
            {
                bullethit = CircleCollision2(temp, collision);
                hit(temp, collision);
                if (bullethit) { break; }
            }
        }
    }
    //methods for collision
    //private bool AABBCollision(CollisionDetection objecta, enemy1 objectb)
    //{
    //    if (objecta.x < objectb.x + objectb.width &&
    //        objecta.x + objecta.width > objectb.x &&
    //        objecta.y < objectb.y + objectb.height &&
    //        objecta.y + objecta.height > objectb.y) { return true; }
    //    else { return false; }
    //}
    //private bool AABBCollision2(Shooting objecta, enemy1 objectb)
    //{
    //    if (objecta.x < objectb.x + objectb.width &&
    //        objecta.x + objecta.width > objectb.x &&
    //        objecta.y < objectb.y + objectb.height &&
    //        objecta.y + objecta.height > objectb.y) { return true; }
    //    else { return false; }
    //}
    private bool CircleCollision(CollisionDetection objecta, enemy1 objectb)
    {
        SpriteRenderer spritea = objecta.GetComponent<SpriteRenderer>();
        SpriteRenderer spriteb = objectb.GetComponent<SpriteRenderer>();

        float distance = Mathf.Pow(spritea.bounds.center.x - spriteb.bounds.center.x, 2)
            + Mathf.Pow(spritea.bounds.center.y - spriteb.bounds.center.y, 2);
        if (distance <= ((spritea.bounds.max.x - spritea.bounds.center.x) +
            (spriteb.bounds.max.x - spriteb.bounds.center.x)) *
            ((spritea.bounds.max.x - spritea.bounds.center.x) +
            (spriteb.bounds.max.x - spriteb.bounds.center.x)))
        {
            return true;
        }
        else { return false; }
    }
    private bool CircleCollision2(Shooting objecta, enemy1 objectb)
    {
        SpriteRenderer spritea = objecta.GetComponent<SpriteRenderer>();
        SpriteRenderer spriteb = objectb.GetComponent<SpriteRenderer>();

        float distance = Mathf.Pow(spritea.bounds.center.x - spriteb.bounds.center.x, 2)
            + Mathf.Pow(spritea.bounds.center.y - spriteb.bounds.center.y, 2);
        if (distance <= ((spritea.bounds.max.x - spritea.bounds.center.x) +
            (spriteb.bounds.max.x - spriteb.bounds.center.x)) *
            ((spritea.bounds.max.x - spritea.bounds.center.x) +
            (spriteb.bounds.max.x - spriteb.bounds.center.x)))
        {
            return true;
        }
        else { return false; }
    }
    void ColorSprite(CollisionDetection objecta, enemy1 objectb)
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
    void hit(Shooting objecta, enemy1 objectb)
    {
        if (bullethit)
        {
            var colora = objecta.GetComponent<Renderer>();
            colora.material.SetColor("_Color", Color.red);
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
