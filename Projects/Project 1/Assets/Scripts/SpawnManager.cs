using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    GameObject enemy;
    [SerializeField]
    GameObject enemy2;

    float two = 2, four = 4;
    // Start is called before the first frame update
    void Start()
    {
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
            Spawn();
        }
    }
    IEnumerator TimeSpawn2()
    {
        while (true)
        {
            yield return new WaitForSeconds(four);
            Spawn2();
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
}
