using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player, orbitRoot;
    public SplineFollower playerFollower;
    public SplineFollower splineFollower;
    public ObjectPool poolExplosion;
    void Start()
    {
        playerFollower = player.GetComponent<Player>().follower.GetComponent<SplineFollower>();
    }

    public void OnHit(Transform other)
    {
        Transform explosion = poolExplosion.GetPooledObject().transform;
        explosion.transform.position = this.transform.position;
        explosion.gameObject.SetActive(true);
        explosion.GetComponent<ParticleSystem>().Play();

        DeactivateMyself();

    }

    void DeactivateMyself()
    {
        this.gameObject.SetActive(false);
    }

}
