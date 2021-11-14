using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public Transform arCamera;
    public GameObject projectile;

    public float shootForce = 30.0f;
    public float shootUp = 7.0f;
    private Vector3 projectileOrigin;

    void Update()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            projectileOrigin = new Vector3(arCamera.position.x, arCamera.position.y-0.2f, arCamera.position.z);
            GameObject bullet = Instantiate(projectile, arCamera.position, arCamera.rotation) as GameObject;
            bullet.GetComponent<Rigidbody>().AddForce(arCamera.forward * shootForce);
            bullet.GetComponent<Rigidbody>().AddForce(arCamera.forward * shootForce);
            bullet.GetComponent<Rigidbody>().AddForce(arCamera.up * shootUp);
        }
    }
}
