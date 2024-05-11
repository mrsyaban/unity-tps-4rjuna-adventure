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
    public Image backgroundImage; 
    public AudioClip[] lineAudioClips; 
    private AudioSource audioSource; 
    public Sprite[] backgroundImages; 
    [SerializeField] public string nextScene;
    private int index;

    
    void Start()
    {
        textComponent.text = string.Empty;
        audioSource = gameObject.AddComponent<AudioSource>(); 
        StartDialogue();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                audioSource.Stop(); 
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                audioSource.Stop(); 
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        UpdateDialogueImage();
        UpdateBackgroundImage(); 
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        audioSource.PlayOneShot(lineAudioClips[index]); 
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
            UpdateBackgroundImage();
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
                dialogueImage.sprite = newSprite;
            }
            else
            {
                StartCoroutine(FadeImageCoroutine(dialogueImage, newSprite, 0.5f)); 
            }
        }
    }

    void UpdateBackgroundImage()
    {
        if (backgroundImage != null && backgroundImages != null && index < backgroundImages.Length)
        {
            backgroundImage.sprite = backgroundImages[index]; 
        }
    }

    IEnumerator FadeImageCoroutine(Image image, Sprite newSprite, float duration)
    {
        for (float t = 0; t < 1.0f; t += Time.deltaTime / duration)
        {
            Color newColor = image.color;
            newColor.a = 1.0f - t;
            image.color = newColor;
            yield return null;
        }

        image.sprite = newSprite;

        for (float t = 0; t < 1.0f; t += Time.deltaTime / duration)
        {
            Color newColor = image.color;
            newColor.a = t;
            image.color = newColor;
            yield return null;
        }

        Color finalColor = image.color;
        finalColor.a = 1.0f;
        image.color = finalColor;
    }
}
