using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum Direction
{
    LeftRight,
    AwayCloser,
    TopBottom
}

public class MovementController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject[] prefabs;
    public float speedInit = 0.25f;
    public int speedTimes = 2;
    private bool isMoving = false;
    public float maxDistance = 0.1f;

    public void OnPointerDown(PointerEventData eventData)
    {
        isMoving = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isMoving = false;
    }

    private void Press(Direction direction, int force)
    {
        if (isMoving)
        {
            prefabs = GameObject.FindGameObjectsWithTag("prefab");

            float speed = speedInit;

            if (speed != speedInit * speedTimes && GameObject.FindGameObjectsWithTag("tracked").Length > 0)
                speed *= speedTimes;

            float distance = force * speed * Time.deltaTime;
            float distanceComparison = 0f;
            
            foreach(var prefab in prefabs)
            {
                SelectedObject selectedObject = prefab.GetComponent<SelectedObject>();
                Vector3 currentPosition = prefab.transform.position;

                if (direction == Direction.LeftRight)
                {
                    prefab.transform.Translate(distance, 0, 0);
                    distanceComparison = selectedObject.initialPosition.x - currentPosition.x;
                }

                if (direction == Direction.AwayCloser)
                {
                    prefab.transform.Translate(0, 0, distance);
                    distanceComparison = selectedObject.initialPosition.z - currentPosition.z;
                }

                if (direction == Direction.TopBottom)
                {
                    prefab.transform.Translate(0, distance, 0);
                    distanceComparison = selectedObject.initialPosition.y - currentPosition.y;
                }

                if (Mathf.Abs(distanceComparison) >= maxDistance)
                {
                    selectedObject.DestroyObject();
                    isMoving = false;
                }
            }
        }
    }

    public void PressLeftRight(int force)
    {
        Press(Direction.LeftRight, force);
    }

    public void PressAwayCloser(int force)
    {
        Press(Direction.AwayCloser, force);
    }

    public void PressTopBottom(int force)
    {
        Press(Direction.TopBottom, force);
    }
}