using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public Transform Camera;
    public GameObject projectile;
    public float shootForce = 30.0f;
    public float shootUp = 7.0f;
    public float fireRate = 0.5f;
    private Vector3 projectileOrigin;
    public bool allowFire = true;


    void Update()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            //fireNeedle();
        }
    }

    public void fireNeedle()
    {

        if(allowFire)
        {
            allowFire = false;
            StartCoroutine(Fire());
        }
        //if (Input.GetMouseButton(0) && allowFire)
        //{
        //    StartCoroutine(FireRate());
        //}    
    }
    IEnumerator Fire()
    {
        allowFire = false;
        projectileOrigin = new Vector3(Camera.position.x, Camera.position.y-0.1f, Camera.position.z);
        GameObject bullet = Instantiate(projectile, projectileOrigin, Camera.rotation) as GameObject;
        bullet.GetComponent<Rigidbody>().AddForce(Camera.forward * shootForce);
        bullet.GetComponent<Rigidbody>().AddForce(Camera.up * shootUp);
        yield return new WaitForSeconds(fireRate);
        allowFire = true;
    }    

}

