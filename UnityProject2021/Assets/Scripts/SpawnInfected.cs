using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class SpawnInfected: MonoBehaviour {
 
 public float spawntime_initial = 3.0f;
 public float spawntime_min = 1.0f;
 public float spawntime_max = 7.0f;

 
 public GameObject objectToSpawn;

 void Update(){
 
 spawntime_initial -= Time.deltaTime;
 
 if (spawntime_initial <= 0.0f)
 {
    timerEnded();
 }
 
 }
 
 void timerEnded()
 {
    Instantiate(objectToSpawn, new Vector3(Random.Range(-1.5f,1.5f),0.0f,Random.Range(2.0f,2.5f)), Quaternion.identity);
    spawntime_initial = Random.Range(spawntime_min,spawntime_max);
 }
 
 
 }