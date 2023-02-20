using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform playerTransform;
    [SerializeField] float moveSpeed = 10f, yRotationUpLimit = 0.4f , yRotationLowLimit = -0.17f  ; 
    Vector3 offset; 
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - playerTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newCamPosition = playerTransform.position + offset;
        transform.position = Vector3.Lerp(transform.position,newCamPosition, moveSpeed*Time.deltaTime );

        if (Input.GetKey(KeyCode.A))
        {

            if (transform.rotation.y > yRotationLowLimit && transform.rotation.y < yRotationUpLimit+0.1f)
            {
                transform.Rotate(0, -1 * moveSpeed * Time.deltaTime, 0);
                //Debug.Log("Rotation A: " + transform.rotation.y);
            }
           
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (transform.rotation.y > yRotationLowLimit-0.1f && transform.rotation.y < yRotationUpLimit)
            {
                transform.Rotate(0, moveSpeed * Time.deltaTime, 0);
                //Debug.Log("Rotation D: " + transform.rotation.y);
            }

        }
    }
}
