using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreAnimtions : MonoBehaviour
{
     private Animator coreAnimator;

     void Update()
     {
         StartCoroutine(Wait());
     }
    IEnumerator Wait() 
    {
        coreAnimator = GetComponentInChildren<Animator>();   
        yield return new WaitForSeconds(3);
        int r = Random.Range(0,6);
        coreAnimator.SetInteger("randy", r);
        Debug.Log(r.ToString());   
    }
}
