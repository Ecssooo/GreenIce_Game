using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class DetectMous : MonoBehaviour
{
    public BoxCollider2D _collider2D;
    public Canvas gameOverScreen;
    public ObjectMovement objectMovement;
    public GameObject lumiere;
    void Update()
    {
        Vector2 mousPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (!_collider2D.OverlapPoint(mousPos))
        {
            gameOverScreen.gameObject.SetActive(true);
            objectMovement.enabled = false;
            lumiere.SetActive(false);
            StartCoroutine(ReloadScene());
        }
    }

    IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);;
    }
}
