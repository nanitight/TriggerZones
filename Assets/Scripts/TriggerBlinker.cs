using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBlinker : MonoBehaviour
{
    public Color startColor = Color.black, endColor = Color.white;
    public bool blink = false;
    public float colorChangeSpeed = 2f;
    Renderer render;
    private void Start()
    {
        render= GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        render.material.color = Color.Lerp(startColor, endColor, Mathf.PingPong(colorChangeSpeed * Time.time, 1));
    }
}
