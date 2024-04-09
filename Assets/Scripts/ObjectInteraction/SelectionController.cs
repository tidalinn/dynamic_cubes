using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionController : MonoBehaviour
{
    public SelectedObject selectedObject;

    public bool IsSelected(Touch touch)
    {
        Ray ray = Camera.main.ScreenPointToRay(touch.position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            selectedObject = hit.transform.GetComponent<SelectedObject>();
            return selectedObject != null;
        }
        
        return false;
    }
}
