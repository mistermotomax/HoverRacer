using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Dreamteck.Splines;


public class EnemyScouter : MonoBehaviour
{
    Enemy enemy;

    void Awake()
    {
        enemy = this.GetComponent<Enemy>();
        this.transform.localPosition = new Vector3(0, 2f, 0);
    }
    IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
        //StartCoroutine(CheckDistanceToPlayer());
        //enemy.splineFollower.SetPercent(0.1f);
    }

    void StartShip()
    {
        this.transform.DOLocalMoveY(3, 1f);
        enemy.orbitRoot.DOLocalRotate(
            new Vector3(0, 0, Random.Range(45, 180)/*  * Random.Range(0, 2) == 0 ? -1 : 1 */), 50f, RotateMode.FastBeyond360)
            .SetLoops(-2, LoopType.Yoyo).SetSpeedBased().SetEase(Ease.InOutSine);
        enemy.splineFollower.followSpeed = enemy.playerFollower.followSpeed;
    }

    /*     IEnumerator CheckDistanceToPlayer()
        {
            while (true)
            {
                float distance = (float)enemy.splineFollower.GetPercent() - (float)enemy.playerFollower.GetPercent();
                //print(enemy.splineFollower.name + " Dist: " + distance);
                yield return new WaitForSeconds(0.1f);
            }
        } */

    public void OnPlayerTriggered()
    {
        StartShip();
    }
}
