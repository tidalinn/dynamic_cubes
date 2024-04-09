using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedObject : MonoBehaviour
{
    [SerializeField] private Color colorInit = Color.red;
    public float speed = 0.25f;
    int force = 1;
    public Vector3 initialPosition;
    private MeshRenderer meshRenderer;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material.color = colorInit;
    }

    Color RandomColor()
    {
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);
        return new Color(r, g, b, 1f);
    }

    public void ChangeColor()
    {
        meshRenderer.material.color = RandomColor();
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }

    public void MoveAway()
    {
        float distance = force * speed * Time.deltaTime;

        Vector3 currentPosition = transform.position;
        currentPosition = new Vector3(currentPosition.x, currentPosition.y, currentPosition.z + distance);
        transform.position = currentPosition;
    }
}
