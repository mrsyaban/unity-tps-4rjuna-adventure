using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public TextMeshProUGUI textComponent1;
    public TextMeshProUGUI textComponent2;
    public TextMeshProUGUI textComponent3;
    public Image image1;
    public Image image2;
    public Button button1;
    public Button button2;
    public Button button3;
    public Sprite newImage1;
    public Sprite newImage2;
    public AudioClip transactionSound; 

    private AudioSource audioSource; 
    private const int cost1 = 15;
    private const int cost2 = 20;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>(); 
        CheckButtonAccessibility();
        button1.onClick.AddListener(() => ProcessTransaction(0, cost1, image1, button1, newImage1));
        button2.onClick.AddListener(() => ProcessTransaction(1, cost2, image2, button2, newImage2));
        button3.onClick.AddListener(() => NextScene.Next("Scenes/Cutscene04"));
        UpdateCoinDisplay();
    }

    void CheckButtonAccessibility()
    {
        button1.interactable = button1.interactable && GameStateManager.Instance.GetCoins() >= cost1;
        button2.interactable = button2.interactable && GameStateManager.Instance.GetCoins() >= cost2;
    }

    void ProcessTransaction(int petIndex, int cost, Image image, Button button, Sprite newSprite)
    {
        if (GameStateManager.Instance.GetCoins() >= cost)
        {
            GameStateManager.Instance.AddCoin(-cost);
            UpdateCoinDisplay();
            button.interactable = false;
            button.GetComponentInChildren<TextMeshProUGUI>().text = "Summoned";
            StartCoroutine(FadeAndChangeSprite(image, newSprite));
            GameStateManager.Instance.BuyPet(petIndex);
            audioSource.PlayOneShot(transactionSound); 
        }
    }

    IEnumerator FadeAndChangeSprite(Image image, Sprite newSprite)
    {
        for (float alpha = 1f; alpha >= 0; alpha -= Time.deltaTime)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
            yield return null;
        }
        image.sprite = newSprite;
        for (float alpha = 0f; alpha <= 1f; alpha += Time.deltaTime)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
            yield return null;
        }
    }

    void UpdateCoinDisplay()
    {
        if (GameStateManager.Instance != null)
        {
            textComponent3.text = GameStateManager.Instance.GetCoins().ToString();
        }
        CheckButtonAccessibility();
    }
}
