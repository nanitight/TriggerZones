using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundryConstraint : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] lowerXConstraint , lowerYConstraint, lowerZConstraint, higherXConstraint, higherYConstraint, higherZConstraint; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CheckIfPlayerOutOfBounds(Transform player)
    {
        bool outOfBounds = false; 
        if (player != null)
        {
            //x-check
            for (int i = 0; i < lowerXConstraint.Length && outOfBounds==false; i++)
            {
                // lower check 
                if (player.position.x  < lowerXConstraint[i].position.x ){
                    float playerZ = player.position.z;
                    //check if player z is negative,-> make it positive so we find the difference
                    if (player.position.z < 0){
                        playerZ = -playerZ; 
                    }
                    if (playerZ - lowerXConstraint[i].position.z > 0 )
                    {
                        outOfBounds = true;
                    } 
                }
            }

            for (int i = 0; i < higherXConstraint.Length && outOfBounds == false; i++)
            {
                //higher check
                //if ()
            }


            //y-check 
            
            //z-check
        }
        else
        {
            Debug.Log("Player is not selected: "+player);
        }
    }
}
