//######################################
//  code writen by
//                 Martin Gurasvili
//  licence: free to use and edit 
//######################################

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boss : MonoBehaviour
{
    public float speed;  //speed it travels at

    public int life = 5000; //health of enemy

    private bool movingr = true; //variable for if its moving or not for the animator

    public Transform groundDetec; //transform you need to add infront of the ememy pointing down

    public Animator animator; //animations 


    public GameObject deathEffect; //game object animation of death effect

    public Slider healthbar; //ui slider for the health of the enemy



    public void TakeDamage(int damage)
    {
        life -= damage;

        if (life <= 0)
        {

            Die();
        }

    }


    void Update()
    {
        if (life == 4700.00)
        {
            animator.SetBool("isfollow", true);
        }
        healthbar.value= life;



        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetec.position, Vector2.down, 2f);
        if (groundInfo.collider == false)
        {
            if (movingr == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingr = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingr = true;

            }

        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);

        Destroy(gameObject);

    }

    



}