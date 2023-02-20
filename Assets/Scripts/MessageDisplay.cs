using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageDisplay : MonoBehaviour
{
    public Text messageDisplayText;
    private void Start()
    {
        messageDisplayText = FindObjectOfType<Text>();
    }

    public void DisplayMessage(string message)
    {
        messageDisplayText.text = message;
    }
}
