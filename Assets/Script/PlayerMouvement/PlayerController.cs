using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 target;
    public static bool _canMove = true;

    private void Start()
    {
        target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (_canMove)
        {
            Debug.Log("Test");
           Vector2 mousPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

           if(Input.GetMouseButtonDown(0))
           {
               
               target = new Vector2(mousPos.x, transform.position.y);
           }
           transform.position = Vector2.MoveTowards(transform.position, target, 5 * Time.deltaTime);
           
        }
        
    }

    public static void PlayerCantMove()
    {
        _canMove = false;
    }

    public static void PlayerCanMove()
    {
        _canMove = true;
    }
}