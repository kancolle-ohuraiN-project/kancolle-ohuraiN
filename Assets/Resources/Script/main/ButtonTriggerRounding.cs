using UnityEngine;
using UnityEngine.UI;

public class ButtonTriggerRounding : Image
{
    private CircleCollider2D collider2d;

#pragma warning disable CS0114 // ��Ա���ؼ̳еĳ�Ա��ȱ�ٹؼ��� override

    private void Start()
#pragma warning restore CS0114 // ��Ա���ؼ̳еĳ�Ա��ȱ�ٹؼ��� override
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