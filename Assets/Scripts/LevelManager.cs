using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public SplineFollower enemyPrefab;
    public int nrTurrets = 30;
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
    }

}
