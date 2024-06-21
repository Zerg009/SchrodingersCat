using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourthScreen : MonoBehaviour
{
    TextController textController;
    Transform parent;
    public SecondDialogueScript dialogueScript;
    public GameObject dialogueBox ;
    public AudioControllerScript audioController;
    public MainScript mainScript;
    public static bool isGameEnded = false;
    int step = 3;

    void Start()
    {
        parent = gameObject.transform.parent;
        textController = parent.GetComponent<TextController>();
        textController.UpdateText("");
    }
    void OnEnable()
    {
        dialogueBox.SetActive(true);
        audioController.ChangeSubfolder(step + 1);
        dialogueScript.ChangeScene(2);
        isGameEnded = true;
    }

}
