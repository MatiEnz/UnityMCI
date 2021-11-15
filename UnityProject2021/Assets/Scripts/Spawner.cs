using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class Spawner: MonoBehaviour {
 
 public float spawntime_min = 1.0f;
 public float spawntime_max = 7.0f;
 private float spawntime_countdown = 3.0f;
 public GameObject objectToSpawn;
 private float spawnX;
 private float spawnY;
 private float spawnZ;
 private Vector3 spawnPosition;
 [SerializeField] private bool spawnInLine = false;

 void Update(){
 
 spawntime_countdown -= Time.deltaTime;
 
 if (spawntime_countdown <= 0.0f)
 {
    timerEnded();
 }
 
 }
 
 void timerEnded()
 {
    if(spawnInLine)
    {
      spawnX = 0.0f;
      spawnY = 0.1f;
      spawnZ = 2.0f;
      spawnPosition = transform.TransformPoint(spawnX,spawnY,spawnZ);
    }
    else
    {
      spawnX = Random.Range(-1.5f,1.5f);
      spawnY = Random.Range(0.1f,0.5f);
      spawnZ = Random.Range(2.0f,2.5f);
      spawnPosition = transform.TransformPoint(spawnX,spawnY,spawnZ);
    }

    Instantiate(objectToSpawn, spawnPosition, transform.rotation);
    //Instantiate(objectToSpawn, new Vector3(spawnX,spawnY,spawnZ), transform.rotation, gameObject.transform);
    spawntime_countdown = Random.Range(spawntime_min,spawntime_max);
 }
 
 
 }