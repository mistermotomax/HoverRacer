using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplineBullet : MonoBehaviour
{
    public float killTime = 2f;
    void OnEnable()
    {
        Invoke("Deactivate", killTime);
    }

    void Update()
    {

    }

    void Deactivate()
    {
        this.gameObject.SetActive(false);
    }
}
