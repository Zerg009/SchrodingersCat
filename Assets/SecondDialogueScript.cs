using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SecondDialogueScript : MonoBehaviour
{
    public AudioControllerScript audioController;
    public TextMeshProUGUI textComponent;
    public MainScript mainScript;
    public GameObject intro;
    public GameObject fourthScene;
    public GameObject thirdScene;
    public string[][] allLines; // Two-dimensional array to hold lines for different scenes
    public float textSpeed;
    public int index;
    private int currentScene;
    bool IsTyping = false;
      private Dialogue currentDialogue;

    void Start()
    {
        textComponent.text = string.Empty;
        currentScene = 0; // Start with the first scene
        currentDialogue = LocalizationManager.Instance.GetLocalizedText(LanguageSelector.current_language);
        Debug.Log("Starting dialogue from start: ");
        StartDialogue(currentDialogue.text_2); // Start with text_1 as default
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheckForLanguageChange();
            if (textComponent.text == allLines[currentScene][index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = allLines[currentScene][index];
            }

        }
    }
    // void CheckForLanguageChange(){
    //     if(allLines != currentDialogue.text_2 && !IsTyping)
    //     {
    //         allLines = currentDialogue.text_2;
    //     }
    // }
    void CheckForLanguageChange(){
        if(!IsTyping)
        {
            allLines = currentDialogue.text_2;
        }
    }
    void StartDialogue(string[][] text)
    {
        StopAllCoroutines();
        index = 0;
         allLines = text;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        IsTyping = true;
        audioController.PlayAudioClip(index);
        foreach (char c in allLines[currentScene][index].ToCharArray())
        {
            //Debug.Log("Writinng in SECOND dialogue: " + c);

            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        IsTyping = false;
    }

    public void NextLine()
    {
        StopAllCoroutines();
        textComponent.text = string.Empty;
        if (index < allLines[currentScene].Length - 1)
        {
            index++;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            if(FourthScreen.isGameEnded)
            {
                fourthScene.SetActive(false);
                intro.SetActive(true);
                intro.GetComponent<IntroScript>().InitData();
                return;
            }
            if(currentScene == 0 || currentScene == 1)
            {
                MainScript.step = 1;
                mainScript.changeScene();
            }
            else{
                MainScript.step = 2;
                fourthScene.SetActive(false);
                thirdScene.SetActive(true);
            }
        }
    }

    // Method to change the current scene
    public void ChangeScene(int sceneIndex)
    {
        CheckForLanguageChange();
        if (sceneIndex >= 0 && allLines != null && sceneIndex < allLines.Length)
        {
            currentScene = sceneIndex;
             Debug.Log("Starting dialogue from next scene: ");
            StartDialogue(currentDialogue.text_2);
        }
        else
        {
            Debug.LogWarning("Scene index out of range.");
        }
    }
    public void UpdateDialogue(Dialogue newDialogue)
    {
        currentDialogue = newDialogue;
    }
}

