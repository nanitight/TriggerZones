using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public GameObject customMessage, countDown;
    public Text msgObject;
    //public DownCounter downCounterObject;

    public void DisplayCustomMessage(string message, float timeConstraint = 5)
    {
        customMessage.SetActive(true);
        //customMessage.
        msgObject.text = message;
        Invoke(nameof(CloseMessage), timeConstraint);
    }


    public void CloseMessage()
    {
        customMessage.SetActive(false);
    }

    void CloseTimer()
    {
        countDown.SetActive(false);
    }

    public IEnumerator ShowTimer(string msg = "") {
        countDown.SetActive(true);
        //downCounterObject = GameObject.Find("CountDown").GetComponent<DownCounter>();

        //Debug.Log(" timer runnning " + downCounterObject.GetTimerRunning());

        Invoke(nameof(CloseTimer), 10);
        yield return new WaitForSecondsRealtime(10f);

        //yield return new WaitUntil(()=> downCounterObject.GetTimerRunning() == false);

        if (msg.Length> 0)
        {
            DisplayCustomMessage(msg);
        }
        //Debug.Log("EnD timer");
    }


}
