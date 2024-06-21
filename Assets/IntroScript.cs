using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroScript : MonoBehaviour
{
            public DialogueScript dialogueScript;
    public GameObject dialogueBox ;
    public AudioControllerScript audioController;
    public void InitData()
    {
        dialogueBox.SetActive(true);
        audioController.ChangeSubfolder(0);
        dialogueScript.ChangeScene(0);
        SecondSceneScript.showedBefore = false;
    }

}
