using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHitTrigger : MonoBehaviour
{
    public string otherTag = "Enemy";
    public Transform parentScript;
    public void OnHit(Transform other)
    {
        if (other.tag == otherTag)
        {
            print(otherTag + " hit me");
            parentScript.SendMessage("OnHit");
        }
    }
}
