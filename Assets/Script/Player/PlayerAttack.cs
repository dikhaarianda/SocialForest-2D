using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private MainEnemyMovement enemy;
    public bool isJumpEnemy;

    private void Start() {
        enemy = FindObjectOfType<MainEnemyMovement>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Enemy"))
        {
            isJumpEnemy = true;
            enemy.EnemyGetAttack();
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.CompareTag("Enemy"))
        {
            isJumpEnemy = false;
        }
    }
}
