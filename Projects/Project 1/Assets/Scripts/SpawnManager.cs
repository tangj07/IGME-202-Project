using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject temp;
            temp = Instantiate(enemy, new Vector3(Random.Range(-7.8f, 7.8f), Random.Range(-2.5f, 4), 0), transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
