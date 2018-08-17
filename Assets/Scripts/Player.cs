using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using System;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    [NonSerialized]
    public float health = 1F;
    public int maxHealth = 100;
    public int powerLevel;
    public int damage = 10;
    float cooldown = 10;
    float dashcd = 10;
    float barriorcd = 10;
    bool supercd = true;
    bool dash = true;
    bool reflect = true;
        
    public GameObject UIMenuButton;
    public GameObject UIbutton2;


    public void SetDefaultLevels(int _health, int _powerLevel)
    {
        maxHealth = _health;
        powerLevel = _powerLevel;
    }


    [NonSerialized]
    public Animator animator;//You may not need an animator, but if so declare it here 

    int noOfClicks; //Determines Which Animation Will Play
    bool canClick; //Locks ability to click during animation event

    void Start()
    {
        //Initialize appropriate components
        animator = GetComponent<Animator>();

        noOfClicks = 0;
        canClick = true;

        UIMenuButton.SetActive(false);
        UIbutton2.SetActive(false);

        UIManager.instance.supercd.fillAmount = 0;
        cooldown = 0;
        UIManager.instance.dash.fillAmount = 0;
        cooldown = 0;
        UIManager.instance.reflect.fillAmount = 0;
        cooldown = 0;
    }

    void Update()
    {
        if (health <= 0)
        {
            UIMenuButton.SetActive(true);          
            UIbutton2.SetActive(true);
            UIManager.instance.Quit.SetActive(true);
            Time.timeScale = 0;
        }
        // SceneManager.LoadScene("Wk10");
        if (Input.GetMouseButtonDown(0)) { ComboStarter(); }
        if (Input.GetKeyDown(KeyCode.Alpha1) && supercd)
        {
            SuperAttack();
            supercd = false;
            cooldown = 10;
        }
        if (supercd == false)
        {
            cooldown -= Time.deltaTime;
            if(cooldown <= 0)
            {
                supercd = true;
                UIManager.instance.supercd.fillAmount = 1;
            }
        }

        UIManager.instance.supercd.fillAmount = cooldown/10;

        if (Input.GetKeyDown(KeyCode.Alpha2) && dash)
        {
            Evade();
            dash = false;
            dashcd = 10;
        }
        if (dash == false)
        {
            dashcd -= Time.deltaTime;
            if (dashcd <= 0)
            {
                dash = true;
                UIManager.instance.dash.fillAmount = 1;
            }
        }

        UIManager.instance.dash.fillAmount = dashcd / 10;

        if (Input.GetKeyDown(KeyCode.Alpha3) && reflect)
        {
            DestructiveBarrier();
            reflect = false;
            barriorcd = 10;
        }
        if (reflect == false)
        {
            barriorcd -= Time.deltaTime;
            if (barriorcd <= 0)
            {
                reflect = true;
                UIManager.instance.reflect.fillAmount = 1;
            }
        }

        UIManager.instance.reflect.fillAmount = barriorcd / 10;

    }

    // RESTART GAME ON BUTTON CLICK IN THE GAME.
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    void ComboStarter()
    {
        if (canClick)
        {
            noOfClicks++;
        }

        if (noOfClicks == 1)
        {
            animator.SetTrigger("Attack");
        }
    }

    public void ComboCheck()
    {

        canClick = false;

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("swing") && noOfClicks == 1)
        {//If the first animation is still playing and only 1 click has happened, return to idle
            animator.SetTrigger("Attack");
            canClick = true;
            noOfClicks = 0;
            damage = 10;
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("swing") && noOfClicks >= 2)
        {//If the first animation is still playing and at least 2 clicks have happened, continue the combo          
            animator.SetTrigger("Attack");
            canClick = true;
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("1HAttack") && noOfClicks == 2)
        {  //If the second animation is still playing and only 2 clicks have happened, return to idle         
            animator.SetTrigger("Attack");
            canClick = true;
            noOfClicks = 0;
            damage = 10;
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("1HAttack") && noOfClicks >= 3)
        {  //If the second animation is still playing and at least 3 clicks have happened, continue the combo         
            animator.SetTrigger("Attack");
            canClick = true;
            damage = 10;
        }
        else //if (animator.GetCurrentAnimatorStateInfo(0).IsName("2HAttack"))
        { //Since this is the third and last animation, return to idle          
            canClick = false;
            noOfClicks = 0;
            damage = 40;
        }

        
    }

    void SuperAttack()
    {
        animator.SetTrigger("SuperAttack");
    }

    void Evade()
    {

    }
    void DestructiveBarrier()
    {

    }


    public void Damage(int damage)
    {
        health -= (float)damage / maxHealth;
        if (health < 0F)
            health = 0F;
    }
}
