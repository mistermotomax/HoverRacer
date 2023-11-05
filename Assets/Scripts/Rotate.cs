using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speed = 1f;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = target.position;
        this.transform.Rotate(Vector3.up, Time.deltaTime * speed);
    }
}
