using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    //everything manager
    public enemy1[] _enemy1;
    public enemy2[] _enemy2;
    public Shooting[] bullets;
    public CollisionDetection player;
    //what collision method is being used
    public bool isCurrentlyColliding1 = false, isCurrentlyColliding2 = false, bullethit = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        bullets = GameObject.FindObjectsOfType<Shooting>();
        _enemy1 = GameObject.FindObjectsOfType<enemy1>();
        _enemy2 = GameObject.FindObjectsOfType<enemy2>();
        //reset collision
        foreach (enemy1 collision in _enemy1)
        {
            isCurrentlyColliding1 = CircleCollision(player, collision);
            ColorSprite(player);
            if (isCurrentlyColliding1) { break; }
        }
        foreach (enemy2 collision in _enemy2)
        {
            isCurrentlyColliding2 = CircleCollisione2(player, collision);
            ColorSprite(player);
            if (isCurrentlyColliding2) { break; }
        }
        foreach (enemy1 collision in _enemy1)
        {
            foreach (Shooting temp in bullets)
            {
                bullethit = CircleCollision2(temp, collision);
                hit(collision);
                if (bullethit) { collision.hp -= 1;  break; }
            }
        }
        foreach (enemy2 collision in _enemy2)
        {
            foreach (Shooting temp in bullets)
            {
                bullethit = CircleCollisions2(temp, collision);
                hit(collision);
                if (bullethit) { collision.hp -= 1; break; }
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
    private bool CircleCollisione2(CollisionDetection objecta, enemy2 objectb)
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
    private bool CircleCollisions2(Shooting objecta, enemy2 objectb)
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
    void ColorSprite(CollisionDetection objecta)
    {
        if (isCurrentlyColliding1 || isCurrentlyColliding2)
        {
            var colora = objecta.GetComponent<Renderer>();
            colora.material.SetColor("_Color",Color.red); 
        }
        else
        {
            var colora = objecta.GetComponent<Renderer>();
            colora.material.SetColor("_Color", Color.white);
        }
    }
    void hit(enemy1 objectb)
    {
        if (bullethit)
        {
            var colorb = objectb.GetComponent<Renderer>();
            colorb.material.SetColor("_Color", Color.red);
        }
        else
        {
            var colorb = objectb.GetComponent<Renderer>();
            colorb.material.SetColor("_Color", Color.white);
        }
    }
    void hit(enemy2 objectb)
    {
        if (bullethit)
        {
            var colorb = objectb.GetComponent<Renderer>();
            colorb.material.SetColor("_Color", Color.red);
        }
        else
        {
            var colorb = objectb.GetComponent<Renderer>();
            colorb.material.SetColor("_Color", Color.white);
        }
    }
}
