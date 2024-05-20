using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZomLV5 : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Animator animator;
    [SerializeField] public GameObject h_BulletEnemy;
    public float h_IsShoot = 1;

    public Transform h_PointShooting;
    [SerializeField] GameObject h_HP;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        h_IsShoot -= Time.deltaTime;
    }

    public void Attack1()
    {
        if (h_PointShooting != null)
        {

            GameObject game = Instantiate(h_BulletEnemy, h_PointShooting.position, Quaternion.identity);
            AudioManager.instance.Play("EnemyAttack");
            h_IsShoot = 1;

        }
        else
        {
            return;
        }

    }

    public void FindPlayer2()
    {
        GameObject player01Animation = GameObject.FindGameObjectWithTag("Player01Animation");

        if (player01Animation != null)
        {
            Transform playerTransform = player01Animation.transform;

            float direction = Vector3.Distance(playerTransform.position, transform.position);

            if (direction <= 10f && h_IsShoot <= 0)
            {
                animator.SetTrigger("IsAttack");

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

    }
}
