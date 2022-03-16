using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonTriggerRounding : Image
{
    private CircleCollider2D collider2d;

    void Start()
    {
        collider2d = GetComponent<CircleCollider2D>();
    }

    public override bool IsRaycastLocationValid(Vector2 screenPoint, Camera eventCamera)
    {
        bool isRay = base.IsRaycastLocationValid(screenPoint, eventCamera);
        if (isRay && (collider2d != null))
        {
            bool isTrig = collider2d.OverlapPoint(screenPoint);
            return isTrig;
        }
        return isRay;
    }
}
