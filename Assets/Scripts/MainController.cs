using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Mode
{
    single,
    multiple
}

[RequireComponent(typeof(SelectionController))]
[RequireComponent(typeof(PlacementController))]
[RequireComponent(typeof(PanelController))]
[RequireComponent(typeof(UIClickController))]
[RequireComponent(typeof(ImageTracking))]

public class MainController : MonoBehaviour
{
    private SelectionController selectionController;
    private PlacementController placementController;
    private PanelController panelController;
    private UIClickController uIClickController;

    void Awake()
    {
        selectionController = GetComponent<SelectionController>();
        placementController = GetComponent<PlacementController>();
        panelController = GetComponent<PanelController>();
        uIClickController = GetComponent<UIClickController>();
    }

    void ManageObjects(Mode mode)
    {
        if (Input.touchCount > 0)
        {        
            Touch touch = Input.GetTouch(0);

            bool uiIsClicked = uIClickController.IsClickedOnUI(touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                if (!uiIsClicked)
                {
                    if (selectionController.IsSelected(touch))
                        selectionController.selectedObject.ChangeColor();
                    else
                        placementController.PlaceObject(touch, mode);
                }
            }
            
            if (touch.phase == TouchPhase.Stationary)
            {
                if (!uiIsClicked)
                {
                    if (selectionController.IsSelected(touch))
                        selectionController.selectedObject.MoveAway();
                }
            }
        }
    }

    void Update()
    {
        panelController.DisplayControlPanel();
        ManageObjects(Mode.multiple);
    }
}