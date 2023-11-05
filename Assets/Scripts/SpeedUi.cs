using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpeedUi : MonoBehaviour
{
    private TMP_Text text;
    public int speedMin = 908;
    public int speedMax = 978;
    private int speed = 914;
    void Start()
    {
        text = GetComponent<TMP_Text>();
        StartCoroutine(SetSpeed());
    }


    IEnumerator SetSpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            int modifier = Random.Range(0, 2) == 0 ? -1 : 1;
            if (modifier == -1 && speed > speedMin)
            {
                speed--;
            }
            if (modifier == 1 && speed < speedMax)
            {
                speed++;
            }
            text.text = speed.ToString();
        }
    }
}
