﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIJump : MonoBehaviour
{

    float dirX;

    [SerializeField]
    float moveSpeed = 3f;

    Rigidbody rb;

    bool facingRight = false;

    Vector3 localScale;

    // Use this for initialization
    void Start()
    {
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody>();
        dirX = -1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -9f)
            dirX = 1f;
        else if (transform.position.x > 9f)
            dirX = -1f;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
    }

    void LateUpdate()
    {
        CheckWhereToFace();
    }

    void CheckWhereToFace()
    {
        if (dirX > 0)
            facingRight = true;
        else if (dirX < 0)
            facingRight = false;

        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            localScale.x *= -1;

        transform.localScale = localScale;
    }

    void OntriggerEnter(Collider col)
    {
        switch (col.tag)
        {

            case "BigStump":
                rb.AddForce(Vector2.up * 600f);
                break;

            case "SmallStump":
                rb.AddForce(Vector2.up * 450f);
                break;
        }
    }

}
