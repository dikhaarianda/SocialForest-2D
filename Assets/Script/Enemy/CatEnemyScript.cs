using System.Collections;
using UnityEngine;

public class CatEnemyScript : MonoBehaviour
{
    [SerializeField] private GameObject[] Points;
    [SerializeField] private GameObject TargetPoint;
    private Animator animator;
    private float speed;
    private int PointIndex = 0;

    [Header("Attack")]
    [SerializeField] private float AttackRange;
    [SerializeField] private float SeePlayerRange;

    private PlayerMovement Player;
    [SerializeField] private int health = 2;

    void Start()
    {
        animator = GetComponent<Animator>();
        Player = FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
        if (Vector2.Distance(Points[PointIndex].transform.position, transform.position) < .1f)
        {
            PointIndex++;
            if (PointIndex >= Points.Length)
            {
                PointIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, Points[PointIndex].transform.position, Time.deltaTime * speed);

        if (PointIndex > 0)
        {
            transform.eulerAngles = Vector2.zero;
        }
        else
        {
            transform.eulerAngles = Vector2.up * 180;
        }

        if (health <= 0)
        {
            animator.SetTrigger("isDead");
            speed = 0;
            StartCoroutine(DelayTimer());
        }
        else
        {
            AttackCondition();
        }
    }

    private void AttackCondition()
    {
        float dist = Vector2.Distance(TargetPoint.transform.position, transform.position);

        if (dist <= AttackRange && TargetPoint.transform.position.y > transform.position.y)
        {
            animator.SetTrigger("isAttack");
            speed = 0;
        }
        else if (dist < SeePlayerRange)
        {
            speed = 8;
            animator.SetTrigger("isWalk");
        }
        else
        {
            speed = 2;
            animator.SetTrigger("isWalk");
        }
    }

    private IEnumerator DelayTimer()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

    public void PlayerAttack()
    {
        Player.Health-=5;
    }

    public void EnemyGetAttack()
    {
        health--;
        animator.SetTrigger("isHurt");
    }
}
