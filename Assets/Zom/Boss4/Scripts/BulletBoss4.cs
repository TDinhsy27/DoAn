using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBoss4 : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] public int h_BulletSpeed = 6;
    public float h_PlusDamege;

    private SpriteRenderer sprite;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        FindPlayer();
    }
    // Update is called once per frame
    void Update()
    {

    }

    protected void FindPlayer()
    {
        GameObject playerObject = GameObject.FindWithTag("Player01Animation");

        if (playerObject != null)
        {
            Transform playerTransform = playerObject.transform;
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

            Vector3 playerPosition = playerObject.transform.position;

            // Tính h??ng b?n t?nh t? v? trí hi?n t?i c?a ??n ??n v? trí c?a ng??i ch?i
            Vector3 shootingDirection = (playerPosition - transform.position).normalized;

            float angle = Mathf.Atan2(shootingDirection.y, shootingDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            // ??t t?c ?? cho ??n và b?n nó
            rb.velocity = shootingDirection * h_BulletSpeed;

            // H?y ??n sau m?t kho?ng th?i gian
            Destroy(gameObject, 2f);
        }
        else
        {
            Destroy(gameObject, 2f);
            return;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player01Animation"))
        {
            Destroy(gameObject);
            PlayerLife playerLife = collision.gameObject.GetComponent<PlayerLife>();
            playerLife.PlayerTakeDamage(playerLife.GetTotalATK() * h_PlusDamege);
        }
    }
}
