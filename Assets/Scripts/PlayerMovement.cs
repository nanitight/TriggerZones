using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 screenPosition;
    public Vector3 worldPosition;
    //public Plane plane = new Plane(Vector3.down, -2);
    //public LayerMask layersToHit;
    [SerializeField] float movementSpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*
         make movement using keys, page up or down will be used for y-axis, 
         */
        
        //z-axis movement

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(movementSpeed * Time.deltaTime * Vector3.forward);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(movementSpeed * Time.deltaTime * Vector3.back);

        }
        //x-axis movement

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(movementSpeed * Time.deltaTime * Vector3.right);

        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(movementSpeed * Time.deltaTime * Vector3.left);
        }
         
        //y-axis movement
        if (Input.GetKey(KeyCode.PageUp))
        {
            transform.Translate(movementSpeed * Time.deltaTime * Vector3.up);
        }

        if (Input.GetKey(KeyCode.PageDown))
        {
            transform.Translate(movementSpeed * Time.deltaTime * Vector3.down);
        }

        // mouse click postion movement
        if (Input.GetMouseButtonDown(0))
        {
            screenPosition = Input.mousePosition;

            Ray ray = Camera.main.ScreenPointToRay(screenPosition);  
            if ( Physics.Raycast(ray, out RaycastHit hitInfo)){
                worldPosition = hitInfo.point;
            }
            else
            {
                Debug.Log("Nothing hit");
            }


            transform.position = worldPosition;
        }


        }
    /*
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            screenPosition = Input.mousePosition;

            Ray ray = Camera.main.ScreenPointToRay(screenPosition);

            if (plane.Raycast(ray, out float distance))
            {
                worldPosition = ray.GetPoint(distance);
            }

            transform.position = worldPosition;
            //Debug.Log("pos: " + worldPosition.ToString());
        }
    }

      if (Input.GetMouseButtonDown(0))
        {
            screenPosition = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(screenPosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, 2, layersToHit))
            {
                worldPosition = hitInfo.point;
            }
        transform.position = worldPosition;
        } */
}
