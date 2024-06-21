using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdScreenScript : MonoBehaviour
{
    TextController textController;
    Transform parent;
    public DialogueScript dialogueScript;
    public GameObject dialogueBox ;
    public AudioControllerScript audioController;
    public MainScript mainScript;
    int step = 2;
    bool showedOnce = false;

    void Start()
    {
         parent = gameObject.transform.parent;
         textController = parent.GetComponent<TextController>();
         textController.UpdateText(""); 
    }
    void OnEnable()
    {
        dialogueBox.SetActive(true);
        if(!showedOnce)
        {
            audioController.ChangeSubfolder(step + 1);
            dialogueScript.ChangeScene(step + 1);
            showedOnce = true;
        }else{
            audioController.ChangeSubfolder(5);
            dialogueScript.ChangeScene(4);
        }
        
    }
}

