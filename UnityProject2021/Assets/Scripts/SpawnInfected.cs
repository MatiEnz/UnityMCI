using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class SpawnInfected: MonoBehaviour {
 
 public float targetTime = 3.0f;
 
 public GameObject objectToSpawn;

 void Update(){
 
 targetTime -= Time.deltaTime;
 
 if (targetTime <= 0.0f)
 {
    timerEnded();
 }
 
 }
 
 void timerEnded()
 {
    Instantiate(objectToSpawn, new Vector3(Random.Range(-1.5f,1.5f),0.0f,Random.Range(2.0f,2.5f)), Quaternion.identity);
    targetTime = Random.Range(1.0f,10.0f);
 }
 
 
 }