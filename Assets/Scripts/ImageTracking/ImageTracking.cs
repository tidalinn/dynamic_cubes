using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARTrackedImageManager))]

public class ImageTracking : MonoBehaviour
{
    public ARTrackedImageManager aRTrackedImageManager;

    void Awake()
    {
        aRTrackedImageManager = GetComponent<ARTrackedImageManager>();
    }

    void OnEnable()
    {
        aRTrackedImageManager.trackedImagesChanged += OnChanged;
    }

    void OnDisable()
    {
        aRTrackedImageManager.trackedImagesChanged -= OnChanged;
    }

    void OnChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach (var trackedImage in args.added)
        {
            trackedImage.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }
    }
}
