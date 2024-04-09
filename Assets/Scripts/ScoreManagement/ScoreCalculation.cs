using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCalculation : MonoBehaviour
{
    [SerializeField] private Text text;
    private int score = 0;
    private RandomPlacementController randomPlacementController;

    void Awake()
    {
        randomPlacementController = GetComponent<RandomPlacementController>();
    }

    void UpdateScore() 
    {
        int total = GameObject.FindGameObjectsWithTag("coin").Length;
        int difference = randomPlacementController.total - total;

        if (randomPlacementController.isInstantiated && score != difference)
        {
            score = difference;
            text.text = "Score: " + score.ToString();
        }
    }

    void Update()
    {
        UpdateScore();
    }
}
