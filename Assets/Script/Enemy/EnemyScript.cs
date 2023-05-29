using System.Collections;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private GameObject[] Points;
    [SerializeField] private GameObject TargetPoint;
    private Animator animator;
    private float speed;
    private int PointIndex = 0;

    [Header("Attack")]
    [SerializeField] private float AttackRange;
    [SerializeField] private float SeePlayerRange;
    [SerializeField] private int health;

    private PlayerMovement Player;
    private bool isSeePlayer;

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
        bool isAttack = false;

        if (dist <= AttackRange && TargetPoint.transform.position.y > transform.position.y)
        {
            animator.SetTrigger("isAttack");
            speed = 0;
            isAttack = true;
        }
        else if (dist < SeePlayerRange)
        {
            isSeePlayer = true;
        }

        if (isSeePlayer && !isAttack)
        {
            speed = 8;
            animator.SetTrigger("isWalk");
            isAttack = false;
        }

        if(!isSeePlayer && !isAttack)
        {
            speed = 2;
            animator.SetTrigger("isWalk");
            isAttack = false;
        }
    }

    private IEnumerator DelayTimer()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(transform.parent.gameObject);
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