using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEditor;
using UnityEngine;

public class UiFollowObject : MonoBehaviour
{
    public Transform target, player;
    public Canvas Canvas;
    public TMP_Text text;
    private float distance;
    CultureInfo ci;
    public CanvasGroup myCanvasGroup;
    void Start()
    {
        ci = CultureInfo.InvariantCulture;
    }


    void Update()
    {
        if (target != null)
        {

            distance = Vector3.Distance(player.position, target.position);
            myCanvasGroup.alpha = distance < 30 ? 1 : 0;
            text.text = distance.ToString("F3", ci);

            RectTransform CanvasRect = Canvas.GetComponent<RectTransform>();
            Vector2 ViewportPosition = Camera.main.WorldToViewportPoint(target.transform.position);
            Vector2 WorldObject_ScreenPosition = new Vector2(
            ((ViewportPosition.x * CanvasRect.sizeDelta.x) - (CanvasRect.sizeDelta.x * 0.5f)),
            ((ViewportPosition.y * CanvasRect.sizeDelta.y) - (CanvasRect.sizeDelta.y * 0.5f)));
            this.GetComponent<RectTransform>().anchoredPosition = WorldObject_ScreenPosition;


        }
    }
}
