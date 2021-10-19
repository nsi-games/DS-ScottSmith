using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{



    CharacterController charCon;

    [SerializeField]
    float speed;

    void Start()
    {
        charCon = GetCompenent<CharacterController>();
    }

    void Update()
    {
        if (charCon.isGrounded)
        {
            movement.x = 0;
            movement.z = 0;
            movement.y = -1;

            movement += transform.forward * Input.GetAxisRaw("Vertical");
            movement += transform.right * Input.GetAxisRaw("Horizontal");

            //Vector3 movement = Vector3.zero;
            //movement += transform.forward * Input.GetAxisRaw("Vertical");
            //movement += transform.right * Input.GetAxisRaw("Horizontal");

            //charCon.SimpleMove(movement * speed);
        }
        if (Input.GetButtonDown("jump"))
        {
            movement.y = 5;


        }
        else
        {
            movement.y -= 9.8f * Time.deltaTime;
        }
        Debug.Log("Grounded =  " + charCon.isGrounded);

        charCon.move(movement * (speed + (myStats.agility / 2) / myStats.hunger + 1) * Time.deltaTime);

    }
}