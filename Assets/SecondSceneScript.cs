using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SecondSceneScript : MonoBehaviour
{
    TextController textController;
    Transform parent;
    public DialogueScript dialogueScript;
    public SecondDialogueScript secondDialogueScript;
    public AudioControllerScript audioController;
    public GameObject dialogueBox;
    public static bool showedBefore = false;
    int step = 1;
    void Start()
    {
        parent = gameObject.transform.parent;
        textController = parent.GetComponent<TextController>();
    }
    public void InitData()
    {
        dialogueBox.SetActive(true);
        if (!showedBefore)
        {
            showedBefore = true;
            audioController.ChangeSubfolder(step + 1);
            secondDialogueScript.ChangeScene(0);
            return;
        }

        audioController.ChangeSubfolder(6);
        secondDialogueScript.ChangeScene(1);
   

    }
    void OnEnable()
    {
        InitData();

    }
}
