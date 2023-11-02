using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApproachTrigger : MonoBehaviour
{
    public Transform parentScript;
    void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<Player>() != null)
        {
            parentScript.SendMessage("OnPlayerTriggered");
        }
    }
}
