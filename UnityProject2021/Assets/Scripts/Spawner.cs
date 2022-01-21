using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class Spawner: MonoBehaviour {
 
 public float spawntime_min; // default:1
 public float spawntime_max; // default:7
 private float spawntime_countdown = 3.0f;
 public GameObject objectToSpawn;
 private float spawnX;
 private float spawnY;
 private float spawnZ;
 private Vector3 spawnPosition;
 [SerializeField] private bool spawnInLine = false;


  void Start()
  {
    if(StartMenu.current_level == 1)
    {
      spawntime_min = 3.0f; 
      spawntime_max = 8.0f; 
    }
    if(StartMenu.current_level == 2)
    {
      spawntime_min = 2.0f; 
      spawntime_max = 7.0f; 
    } 
    if(StartMenu.current_level == 3)
    {
      spawntime_min = 1.0f; 
      spawntime_max = 6.0f; 
    }       
  }

 void Update()
  {
 
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
      spawnY = Random.Range(0.1f,0.6f);
      spawnZ = Random.Range(2.0f,2.5f);
      spawnPosition = transform.TransformPoint(spawnX,spawnY,spawnZ);
    }

    Instantiate(objectToSpawn, spawnPosition, transform.rotation);
    spawntime_countdown = Random.Range(spawntime_min,spawntime_max);
 }
 
 
 }