﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    float speed = 1.0f;

    GameObject player;
    Rigidbody2D rb;

    void Start()
    {
        player = GameController.Player;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        rb.transform.position = Vector2.MoveTowards(transform.position, player.transform.position, step);
    }
}
