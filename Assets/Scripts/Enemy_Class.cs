using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Class : MonoBehaviour
{

    public string enemyName;
    [NonSerialized]
    public float health = 1F;
    public int maxHealth;
    public int powerLevel;
    public float height;
    public float weight;
    public char sex;
    public float mySpeed;

    public float damageSpeed = 2F;

    private float damageCooldown;

    public void SetDefaultLevels(int _health, int _powerLevel)
    {
        maxHealth = _health;
        powerLevel = _powerLevel;
    }

    void OnDifficultyChange(Difficulty diff)
    {
        switch (diff)
        {
            case Difficulty.EASY:
                maxHealth = 10;
                powerLevel = 100;
                GetComponent<Renderer>().material.color = Color.green;
                break;
            case Difficulty.MEDIUM:
                maxHealth = 150;
                powerLevel = 250;
                GetComponent<Renderer>().material.color = Color.blue;
                break;
            case Difficulty.HARD:
                maxHealth = 500;
                powerLevel = 1000;
                GetComponent<Renderer>().material.color = Color.yellow;
                break;
            case Difficulty.HELL:
                maxHealth = 1500;
                powerLevel = 3000;
                GetComponent<Renderer>().material.color = Color.red;
                break;
            case Difficulty.GODMODE:
                maxHealth = 4000;
                powerLevel = 9000;
                GetComponent<Renderer>().material.color = Color.black;
                break;

            default:
                maxHealth = 10;
                powerLevel = 100;
                break;

        }
    }

    // Gets called every frame
    void Update()
    {
        if (health <= 0)
            Destroy(gameObject);
    }

    void OnTriggerStay(Collider other)
    {
        damageCooldown += Time.deltaTime;
        
        if(damageCooldown >= damageSpeed)
        {
            damageCooldown = 0F;

            if (other.CompareTag("Player"))
            {
                other.transform.GetComponent<Player>().Damage(5);
            }
        }
    }

    public void Damage(int damage)
    {
        health -= (float)damage / maxHealth;

        if (health < 0F)
            health = 0F;
    }
}
