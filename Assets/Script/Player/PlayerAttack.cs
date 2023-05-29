using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public bool isJumpEnemy;

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Enemy"))
        {
            isJumpEnemy = true;
            other.transform.gameObject.GetComponent<EnemyScript>().EnemyGetAttack();
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.CompareTag("Enemy"))
        {
            isJumpEnemy = false;
        }
    }
}
