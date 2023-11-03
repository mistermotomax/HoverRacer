using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 1f;
    public float killTime = 2f;
    public string targetTag = "Enemy";
    public Vector3 direction = Vector3.up;
    public bool hideOnHit = true;
    void OnEnable()
    {
        if (killTime > 0)
        {
            Invoke("Deactivate", killTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(direction * speed * Time.deltaTime * 60);
    }

    void Deactivate()
    {
        this.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider col)
    {
        //print("bullet ouch " + col.name);
        if (col.tag == targetTag)
        {
            //print("bullet ouch 2");
            col.SendMessage("OnHit", this.transform);

            if (hideOnHit)
                Deactivate();
        }
    }
}
