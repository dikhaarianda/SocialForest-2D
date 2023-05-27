using UnityEngine;

public class DogMovement : MonoBehaviour
{
    [SerializeField] private GameObject[] Points;
    [SerializeField] private float speed;
    private Animator animator;
    private int PointIndex = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
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
            animator.SetTrigger("isWalk");
        }
        else
        {
            transform.eulerAngles = Vector2.up * 180;
            animator.SetTrigger("isWalk");
        }
    }
}
