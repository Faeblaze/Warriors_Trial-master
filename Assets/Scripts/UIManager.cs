using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    private Player player;

    public RectTransform healthBarBackground;
    public RectTransform healthBar;

    private Text healthText;

	void Awake () {
        player = (Player)FindObjectOfType(typeof(Player));

        healthText = healthBarBackground.GetComponentInChildren<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        healthBar.sizeDelta = Vector2.Lerp(healthBar.sizeDelta, new Vector2(healthBarBackground.sizeDelta.x * ((float)Mathf.Min(player.health, player.maxHealth) / player.maxHealth), healthBar.sizeDelta.y), Time.deltaTime * 20F);

        healthText.text = player.health + "/" + player.maxHealth;
    }
}
