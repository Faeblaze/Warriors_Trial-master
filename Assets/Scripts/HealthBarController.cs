using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarController : MonoBehaviour
{
    private Transform healthBg;
    private Transform healthBar;

    private Player player;
    private Enemy_Class enemy;

    private void Awake()
    {
        healthBg = transform;
        healthBar = transform.GetChild(0);

        player = (Player)Object.FindObjectOfType(typeof(Player));
        enemy = transform.parent.GetComponentInChildren<Enemy_Class>();
    }

    void Update()
    {
        healthBar.localScale = new Vector3(enemy.health, 1F, 1F);
        healthBar.localPosition = new Vector3(0F, 0F, 0F);
    }

}
