using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class SpawnInfected: MonoBehaviour {
 
 private float spawntime_countdown = 3.0f;
 public float spawntime_min = 1.0f;
 public float spawntime_max = 7.0f;

 public GameObject objectToSpawn;
 public float spawnX;
 public float spawnY;
 public float spawnZ;

 void Update(){
 
 spawntime_countdown -= Time.deltaTime;
 
 if (spawntime_countdown <= 0.0f)
 {
    timerEnded();
 }
 
 }
 
 void timerEnded()
 {
    spawnX = ARTapToPlace.virusTarget.x + Random.Range(-1.5f,1.5f);
    spawnY = ARTapToPlace.virusTarget.y + Random.Range(0.0f,0.5f);
    spawnZ = ARTapToPlace.virusTarget.z + Random.Range(2.0f,2.5f);

    Instantiate(objectToSpawn, new Vector3(spawnX,spawnY,spawnZ), Quaternion.identity);
    spawntime_countdown = Random.Range(spawntime_min,spawntime_max);
 }
 
 
 }