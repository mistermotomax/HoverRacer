using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using Unity.Mathematics;
using UnityEngine;
using DG.Tweening;
using Cinemachine;

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
    [Header("Health")]
    public float health = 100;
    public RectTransform healthbar;
    public Renderer shieldRenderer;
    public Color damageColor;
    public CanvasGroup vignette;
    public CinemachineVirtualCamera vmcam;
    Sequence seqDamage;
    void Start()
    {
        shieldRenderer.materials[0].SetColor("_BaseColor", new Color(damageColor.r, damageColor.g, damageColor.b, 0f));
        vignette.alpha = 0;
        seqDamage = DOTween.Sequence();
        seqDamage.SetRecyclable(true);
        seqDamage.SetAutoKill(false);
        seqDamage.SetLoops(2, LoopType.Yoyo);
        seqDamage.Append(shieldRenderer.material.DOColor(damageColor, "_BaseColor", .2f));
        seqDamage.Join(vignette.DOFade(1, 0.2f).SetLoops(2, LoopType.Yoyo));
        seqDamage.Pause();
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
        ship.localRotation = Quaternion.Lerp(ship.localRotation, Quaternion.Euler(90, direction * turnMax, 0), Time.deltaTime * smoothing);

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

    void OnDamage(float damage)
    {
        health -= damage;
        healthbar.localScale = new Vector3(health / 100f, 1, 1);
        vmcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 3;
        seqDamage.Restart();
        Invoke("OnDamageStop", 0.5f);
    }
    void OnDamageStop()
    {
        vmcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
    }

    public void OnHit()
    {
        OnDamage(3);
    }
}
