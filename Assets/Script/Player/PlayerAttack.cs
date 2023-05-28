using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private DogEnemyScript enemyDog;
    private CatEnemyScript enemyCat;
    public bool isJumpEnemy;

    private void Start() {
        enemyDog = FindObjectOfType<DogEnemyScript>();
        enemyCat = FindObjectOfType<CatEnemyScript>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("EnemyDog"))
        {
            isJumpEnemy = true;
            enemyDog.EnemyGetAttack();
        }

        if (other.gameObject.CompareTag("EnemyCat"))
        {
            isJumpEnemy = true;
            enemyCat.EnemyGetAttack();
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.CompareTag("EnemyDog"))
        {
            isJumpEnemy = false;
        }

        if (other.gameObject.CompareTag("EnemyCat"))
        {
            isJumpEnemy = false;
        }
    }
}
