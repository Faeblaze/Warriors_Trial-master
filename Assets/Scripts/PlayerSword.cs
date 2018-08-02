using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSword : MonoBehaviour {

    private Player player;


	// Use this for initialization
	void Start ()
    {
        player = (Player)Object.FindObjectOfType(typeof(Player));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter (Collider other)
    {
        if (!player.animator.GetCurrentAnimatorStateInfo(0).IsName("swing") && !player.animator.GetCurrentAnimatorStateInfo(0).IsName("1HAttack") && !player.animator.GetCurrentAnimatorStateInfo(0).IsName("2HAttack"))
            return;

        if (other.CompareTag("Enemy"))
        {
            Enemy_Class enemy = other.GetComponentInChildren<Enemy_Class>();

            Debug.Log("Herpty derp I have collided");

            enemy.health -= player.damage;
            //enemy.Health -= Player Damage
        }
    }
}
