using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Gamestate
{
    TITLE,
    INGAME,
    PAUSE,
    GAMEOVER
}
public enum Difficulty
{
    EASY,
    MEDIUM,
    HARD,
    HELL,
    GODMODE
}

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int lives;
    public float timer = 120;

    public Difficulty difficulty;
    public Gamestate gameState;


    // Use this for initialization
    void Start()
    {
        difficulty = Difficulty.MEDIUM;
        gameState = Gamestate.TITLE;

    }

    void Update()
    {
        timer -= Time.deltaTime;                   
    }
    void LoadNewScene()
    {
        SceneManager.LoadScene("SceneTwo");
    }

    void CycleDifficulty()
    {
        switch (difficulty)
        {
            case Difficulty.EASY:
                difficulty = Difficulty.MEDIUM;
                break;
            case Difficulty.MEDIUM:
                difficulty = Difficulty.HARD;
                break;
            case Difficulty.HARD:
                difficulty = Difficulty.HELL;
                break;
            case Difficulty.HELL:
                difficulty = Difficulty.GODMODE;
                break;
            case Difficulty.GODMODE:
                difficulty = Difficulty.EASY;
                break;
            default:
                difficulty = Difficulty.MEDIUM;
                break;

        }
    }
}
