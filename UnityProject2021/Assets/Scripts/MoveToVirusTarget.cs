using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToVirusTarget : MonoBehaviour
{
     public GameObject movedObject;

     public float speed_min = 0.1f;
     public float speed_max = 0.2f;
     public float speed;

     void Start()
     {
          speed = Random.Range(speed_min,speed_max);

     }
     void Update()
    {

         float step = speed * Time.deltaTime;
         transform.position = Vector3.MoveTowards(transform.position, ARTapToPlace.virusTarget, step);
         //if(transform.position == ARTapToPlace.virusTarget)
         //{
         //      Global.count++;   
         //      Destroy(movedObject);
         //}
     }

     
    void OnTriggerEnter(Collider other)
    {

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (other.gameObject.tag == "Finish")
        {
            //If the GameObject has the same tag as specified, output this message in the console
               Global.count = Global.count+1;
               Debug.Log("Ouch!"); 
               Destroy(movedObject);
                  
        }
    }
}
