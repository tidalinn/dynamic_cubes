using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
[RequireComponent(typeof(RandomPlacementController))]

public class PlacementController : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    private GameObject placedObject;
    private ARRaycastManager aRRaycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private RandomPlacementController randomPlacementController;

    void Awake()
    {
        aRRaycastManager = GetComponent<ARRaycastManager>();
        randomPlacementController = GetComponent<RandomPlacementController>();
    }

    public void RotateToCamera()
    {
        Vector3 lookPosition = Camera.main.transform.position - placedObject.transform.position;
        lookPosition.y = 0;
        placedObject.transform.rotation = Quaternion.LookRotation(lookPosition);
    }

    public void PlaceObject(Touch touch, Mode mode)
    {
        if (aRRaycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;
            Vector3 hitPosePosition = hitPose.position;
            Vector3 objectPosition = new Vector3(hitPosePosition.x, hitPosePosition.y + 0.05f, hitPosePosition.z);

            if (!randomPlacementController.isInstantiated)
                randomPlacementController.InstantiateStaticObjects(objectPosition);

            if ((placedObject == null && mode == Mode.single) || (mode == Mode.multiple))
            {
                GameObject parent = Instantiate(new GameObject("Placed Objects"));
                placedObject = Instantiate(prefab, objectPosition, hitPose.rotation, parent.transform);
                placedObject.GetComponent<SelectedObject>().initialPosition = objectPosition;
            }
            else
            {
                placedObject.transform.position = objectPosition;
                placedObject.transform.rotation = hitPose.rotation;
            }

            RotateToCamera();
        }
    }
}
