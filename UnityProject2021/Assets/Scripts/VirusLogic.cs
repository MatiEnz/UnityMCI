using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusLogic : MonoBehaviour
{
     public GameObject movedObject;
     public GameObject targetObject;
     public GameObject explosionEffect;
     public GameObject spawnEffect;
     public float speed_min = 0.1f;
     public float speed_max = 0.2f;
     [SerializeField] private float speed;
     [SerializeField] private float health = 100;
     private ParticleSystem ps;
     void Start()
     {
        speed = Random.Range(speed_min,speed_max);
        Instantiate(spawnEffect, transform.position, Quaternion.identity);
     }
     void Update()
    {
         float step = speed * Time.deltaTime;
         //transform.position = Vector3.MoveTowards(transform.position, Placer.newOrigin.position, step);
         transform.LookAt(Placer.newOrigin.position);
     }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        {
               Global.count = Global.count+1;
               Debug.Log("Ouch!"); 
               StartCoroutine(Wait());      
        }

        if (other.gameObject.tag == "Needle")
        {
 
               Destroy(other.gameObject);
               GetComponent<Rigidbody>().AddForce(transform.forward * -5f);
               Instantiate(explosionEffect, other.gameObject.transform.position, Quaternion.identity);
               speed = speed - 0.033f;
               health = health - 34;

            if(health <= 0)
            {
                StartCoroutine(Wait());
            }      
        }
    }

    IEnumerator Wait()
    {   
        foreach (MeshRenderer component in gameObject.GetComponentsInChildren<MeshRenderer>())
            {
                component.enabled = false;
            }
        GetComponent<SphereCollider>().enabled = false;
        ps = GetComponent<ParticleSystem>();
        ps.Stop();
	    yield return new WaitForSeconds(5);
        Destroy(movedObject);
    }
}
