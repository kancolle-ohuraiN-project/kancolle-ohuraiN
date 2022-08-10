using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonTriggerRounding : Image
{
    private CircleCollider2D collider2d;

#pragma warning disable CS0114 // 成员隐藏继承的成员；缺少关键字 override
    void Start()
#pragma warning restore CS0114 // 成员隐藏继承的成员；缺少关键字 override
    {
        collider2d = GetComponent<CircleCollider2D>();
    }

    override public bool IsRaycastLocationValid(Vector2 screenPoint, Camera eventCamera)
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
