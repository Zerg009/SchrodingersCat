using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;    
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = System.Random;

public class MainScript : MonoBehaviour
{
    public static int step = 0;
    public TextMeshPro actionText;
    public static bool isCatDead = false;
    public DialogueScript dialogueScript;
    public AudioControllerScript audioController;
    String[] scenes = { "first_scene", "second_scene", "third_scene", "fourth_scene" };
    public void changeScene()
    {
        if(step == 2)
        {
            DisableChildObjectByName(scenes[step]);
            if(IsCatAlive())
            {
                EnableChildObjectByName(scenes[1]);

                return;
            }
            EnableChildObjectByName(scenes[3]);

            return;
        }
        if(step == 3)
        {
            DisableChildObjectByName(scenes[step]);
            EnableChildObjectByName(scenes[0]);
            return;
        }

        DisableChildObjectByName(scenes[step++]);
        EnableChildObjectByName(scenes[step]);

    }
    public static bool IsCatAlive()
    {
        // Generate a random number between 0 and 1
        Random random = new Random();
        int randomNumber = random.Next(0, 2);

        // Return true if the random number is 0, false if it is 1
        return randomNumber == 0;
    }
    void DisableChildObjectByName(string name)
    {
        // Iterate through all child GameObjects
        foreach (Transform child in transform)
        {
            // Check if the child GameObject's name matches the specified name
            if (child.gameObject.name == name)
            {
                // Disable the child GameObject
                child.gameObject.SetActive(false);
                Debug.Log("Disabled child: " + name);
                return; // Exit the loop after disabling the child
            }
        }

        // If the child with the specified name is not found
        Debug.LogWarning("Child with name '" + name + "' not found under parent: " + gameObject.name);
    }

    void EnableChildObjectByName(string name)
    {
        // Iterate through all child GameObjects
        foreach (Transform child in transform)
        {
            // Check if the child GameObject's name matches the specified name
            if (child.gameObject.name == name)
            {
                // Enable the child GameObject
                child.gameObject.SetActive(true);
                Debug.Log("Enabled child: " + name);
                return; // Exit the loop after enabling the child
            }
        }

        // If the child with the specified name is not found
        Debug.LogWarning("Child with name '" + name + "' not found under parent: " + gameObject.name);
    }
    void Start()
    {
        step = 0;
    }

    void Update()
    {

    }
}
