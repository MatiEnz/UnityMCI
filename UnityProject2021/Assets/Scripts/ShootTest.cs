using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTest : MonoBehaviour
{

    public Transform arCamera;
    public GameObject projectile;

    public float shootForce = 500.0f;
    public float shootUp = 20.0f;
    private Vector3 projectileOrigin;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            projectileOrigin = new Vector3(arCamera.position.x, arCamera.position.y-0.1f, arCamera.position.z-0.05f);
            GameObject bullet = Instantiate(projectile, projectileOrigin, arCamera.rotation) as GameObject;
            bullet.GetComponent<Rigidbody>().AddForce(arCamera.forward * shootForce);
            bullet.GetComponent<Rigidbody>().AddForce(arCamera.up * shootUp);
        }
    }
}
