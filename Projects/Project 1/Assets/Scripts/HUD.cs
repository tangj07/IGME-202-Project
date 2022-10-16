using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField]
    Text score;
    [SerializeField]
    Slider slider;
    CollisionManager player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<CollisionManager>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "" + player.points;
        slider.value = player.hp;
    }
}
