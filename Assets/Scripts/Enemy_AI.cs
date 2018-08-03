using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{
    Transform tr_Player;
   public float f_RotSpeed = 1.0f, f_MoveSpeed = 1.0f;

    //Use this for initialization

    void Start()
    {

        tr_Player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    //Update is called once per frame
    void Update()
    {
        /* Look at Player*/
        transform.rotation = Quaternion.Slerp(transform.rotation
                                              , Quaternion.LookRotation(new Vector3(tr_Player.position.x, transform.position.y, tr_Player.position.z) - transform.position)
                                              , f_RotSpeed * Time.deltaTime);

        /* Move at Player*/
        transform.position += transform.forward * f_MoveSpeed * Time.deltaTime;
    }

}
