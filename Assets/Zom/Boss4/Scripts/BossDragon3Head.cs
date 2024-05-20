using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDragon3Head : MonoBehaviour
{
    private Animator animator;
    [SerializeField] public GameObject[] h_BulletEnemy;
    [SerializeField] float h_TimeAttack = 3;
    [SerializeField] GameObject[] h_PointFire1;
    [SerializeField] GameObject[] h_PointFire2;
    [SerializeField] GameObject[] h_PointFire3;

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
        int randomIndex1 = Random.Range(0, h_BulletEnemy.Length);
        Vector3 vector3 = h_PointFire1[0].transform.position;
        GameObject game = Instantiate(h_BulletEnemy[randomIndex1], vector3, Quaternion.identity);
        AudioManager.instance.Play("EnemyAttack");
        animator.SetInteger("State", 0);
    }

    public void Attack2()
    {
        int randomIndex2 = Random.Range(0, h_BulletEnemy.Length);
        Vector3 vector3 = h_PointFire2[0].transform.position;
        GameObject game = Instantiate(h_BulletEnemy[randomIndex2], vector3, Quaternion.identity);

        List<int> remainingIndices = new List<int>();
        for (int i = 0; i < h_BulletEnemy.Length; i++)
        {
            if (i != randomIndex2)
            {
                remainingIndices.Add(i);
            }
        }

        int randomIndex22 = remainingIndices[Random.Range(0, remainingIndices.Count)];
        Vector3 vector32 = h_PointFire2[1].transform.position;
        GameObject game2 = Instantiate(h_BulletEnemy[randomIndex22], vector32, Quaternion.identity);

        AudioManager.instance.Play("EnemyAttack");
        animator.SetInteger("State", 0);
    }
    public void Attack3()
    {
        int randomIndex3 = Random.Range(0, h_BulletEnemy.Length);
        Vector3 vector3 = h_PointFire3[0].transform.position;
        GameObject game = Instantiate(h_BulletEnemy[randomIndex3], vector3, Quaternion.identity);

        List<int> remainingIndices = new List<int>();
        for (int i = 0; i < h_BulletEnemy.Length; i++)
        {
            if (i != randomIndex3)
            {
                remainingIndices.Add(i);
            }
        }

        int randomIndex33 = remainingIndices[Random.Range(0, remainingIndices.Count)];
        Vector3 vector33 = h_PointFire3[1].transform.position;
        GameObject game3 = Instantiate(h_BulletEnemy[randomIndex33], vector33, Quaternion.identity);

        remainingIndices.Remove(randomIndex33);
        int randomIndex333 = remainingIndices[Random.Range(0, remainingIndices.Count)];
        Vector3 vector333 = h_PointFire3[2].transform.position;
        GameObject game33 = Instantiate(h_BulletEnemy[randomIndex333], vector333, Quaternion.identity);

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

            if (direction <= 15f && h_TimeAttack <= 0)
            {
                int randomNumber = Random.Range(0, 3);
                if (randomNumber == 0)
                {
                    animator.SetInteger("State", 1);
                    h_TimeAttack = 4;
                }
                if (randomNumber == 1)
                {
                    animator.SetInteger("State", 2);
                    h_TimeAttack = 4;
                }
                else if (randomNumber == 2)
                {
                    animator.SetInteger("State", 3);
                    h_TimeAttack = 4;
                }
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

        }
        else
        {
            return;
        }

    }
}
