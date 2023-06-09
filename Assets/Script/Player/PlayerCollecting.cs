using UnityEngine.UI;
using UnityEngine;

public class PlayerCollecting : MonoBehaviour
{
    [SerializeField] private Text moneyText;
    private bool isOrganic;
    private bool isAnOrganic;
    private int money;

    private void Start() {
        if (PlayerPrefs.HasKey("money"))
        {
            money = PlayerPrefs.GetInt("money");
        }
        else
        {
            PlayerPrefs.SetInt("money", 0);
        }
    }

    private void FixedUpdate() {
        if (isOrganic)
        {
            money += 1000;
            isOrganic = false;
        }

        if (isAnOrganic)
        {
            money += 1500;
            isAnOrganic = false;
        }
        moneyText.text = money.ToString();
        PlayerPrefs.SetInt("money", money);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Organic"))
        {
            isOrganic = true;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("An-Organic"))
        {
            isAnOrganic = true;
            Destroy(other.gameObject);
        }
    }
}