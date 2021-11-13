using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToOrigin : MonoBehaviour
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
         transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, step);
         if(transform.position == Vector3.zero)
         {
               Global.count++;   
               Destroy(movedObject);
         }
     }
}
