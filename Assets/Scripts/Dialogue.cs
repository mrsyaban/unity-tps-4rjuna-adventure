using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public Image dialogueImage;
    public Sprite[] lineImages;
    public Image backgroundImage; // Properti untuk latar belakang
    public Sprite[] backgroundImages; // Array untuk menyimpan sprite latar belakang
    [SerializeField] public string nextScene;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        UpdateDialogueImage();
        UpdateBackgroundImage(); // Memanggil metode untuk memperbarui latar belakang
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            UpdateDialogueImage();
            UpdateBackgroundImage(); // Memanggil metode untuk memperbarui latar belakang
            StartCoroutine(TypeLine());
        }
        else
        {
            NextScene.Next(nextScene);
            gameObject.SetActive(false);
        }
    }

    void UpdateDialogueImage()
    {
        if (dialogueImage != null && lineImages != null && index < lineImages.Length)
        {
            Sprite newSprite = lineImages[index];
            if (dialogueImage.sprite == newSprite)
            {
                // Jika sprite sama, tidak perlu fade, hanya update sprite secara langsung
                dialogueImage.sprite = newSprite;
            }
            else
            {
                StartCoroutine(FadeImageCoroutine(dialogueImage, newSprite, 0.5f)); // Durasi fade bisa disesuaikan
            }
        }
    }

    void UpdateBackgroundImage()
    {
        if (backgroundImage != null && backgroundImages != null && index < backgroundImages.Length)
        {
            backgroundImage.sprite = backgroundImages[index]; // Mengubah sprite latar belakang sesuai dengan indeks
        }
    }

    IEnumerator FadeImageCoroutine(Image image, Sprite newSprite, float duration)
    {
        // Fade out
        for (float t = 0; t < 1.0f; t += Time.deltaTime / duration)
        {
            Color newColor = image.color;
            newColor.a = 1.0f - t;
            image.color = newColor;
            yield return null;
        }

        // Ganti sprite setelah fade out
        image.sprite = newSprite;

        // Fade in
        for (float t = 0; t < 1.0f; t += Time.deltaTime / duration)
        {
            Color newColor = image.color;
            newColor.a = t;
            image.color = newColor;
            yield return null;
        }

        // Pastikan alpha kembali ke 1
        Color finalColor = image.color;
        finalColor.a = 1.0f;
        image.color = finalColor;
    }
}
