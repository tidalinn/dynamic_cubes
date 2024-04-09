using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ImageDownloader))]

public class PanelController : MonoBehaviour
{
    [SerializeField] private GameObject controlPanel;
    public string urlDefault = "https://mix-ar.ru/content/ios/marker.jpg";
    private PlacementController placementController;
    private ARTrackedImageManager aRTrackedImageManager;
    private ImageDownloader imageDownloader;

    void Awake()
    {
        placementController = GetComponent<PlacementController>();
        aRTrackedImageManager = GetComponent<ARTrackedImageManager>();
        imageDownloader = GetComponent<ImageDownloader>();
    }

    public void DisplayControlPanel() 
    {
        if (GameObject.FindGameObjectsWithTag("prefab").Length > 0)
            controlPanel.SetActive(true);
        else
            controlPanel.SetActive(false);
    }

    void AddImageToLibrary()
    {
        /*
        Texture2D texture = imageDownloader.texture;

        var referenceLibrary = aRTrackedImageManager.referenceLibrary as MutableRuntimeReferenceImageLibrary;

        byte[] bytesEncode = texture.EncodeToPNG();
        NativeArray<byte> nativeArray = new NativeArray<byte>(bytesEncode, Allocator.Temp);
        NativeSlice<byte> nativeSlice = new NativeSlice<byte>(nativeArray);

        var imageGuid = Guid.NewGuid();
        var guidBytes = imageGuid.ToByteArray();
        var serializableGuid = new UnityEngine.XR.ARSubsystems.SerializableGuid(
            BitConverter.ToUInt64(guidBytes, 0),
            BitConverter.ToUInt64(guidBytes, 0)
        );

        var imageToAdd = new XRReferenceImage(
            new SerializableGuid(BitConverter.ToUInt64(guidBytes, 0), BitConverter.ToUInt64(guidBytes, 8)),
            new SerializableGuid(BitConverter.ToUInt64(guidBytes, 16), BitConverter.ToUInt64(guidBytes, 24)),
            new Vector2(texture.width, texture.height),
            "marker",
            texture
        );

        var jobHandle = referenceLibrary.ScheduleAddImageWithValidationJob(
            nativeSlice,
            new Vector2Int(image.width, texture.height),
            TextureFormat.RGBA32,
            imageToAdd,
            default
        );

        nativeArray.Dispose();
        */
    }

    void Update()
    {
        if (imageDownloader.texture != null)
            AddImageToLibrary();
    }
}
