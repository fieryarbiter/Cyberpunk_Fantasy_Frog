﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;

    private Rigidbody rb;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            rb.velocity = Vector3.zero;
        }
        else
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    //Killing Player
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            collision.gameObject.SetActive(false);
        }
    }
}
