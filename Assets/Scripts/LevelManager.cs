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
    public List<SplineFollower> Falcons = new List<SplineFollower>();
    public SplineFollower PlayerFollower;
    public UiFollowObject hudFalconPrefab;
    public Canvas hudCanvas;
    void Start()
    {
        PlaceAllEnemies();

    }

    void Update()
    {

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
            Falcons.Add(newTurret);

            UiFollowObject newHud = Instantiate(hudFalconPrefab, hudCanvas.transform);
            newHud.target = newTurret.transform.GetChild(0).GetChild(0);
            newTurret.GetComponentInChildren<Enemy>().hudFollowMe = newHud.GetComponent<RectTransform>();

        }
        enemyPrefab.gameObject.SetActive(false);



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
