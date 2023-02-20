
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectTrigger : MonoBehaviour
{
    public TextManager textManager;
    bool redMsg = true, greenMsg = false, yellowMsg = false;
    public DownCounter countDown;

    private void Start()
    {
        textManager = FindObjectOfType<TextManager>();
        textManager.DisplayCustomMessage("Go to RED trigger");


    }



    void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.CompareTag("redTrigger") && redMsg)
        {
            redMsg = false;
            greenMsg = true;
            Debug.Log("RED ZONE");
            if (textManager != null)
            {
                textManager.DisplayCustomMessage("Go to green trigger");
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

                //Debug.Log("GREEN ZONE,2 timer: " + countDown.timerRunning);
                //textManager.DisplayCustomMessage("Go to Yellow trigger");
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
