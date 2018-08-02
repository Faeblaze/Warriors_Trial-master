using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Class : MonoBehaviour
{

    public string enemyName;
    public int health;
    public int powerLevel;
    public float height;
    public float weight;
    public char sex;
    public float mySpeed;

    public void SetDefaultLevels(int _health, int _powerLevel)
    {
        health = _health;
        powerLevel = _powerLevel;
    }
    void OnEnemyHit()
    {
        health -= 10;
    }

    void OnDifficultyChange(Difficulty diff)
    {
        switch (diff)
        {
            case Difficulty.EASY:
                health = 10;
                powerLevel = 100;
                GetComponent<Renderer>().material.color = Color.green;
                break;
            case Difficulty.MEDIUM:
                health = 150;
                powerLevel = 250;
                GetComponent<Renderer>().material.color = Color.blue;
                break;
            case Difficulty.HARD:
                health = 500;
                powerLevel = 1000;
                GetComponent<Renderer>().material.color = Color.yellow;
                break;
            case Difficulty.HELL:
                health = 1500;
                powerLevel = 3000;
                GetComponent<Renderer>().material.color = Color.red;
                break;
            case Difficulty.GODMODE:
                health = 4000;
                powerLevel = 9000;
                GetComponent<Renderer>().material.color = Color.black;
                break;

            default:
                health = 10;
                powerLevel = 100;
                break;

        }
    }

    void Start()
    {
        health = 10;
        powerLevel = 100;
    }

    // Gets called every frame
    void Update()
    {
        if (health <= 0)
            Destroy(gameObject);
    }
}
