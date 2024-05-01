using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectMovement : MonoBehaviour
{
    public float moveSpeed = 100f; // Vitesse de déplacement de l'ennemi
    public float changeDirectionInterval = 3f; // Intervalle de temps pour changer de direction

    public Rigidbody2D rb;
    private Vector2 movementDirection;
    private float nextDirectionChangeTime;

    void Start()
    {
        StartCoroutine(Wait());
        nextDirectionChangeTime = Time.time + Random.Range(0, changeDirectionInterval);
    }

    void Update()
    {
        if (Time.time >= nextDirectionChangeTime)
        {
            ChooseRandomDirection();
            nextDirectionChangeTime = Time.time + changeDirectionInterval;
        }

        MoveEnemy();
    }

    void ChooseRandomDirection()
    {
        float randomAngle = Random.Range(0f, 360f);
        movementDirection = new Vector2(Mathf.Cos(randomAngle * Mathf.Deg2Rad), Mathf.Sin(randomAngle * Mathf.Deg2Rad));
    }

    void MoveEnemy()
    {
        rb.MovePosition(rb.position + movementDirection * moveSpeed * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "wall")
        {
            MoveEnemy();
        }
    }


    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
        ChooseRandomDirection();
    }
}