using TMPro;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    public int brassCount = 0;
    public int silverCount = 0;
    public int darkGoldCount = 0;
    public int GoldCount = 0;

    public TMP_Text Brass_Coin;     // Text for Brass coin
    public TMP_Text Silver_Coin;    // Text for Silver coin
    public TMP_Text DarkGold_Coin;  // Text for DarkGold coin
    public TMP_Text Gold_Coin;      // Text for Gold coin

    private Nextpage gameManager;

    private void Start()
    {
        // Hide all coin texts at the beginning
        Brass_Coin.gameObject.SetActive(false);
        Silver_Coin.gameObject.SetActive(false);
        DarkGold_Coin.gameObject.SetActive(false);

        gameManager = GameObject.FindObjectOfType<Nextpage>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BrassCoin"))
        {
            brassCount++;
            Destroy(other.gameObject);

            Brass_Coin.gameObject.SetActive(true);
            Brass_Coin.text = "Brass : " + brassCount.ToString();
        }
        else if (other.gameObject.CompareTag("SilverCoin"))
        {
            silverCount++;
            Destroy(other.gameObject);

            Silver_Coin.gameObject.SetActive(true);
            Silver_Coin.text = "Silver : " + silverCount.ToString();
        }
        else if (other.gameObject.CompareTag("DarkGoldCoin"))
        {
            darkGoldCount++;
            Destroy(other.gameObject);

            DarkGold_Coin.gameObject.SetActive(true);
            DarkGold_Coin.text = "DarkGold : " + darkGoldCount.ToString();
        }
        else if (other.gameObject.CompareTag("GoldCoin"))
        {
            GoldCount++;
            Destroy(other.gameObject);

            Gold_Coin.gameObject.SetActive(true);
            Gold_Coin.text = "Gold : " + GoldCount.ToString();

            if (GameObject.FindGameObjectsWithTag("GoldCoin").Length <= 1)
            {
                gameManager.TriggerGameWin();
            }
        }
    }
}
