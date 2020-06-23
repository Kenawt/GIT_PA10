﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This script manages the behavior of individual obstacle
public class Obstacle : MonoBehaviour
{
    [SerializeField] private float Speed = 3;
    bool addedScore = false;
    void Update()
    {
        if (Player.TrueScore <= 10)
        {
            Speed = 5;
        }
        else
            Speed = 3;
        if (transform.position.x <= 0 && addedScore == false)
        {
            addedScore = true;
            Player.TrueScore++;
        }
        if (transform.position.x <= -8)
            Destroy(gameObject);
        else
            transform.Translate(Vector3.right * Time.deltaTime * -Speed);
    }
}
