using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 1f;
    public float killTime = 2f;
    void OnEnable()
    {
        Invoke("Deactivate", killTime);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.up * speed);
    }

    void Deactivate()
    {
        this.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider col)
    {
        print("bullet ouch");
        if (col.GetComponent<Enemy>() != null)
        {
            col.GetComponent<Enemy>().OnHit();
        }
    }
}
