using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusBaseLogic : MonoBehaviour
{
     public GameObject movedObject;
     public float speed_min = 0.1f;
     public float speed_max = 0.2f;
     [SerializeField] private float speed;
     [SerializeField] private float health = 100;
     void Start()
     {
          speed = Random.Range(speed_min,speed_max);
     }
     void Update()
    {
         float step = speed * Time.deltaTime;
         transform.position = Vector3.MoveTowards(transform.position, ARTapToPlace.virusTarget, step);
     }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        {
               Global.count = Global.count+1;
               Debug.Log("Ouch!"); 
               Destroy(movedObject);      
        }

        if (other.gameObject.tag == "Needle")
        {
               Debug.Log("Hit!"); 
               other.transform.parent = gameObject.transform;
               other.GetComponent <ConstantForce > ().force = new Vector3(0f, 0f, 0f);
               other.attachedRigidbody.velocity = Vector3.zero;
               other.transform.LookAt(gameObject.transform);
               health = health - 25;

            if(health <= 0)
            {
                Destroy(movedObject);
            }      
        }
    }
}
