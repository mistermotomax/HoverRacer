using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        //this.transform.rotation = Quaternion.Lerp(this.transform.rotation, target.rotation, smoothing);
        //this.transform.position = Vector3.Lerp(this.transform.position, target.position, smoothing);

        this.transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velocity, smoothTime);
        var targetRotation = Quaternion.LookRotation(target.transform.position - transform.position);

        // Smoothly rotate towards the target point.
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, smoothTime * Time.deltaTime);
    }
}
