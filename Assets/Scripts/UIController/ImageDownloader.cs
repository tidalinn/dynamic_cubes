using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ImageDownloader : MonoBehaviour
{
    [SerializeField] private InputField inputField;
    [SerializeField] private Image imageField;
    public string url = "https://mix-ar.ru/content/ios/marker.jpg";
    public Texture2D texture;

    IEnumerator HighlightInput()
    {
        inputField.image.color = Color.red;
        yield return new WaitForSeconds(1f);
        inputField.image.color = Color.white;
    }

    IEnumerator DownloadImageFromUrl(string url)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || 
            request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log(request.error);
            StartCoroutine(HighlightInput());
        }
        else
        {
            Texture2D texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            Sprite textureSprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            imageField.sprite = textureSprite;
        }
    }

    public void LoadImageFromUrl()
    {
        if (string.IsNullOrEmpty(url))
        {
            Debug.Log("Input is null");
            HighlightInput();
        }
        else
        {
            StartCoroutine(DownloadImageFromUrl(inputField.text));
        }
    }
}
