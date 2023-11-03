using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public SplineFollower enemyPrefab;
    public SplinePositioner ringPrefab;
    public int nrTurrets = 30;
    public int nrRings = 20;
    public ObjectPool poolFalcons;
    void Start()
    {
        PlaceAllEnemies();

    }


    void PlaceEnemy()
    {
        Transform newFalcon = poolFalcons.GetPooledObject().transform;
    }

    void PlaceAllEnemies()
    {
        for (int i = 0; i < nrTurrets; i++)
        {
            SplineFollower newTurret = Instantiate(enemyPrefab);
            newTurret.SetPercent(0.1f + (0.9f / nrTurrets) * i);
            newTurret.transform.GetChild(0).localRotation = Quaternion.Euler(
                0,
                0,
                Random.Range(-90f, 90f)
            );
            newTurret.name = "Falcon " + i;
        }

        for (int i = 0; i < nrRings; i++)
        {
            SplinePositioner newRing = Instantiate(ringPrefab);
            newRing.SetPercent(0.05f + (0.85f / nrRings) * i);
            newRing.transform.GetChild(0).localRotation = Quaternion.Euler(
                0,
                0,
                Random.Range(-90f, 90f)
            );
            newRing.name = "Ring " + i;
        }
    }

}
