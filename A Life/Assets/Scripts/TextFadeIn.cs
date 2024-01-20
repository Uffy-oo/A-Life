using System.Collections;
using UnityEngine;
using TMPro;

public class TextFadeIn : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public float duration = 2.0f; // Duration in seconds for the fade-in effect

    private void Start()
    {
        // Initialize the text with full transparency
        textMeshPro.alpha = 0f;
        StartCoroutine(FadeInText(duration, textMeshPro));
    }

    private IEnumerator FadeInText(float duration, TextMeshProUGUI text)
    {
        // Calculate the range of characters in the text
        int totalCharacters = text.textInfo.characterCount;

        float currentTime = 0f;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            int charactersToShow = Mathf.FloorToInt((currentTime / duration) * totalCharacters);

            // Set alpha values
            for (int i = 0; i < totalCharacters; i++)
            {
                // Determine the alpha value (full alpha for shown characters, zero for the rest)
                byte alpha = (i < charactersToShow) ? (byte)255 : (byte)0;
                text.textInfo.meshInfo[0].colors32[i * 4 + 0].a = alpha;
                text.textInfo.meshInfo[0].colors32[i * 4 + 1].a = alpha;
                text.textInfo.meshInfo[0].colors32[i * 4 + 2].a = alpha;
                text.textInfo.meshInfo[0].colors32[i * 4 + 3].a = alpha;
            }

            // Update the mesh with the new alpha values
            textMeshPro.mesh.colors32 = text.textInfo.meshInfo[0].colors32;

            yield return null;
        }
    }
}
