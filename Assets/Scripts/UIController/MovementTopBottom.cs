using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementController))]

public class MovementTopBottom : MonoBehaviour
{
    public int force;
    private MovementController movementController;

    void Awake()
    {
        movementController = GetComponent<MovementController>();
    }

    void Update()
    {
        movementController.PressTopBottom(force);
    }
}
