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
    public RectTransform hudFollowMe;
    public ScoreUi scoreUi;
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
        scoreUi.OnUpdateScore(200);

        DeactivateMyself();

    }

    void DeactivateMyself()
    {
        hudFollowMe.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
    }

}
