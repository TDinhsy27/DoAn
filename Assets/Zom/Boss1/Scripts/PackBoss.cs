using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackBoss : MonoBehaviour
{
    private Animator animator;
    [SerializeField] public GameObject[] h_BulletEnemy;
    [SerializeField] float h_TimeAttack = 1;
    [SerializeField] GameObject h_PointFire;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        FindPlayer2();
        h_TimeAttack -= Time.deltaTime;
    }

    public void Attack1()
    {
        GameObject gameObject = GameObject.FindGameObjectWithTag("Player01Animation");
        if (gameObject != null)
        {
            Vector3 vector3 = gameObject.transform.position;
            vector3.y = gameObject.transform.position.y + 2f;
            GameObject game = Instantiate(h_BulletEnemy[0], vector3, Quaternion.identity);
            AudioManager.instance.Play("EnemyAttack");
            animator.SetInteger("State", 0);
        }
        else
        {
            return;
        }
    }

    public void Attack2()
    {
        Vector3 vector3 = h_PointFire.transform.position;
        GameObject game = Instantiate(h_BulletEnemy[1], vector3, Quaternion.identity);
        AudioManager.instance.Play("EnemyAttack");
        animator.SetInteger("State", 0);
    }

    public void FindPlayer2()
    {
        GameObject player01Animation = GameObject.FindGameObjectWithTag("Player01Animation");

        if (player01Animation != null)
        {
            Transform playerTransform = player01Animation.transform;

            float direction = Vector3.Distance(playerTransform.position, transform.position);

            if (direction <= 12f && h_TimeAttack <= 0)
            {
                int randomNumber = Random.Range(0, 2);
                if (randomNumber == 0)
                {
                    animator.SetInteger("State", 1);
                    h_TimeAttack = 4;
                }
                else if (randomNumber == 1)
                {
                    animator.SetInteger("State", 2);
                    h_TimeAttack = 4;
                }
            }

            float enemyX = transform.position.x;
            float playerX = playerTransform.position.x;

            if (playerX < enemyX)
            {
                Vector3 newRotation = transform.eulerAngles;
                newRotation.y = 0; // Đặt góc y về 0
                transform.eulerAngles = newRotation;
            }
            else if (playerX > enemyX)
            {
                Vector3 newRotation = transform.eulerAngles;
                newRotation.y = 180; // Đặt góc y về 180 để quay ngược lại
                transform.eulerAngles = newRotation;
            }

        }
        else
        {
            return;
        }

    }
}
