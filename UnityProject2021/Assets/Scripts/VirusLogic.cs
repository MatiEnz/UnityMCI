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
     private Animator virusAnimator;
     private ParticleSystem ps;
     void Start()
     {
        speed = Random.Range(speed_min,speed_max);
        Instantiate(spawnEffect, transform.position, Quaternion.identity);
        virusAnimator = GetComponentInChildren<Animator>(); 
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
               GetComponent<Rigidbody>().velocity = Vector3.zero;
               virusAnimator.SetTrigger("finish"); 
               Debug.Log("Ouch!"); 
               StartCoroutine(Wait());      
        }

        if (other.gameObject.tag == "Needle")
        {

               Destroy(other.gameObject);
               Debug.Log("Animate!"); 
               GetComponent<Rigidbody>().AddForce(transform.forward * -5f);
               Instantiate(explosionEffect, other.gameObject.transform.position, Quaternion.identity);
               health = health - 34;

            if(health <= 0)
            {
                StartCoroutine(Wait());

                virusAnimator.SetBool("dead",true);  
            } 
            else
            {
                virusAnimator.SetTrigger("hit"); 
            }
              
        }
    }

    IEnumerator Wait()
    {   
        GetComponent<SphereCollider>().enabled = false;
        yield return new WaitForSeconds(1);
        foreach (MeshRenderer component in gameObject.GetComponentsInChildren<MeshRenderer>())
            {
                component.enabled = false;
            }
        ps = GetComponent<ParticleSystem>();
        ps.Stop();
	    yield return new WaitForSeconds(4);
        Destroy(movedObject);
    }

    
}
