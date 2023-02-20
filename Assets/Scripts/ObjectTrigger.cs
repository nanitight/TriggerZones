
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectTrigger : MonoBehaviour
{
    public TextManager textManager;
    bool redMsg = true, greenMsg = false, yellowMsg = false;
    //public DownCounter ;
    public GameObject redTriggerObject , greenTriggerObject, yellowTriggerObject , countDown;
    private void Start()
    {
        textManager = FindObjectOfType<TextManager>();
        textManager.DisplayCustomMessage("Go to RED trigger");


    }

    private void Update()
    {
        if (redMsg)
        {
            redTriggerObject.GetComponent<TriggerBlinker>().enabled = true;
            greenTriggerObject.GetComponent<TriggerBlinker>().enabled = false;
            yellowTriggerObject.GetComponent<TriggerBlinker>().enabled = false;
        }
        else if (greenMsg)
        {
            redTriggerObject.GetComponent<TriggerBlinker>().enabled = false;
            yellowTriggerObject.GetComponent<TriggerBlinker>().enabled = false;
            greenTriggerObject.GetComponent<TriggerBlinker>().enabled = true;

        }
        else if(yellowMsg)
        {
            redTriggerObject.GetComponent<TriggerBlinker>().enabled = false;
            greenTriggerObject.GetComponent<TriggerBlinker>().enabled = false;
            //yellow trigger blinker is after coruotine
        }
    }



    void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.CompareTag("redTrigger") && redMsg)
        {
            redMsg = false;
            greenMsg = true;
            //Debug.Log("RED ZONE");
            if (textManager != null)
            {
                textManager.DisplayCustomMessage("Go to green trigger");
                greenTriggerObject.SetActive(true);
                redTriggerObject.SetActive(false);
            }
            else
            {
                Debug.Log("Message is not displayed, manager is null");

            }
        }

        if (collision.gameObject.CompareTag("greenTrigger") && greenMsg)
        {
            greenMsg= false;
            yellowMsg = true;
            //Debug.Log("GREEN ZONE, timer: "+countDown.timerRunning);
            if (textManager != null)
            {
                //textManager.ShowTimer();
                //countDown = FindObjectOfType<DownCounter>();
                //while (countDown.timerRunning) { 
                //    Debug.Log("GREEN ZONE, timer: "+countDown.timerRunning);
                //} //hang until timer is done
                StartCoroutine(textManager.ShowTimer("Go to Yellow trigger"));

                StartCoroutine(StartBlinkerSequence());
               
            }
            else
            {
                Debug.Log("Message is not displayed, manager is null");

            }
        }

        //Debug.Log(" ZONE " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("yellowTrigger") && yellowMsg)
        {
            yellowMsg = false;
            redMsg = true;
            if (textManager != null)
            {
                textManager.DisplayCustomMessage("Found ALL the triggers! Game restarting");
                yellowTriggerObject.SetActive(false);
                redTriggerObject.SetActive(true) ;
                Invoke(nameof(ReloadScene), 3f);
            }
            else
            {
                Debug.Log("Message is not displayed, manager is null");

            }

        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }

    private IEnumerator StartBlinkerSequence()
    {
        yield return new WaitUntil(() => countDown.activeSelf == false);
        greenTriggerObject.SetActive(false);
        yellowTriggerObject.SetActive(true);
        yellowTriggerObject.GetComponent<TriggerBlinker>().enabled = true;
    }

}
