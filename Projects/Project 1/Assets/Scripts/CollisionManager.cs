using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionManager : MonoBehaviour
{
    //everything manager
    public float points = 0, hp;
    public enemy1[] _enemy1;
    public enemy2[] _enemy2;
    public Shooting[] bullets;
    public Rum[] _rum;
    public CollisionDetection player;
    public bool isCurrentlyColliding1 = false, isCurrentlyColliding2 = false, bullethit = false, dead;
    [SerializeField] 
    Text gameover;
    [SerializeField]
    Text score;

    // Start is called before the first frame update
    void Start()
    {
        hp = 2f;
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        bullets = GameObject.FindObjectsOfType<Shooting>();
        _enemy1 = GameObject.FindObjectsOfType<enemy1>();
        _enemy2 = GameObject.FindObjectsOfType<enemy2>();
        _rum = GameObject.FindObjectsOfType<Rum>();
        //reset collision
        foreach (enemy1 collision in _enemy1)
        {
            isCurrentlyColliding1 = CircleCollision(player, collision);
            ColorSprite(player);
            if (isCurrentlyColliding1) { hp -= Time.deltaTime; break; }
        }
        foreach (enemy2 collision in _enemy2)
        {
            isCurrentlyColliding2 = CircleCollisione2(player, collision);
            ColorSprite(player);
            if (isCurrentlyColliding2) { hp -= Time.deltaTime; break; }
        }
        foreach (enemy1 collision in _enemy1)
        {
            foreach (Shooting temp in bullets)
            {
                bullethit = CircleCollision2(temp, collision);
                hit(collision);
                if (bullethit) { 
                    collision.hp -= 1;
                    if (!dead)
                    {
                        points += 1;
                    }
                    break; }
            }
        }
        foreach (enemy2 collision in _enemy2)
        {
            foreach (Shooting temp in bullets)
            {
                bullethit = CircleCollisions2(temp, collision);
                hit(collision);
                if (bullethit)
                {
                    collision.hp -= 1;
                    if (!dead)
                    {
                        points += 1;
                    }
                    break;
                }
            }
        }
        foreach (Rum collision in _rum)
        {
            isCurrentlyColliding2 = RumCollision(player, collision);
            if (isCurrentlyColliding2) { collision.hit = true; hp += 1; break; }
        }
        if (hp > 2)
        {
            hp = 2;
        }
        if (hp <= 0) { 
            dead = true; 
            Gameover();
            score.text = "" + points;
        }
    }
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
    private bool RumCollision(CollisionDetection objecta, Rum objectb)
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
    public void Gameover()
    {
        gameover.gameObject.SetActive(true);
    }
}
