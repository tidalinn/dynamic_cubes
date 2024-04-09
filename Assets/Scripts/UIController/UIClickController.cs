using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIClickController : MonoBehaviour
{
    public bool IsClickedOnUI(Vector2 touchPosition)
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return false;

        PointerEventData eventPosition = new PointerEventData(EventSystem.current);
        eventPosition.position = new Vector2(touchPosition.x, touchPosition.y);

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventPosition, results);

        return results.Count > 0;
    }
}
