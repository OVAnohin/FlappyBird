using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BirdMover))]
public class Bird : MonoBehaviour
{
    private BirdMover _birdMover;
    private int _score;

    private void Start()
    {
        _birdMover = GetComponent<BirdMover>();
    }

    public void ResetPlayer()
    {
        _score = 0;
        _birdMover.ResetBird();
    }

    public void Die()
    {
        Debug.Log("I am Dying");
        Time.timeScale = 0;
    }

    internal void IncreaseScore()
    {
        _score++;
    }
}
