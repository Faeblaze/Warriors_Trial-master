using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    private Player player;
    private SpawnManager Sawning;
    public static int enemiesKilled;

    public RectTransform healthBarBackground;
    public RectTransform healthBar;

    private Text healthText;
    public Text counterText;
    public GameObject Win;
    public GameObject Quit;

	void Awake () {
        player = (Player)FindObjectOfType(typeof(Player));

        healthText = healthBarBackground.GetComponentInChildren<Text>();

        Quit.SetActive(false);
        Win.SetActive(false);
        enemiesKilled = 0;
    }
	
	// Update is called once per frame
	void Update () {
        healthBar.sizeDelta = Vector2.Lerp(healthBar.sizeDelta, new Vector2(healthBarBackground.sizeDelta.x * player.health, healthBar.sizeDelta.y), Time.deltaTime * 20F);

        healthText.text = Mathf.RoundToInt(player.health * player.maxHealth) + "/" + player.maxHealth;

        counterText.text = "Enemies Killed: " + enemiesKilled;

        if (enemiesKilled >= 20)
        {
            Win.SetActive(true);
            Quit.SetActive(true);        
            Time.timeScale = 0;
        }      
    }

    public void QuitGame()
    {
        Application.Quit();
    }



}
