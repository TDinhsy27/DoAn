using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZomBoom : MonoBehaviour
{
    public SpriteRenderer sprite;
    public Animator animator;
    //[SerializeField] GameObject h_HP;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        FindPlayer1();
    }

    public void FindPlayer1()
    {
        GameObject player01Animation = GameObject.FindGameObjectWithTag("Player01Animation");

        if (player01Animation != null)
        {
            Transform playerTransform = player01Animation.transform;


            float direction = Vector3.Distance(playerTransform.position, transform.position);

            if (direction <= 10f)
            {
                animator.SetInteger("State", 1);

            }
            else
            {
                animator.SetInteger("State", 0);
            }
            float enemyX = transform.position.x;
            float playerX = playerTransform.position.x;

            if (playerX < enemyX)
            {
                Vector3 newRotation = transform.eulerAngles;
                newRotation.y = 0; // ??t góc y v? 0
                transform.eulerAngles = newRotation;
            }
            else if (playerX > enemyX)
            {
                Vector3 newRotation = transform.eulerAngles;
                newRotation.y = 180; // ??t góc y v? 180 ?? quay ng??c l?i
                transform.eulerAngles = newRotation;
            }

            /*if (playerX < enemyX)
            {
                sprite.flipX = true;
            }
            else if (playerX > enemyX)
            {
                sprite.flipX = false;
            }*/
            //h_HP.transform.rotation = Quaternion.identity;
        }
        else
        {
            return;
        }

    }


    /*public void FindPlayer2()
    {
        GameObject player01Animation = GameObject.FindGameObjectWithTag("Player01Animation");

        if (player01Animation != null)
        {
            Transform playerTransform = player01Animation.transform;

            float direction = Vector3.Distance(playerTransform.position, transform.position);

            if (direction <= 9f)
            {
                animator.SetTrigger("IsRun");
                transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, Speed * Time.deltaTime);

            }
            float enemyX = transform.position.x;
            float playerX = playerTransform.position.x;

            if (playerX > enemyX)
            {
                Vector3 newRotation = transform.eulerAngles;
                newRotation.y = 0; // ??t góc y v? 0
                transform.eulerAngles = newRotation;
            }
            else if (playerX < enemyX)
            {
                Vector3 newRotation = transform.eulerAngles;
                newRotation.y = 180; // ??t góc y v? 180 ?? quay ng??c l?i
                transform.eulerAngles = newRotation;
            }
            h_HP.transform.rotation = Quaternion.identity;
        }
        else
        {
            return;
        }

    }*/
}
