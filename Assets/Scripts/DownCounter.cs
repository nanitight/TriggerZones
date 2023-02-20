
using UnityEngine;
using UnityEngine.UI;
public class DownCounter : MonoBehaviour
{
    [SerializeField] float timerUpLimit;
    public Text timerDisplayed;
    public bool timerRunning = false;

   
    void Start()
    {
        timerRunning = true;
        timerUpLimit = 11;
        //Debug.Log("DownCounter started");

    }
    // Update is called once per frame
    void Update()
    {
        // 10 times, each second, change the time, dec by 1
       if (timerRunning)
       {

            if (Mathf.FloorToInt(timerUpLimit % 60) >= 0.8f)
            {
                timerUpLimit -= Time.deltaTime;
            }
            else
            {
                timerRunning = false;
                timerUpLimit= 0;
            }
            float seconds = Mathf.FloorToInt(timerUpLimit % 60);
            timerDisplayed.text = seconds.ToString("0");
        

       }
        else
        {
            this.enabled= false;
        }

    }

    public bool GetTimerRunning()
    {
        return timerRunning;
    }


}
