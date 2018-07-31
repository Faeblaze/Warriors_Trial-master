using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	void Start ()
    {
        difficulty = Difficulty.MEDIUM;
        gameState = Gamestate.TITLE;
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
