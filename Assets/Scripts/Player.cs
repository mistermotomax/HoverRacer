using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Transform follower, orbit, ship, cannon;
    public float steerForce = 10f;
    public float direction;
    public float turnMax = 25f;
    public float smoothing = 5;

    [Header("Shooting")]
    public ObjectPool bulletPool, bulletSplinePool;
    public float fireDelay = 1f;
    float fireDelayTotal = 1f;
    void Start()
    {

    }

    void Steer()
    {
        direction = -Input.GetAxis("Horizontal");
        orbit.Rotate(Vector3.forward, 10 * Time.deltaTime * direction * steerForce);
    }


    void Update()
    {
        Steer();
        //ship.Rotate(Vector3.up, direction);
        ship.localRotation = Quaternion.Lerp(ship.localRotation, Quaternion.Euler(0, direction * turnMax, 0), Time.deltaTime * smoothing);

        if (Input.GetButton("Fire1"))
        {
            if (fireDelayTotal < Time.time)
            {
                Shoot();
                fireDelayTotal = Time.time + fireDelay;
            }

        }
    }

    void Shoot()
    {
        Transform bullet = bulletPool.GetPooledObject().transform;
        bullet.position = cannon.position;
        bullet.rotation = cannon.rotation;
        bullet.gameObject.SetActive(true);
        /* Transform bulletSpline = bulletSplinePool.GetPooledObject().transform;
        bulletSpline.gameObject.SetActive(true);
        bulletSpline.GetComponent<SplineFollower>().SetPercent(this.GetComponent<SplineFollower>().GetPercent());
        bulletSpline.GetChild(0).localRotation = Quaternion.Euler(0, 0, orbit.rotation.eulerAngles.z);
        //bulletSpline.GetComponent<SplineFollower>().motion.rotationOffset = new Vector3(0, 0, 180);// this.transform.rotation.z);
        //bulletSpline.rotation = Quaternion.Euler(270, -90, 180);// this.transform.rotation.eulerAngles.z); */

    }
}
