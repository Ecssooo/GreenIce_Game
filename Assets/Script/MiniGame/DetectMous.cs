using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DetectMous : MonoBehaviour
{
    private BoxCollider2D _collider2D;
    public Canvas gameOverScreen;
    public ObjectMovement objectMovement;
    private void Start()
    {
        _collider2D = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        Vector2 mousPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (!_collider2D.OverlapPoint(mousPos))
        {
            gameOverScreen.gameObject.SetActive(true);
            objectMovement.enabled = false;
        }
    }
    
}
