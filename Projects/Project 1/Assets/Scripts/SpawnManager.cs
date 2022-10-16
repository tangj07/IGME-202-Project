using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    GameObject enemy;
    [SerializeField]
    GameObject enemy2;
    [SerializeField]
    GameObject rum;
    [SerializeField]
    CollisionManager manager;

    float two = 2, four = 4, rumtime= 10;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<CollisionManager>();
        for (int i = 0; i < 4; i++)
        {
            GameObject temp;
            temp = Instantiate(enemy, new Vector3(Random.Range(-7.8f, 7.8f), Random.Range(-2.5f, 4), 0), transform.rotation);
        }
        for (int i = 0; i < 3; i++)
        {
            GameObject temp;
            temp = Instantiate(enemy2, new Vector3(Random.Range(-7.21f, 7.21f), Random.Range(-2.5f, 4), 0), transform.rotation);
        }
        StartCoroutine(TimeSpawn());
        StartCoroutine(TimeSpawn2());
        StartCoroutine(TimeSpawn3());
    }

    // Update is called once per frame
    void Update()
    {
    }
    IEnumerator TimeSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(two);
            if (!manager.dead) { Spawn(); }
        }
    }
    IEnumerator TimeSpawn2()
    {
        while (true)
        {
            yield return new WaitForSeconds(four);
            if (!manager.dead) { Spawn2(); }
        }
    }
    IEnumerator TimeSpawn3()
    {
        while (true)
        {
            yield return new WaitForSeconds(rumtime);
            if (!manager.dead) { Spawn3(); }
        }
    }
    void Spawn()
    {
        GameObject temp;
        temp = Instantiate(enemy, new Vector3(7.8f, Random.Range(-2.5f, 4), 0), transform.rotation);
    }
    void Spawn2()
    {
        GameObject temp;
        temp = Instantiate(enemy2, new Vector3(Random.Range(-7.8f, 7.8f), 4, 0), transform.rotation);
    }
    void Spawn3()
    {
        GameObject temp;
        temp = Instantiate(rum, new Vector3(Random.Range(-7.61f, 7.61f), Random.Range(-4.48f, 4.48f), 0), transform.rotation);
    }
}
