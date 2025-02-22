using UnityEngine;

[CreateAssetMenu(fileName = "NewDialogue", menuName = "Dialogue/DialogueData")]
public class DialogueData : ScriptableObject
{
    public string speakerName;
    [TextArea(3, 5)]
    public string[] dialogueLines;
    public AudioClip[] voiceOverClips; // Placeholder for voiceovers
}

