using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FirstSceneScript : MonoBehaviour
{
    TextController textController;
    Transform parent;
    GameObject clickedObject;
    public DialogueScript dialogueScript;
    public GameObject dialogueBox;
    public AudioControllerScript audioController;
    public Dictionary<int, string> objectIndex;
    int step = 0;
    public void OnPointerClick(GameObject gameObject)
    {
        clickedObject = gameObject;
        if (gameObject.name == "Box_Opened")
        {
            if (AvailableObjectsToAdd())
            {
                textController.UpdateText("Add all items to the box!");
                return;
            }
            MainScript mainScript = parent.GetComponent<MainScript>();
            MainScript.step = step;

            mainScript.changeScene();
            dialogueBox.SetActive(false);
            return;
        }
        if (gameObject.name == objectIndex[dialogueScript.index])
        {
            dialogueScript.NextLine();

            //Debug.Log("Set object " + gameObject.name);
            textController.UpdateText("Added item \'" + gameObject.name + "\' to the box!");
            gameObject.SetActive(false);
        }
        else
        {

        }
    }
    private bool AvailableObjectsToAdd()
    {
        if (parent == null)
        {
            Debug.LogWarning("No parent found for the GameObject.");
            return false;
        }

        // Iterate through all siblings of the parent GameObject
        foreach (Transform sibling in gameObject.transform)
        {
            // Skip checking against itself
            if (sibling == clickedObject.transform || sibling.name == "scientist")
                continue;

            // Check if the sibling GameObject is active
            if (sibling.gameObject.activeSelf)
            {
                return true; // If any sibling is active, return false
            }
        }

        return false; // If all siblings are disabled, return true
    }
    private void EnableAllChildren()
    {
        if (parent == null)
        {
            Debug.LogWarning("No parent found for the GameObject.");

        }

        // Iterate through all siblings of the parent GameObject
        foreach (Transform sibling in gameObject.transform)
        {
            sibling.gameObject.SetActive(true);
        }


    }
    // Start is called before the first frame update
    void Start()
    {
        parent = gameObject.transform.parent;
        textController = parent.GetComponent<TextController>();
        textController.UpdateText("");
        objectIndex = new Dictionary<int, string>
        {
            { 0, "Cat" },
            { 1, "Poison" },
            { 2, "Geiger_Counter" },
            { 3, "Radioactive_Material" },
            { 4, "Hammer" },
            { 5, "Box_Opened"}

        };

    }
    void OnEnable()
    {
        InitData();
    }
    public void InitData()
    {
        EnableAllChildren();
        FourthScreen.isGameEnded = false;
        dialogueBox.SetActive(true);
        audioController.ChangeSubfolder(step + 1);
        dialogueScript.ChangeScene(step + 1);

    }

}
