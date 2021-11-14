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
      spawnX = transform.position.x + 0.0f;
      spawnY = transform.position.y + 0.1f;
      spawnZ = transform.position.z + 2.0f;
    }
    else
    {
      spawnX = transform.position.x + Random.Range(-1.5f,1.5f);
      spawnY = transform.position.y + Random.Range(0.15f,0.5f);
      spawnZ = transform.position.z + Random.Range(2.0f,2.5f);
    }

    Instantiate(objectToSpawn, new Vector3(spawnX,spawnY,spawnZ), Quaternion.identity);
    spawntime_countdown = Random.Range(spawntime_min,spawntime_max);
 }
 
 
 }