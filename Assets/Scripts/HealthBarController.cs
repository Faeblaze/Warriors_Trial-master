using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarController : MonoBehaviour {
    private Sprite healthBg;
    private Sprite healthBar;

    private Player player;

    private void Awake()
    {
        healthBg = GetComponent<Sprite>();
        healthBar = transform.GetChild(0).GetComponent<Sprite>();
    }

     void Update()
    {

    }

}
