using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    public Text speakerText;
    public Text dialogueText;
    public AudioSource audioSource;
    public float textSpeed = 0.05f; 

    private DialogueData currentDialogue;
    private int currentLineIndex = 0;

    public void StartDialogue(DialogueData dialogue)
    {
        currentDialogue = dialogue;
        currentLineIndex = 0;
        speakerText.text = dialogue.speakerName;
        StartCoroutine(DisplayDialogue());
    }

    IEnumerator DisplayDialogue()
    {
        while (currentLineIndex < currentDialogue.dialogueLines.Length)
        {
            dialogueText.text = "";
            foreach (char letter in currentDialogue.dialogueLines[currentLineIndex].ToCharArray())
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(textSpeed);
            }

            if (currentDialogue.voiceOverClips.Length > currentLineIndex && currentDialogue.voiceOverClips[currentLineIndex] != null)
            {
                audioSource.clip = currentDialogue.voiceOverClips[currentLineIndex];
                audioSource.Play();
            }

            yield return new WaitForSeconds(2f); // Wait before next line
            currentLineIndex++;
        }
    }
}

