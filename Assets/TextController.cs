using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextController : MonoBehaviour
{
    public TextMeshProUGUI centralText;
    public void UpdateText(string newText)
    {
        centralText.text = newText;
    }
}
