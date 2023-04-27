using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypewriterEffect : MonoBehaviour
{
    public Text textComponent;                  // Reference to the Text component on the canvas
    public string textToType;                   // The text to be typed
    public float typingSpeed = 0.05f;           // The speed of typing in seconds
    private Coroutine typingCoroutine;         // Reference to the typing coroutine

    void Start()
    {
        // Start typing coroutine when the script is first loaded
        typingCoroutine = StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        textComponent.text = "";  // Clear existing text
        float typingSpeedThisCharacter = typingSpeed;
        // Loop through each character in the textToType

        for (int i = 0; i < textToType.Length; i++)
        {
            textComponent.text += textToType[i];  // Add the next character to the textComponent
            if (textToType[i].Equals(",")) typingSpeedThisCharacter *= 1.5f;
            if (textToType[i].Equals(".")) typingSpeedThisCharacter *= 2.0f;
            yield return new WaitForSeconds(typingSpeedThisCharacter);  // Wait for typingSpeed seconds before typing the next character
        }

        // Typing is complete
        typingCoroutine = null;
    }

    // Call this function to stop typing prematurely
    public void StopTyping()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            typingCoroutine = null;
        }
    }
}