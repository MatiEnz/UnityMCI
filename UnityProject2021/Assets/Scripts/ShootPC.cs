using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPC : MonoBehaviour
{

    public Transform arCamera;
    public GameObject projectile;
    public bool allowFire = false;
    public float shootForce = 30.0f;
    public float shootUp = 7.0f;
    public float fireRate = 0.5f;
    private Vector3 projectileOrigin;
    

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            fireNeedle();
        }
    }

    public void fireNeedle()
    {
        if (Input.GetMouseButton(0) && allowFire)
        {
            StartCoroutine(FireRate());
        }

        IEnumerator FireRate()
        {
            allowFire = false;
            projectileOrigin = new Vector3(arCamera.position.x, arCamera.position.y-0.1f, arCamera.position.z);
            GameObject bullet = Instantiate(projectile, projectileOrigin, arCamera.rotation) as GameObject;
            bullet.GetComponent<Rigidbody>().AddForce(arCamera.forward * shootForce);
            bullet.GetComponent<Rigidbody>().AddForce(arCamera.up * shootUp);
            yield return new WaitForSeconds(fireRate);
            allowFire = true;
        }
    }


}