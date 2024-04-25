using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickObject : MonoBehaviour
{
    [SerializeField] private BoxCollider2D Collider2d;
    private bool isTrigger = false;

    [SerializeField] private GameObject objectToInteract;

    void OnTriggerEnter2D(Collider2D truc)
    {
        //Si le joueur est en contact avec le bouton
        if (truc.tag == "Player")
        {
            isTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D truc)
    {
        //Si le joueur n'est plus en contact avec le bouton
        if (truc.tag == "Player")
        {
            isTrigger = false;
        }
    }

    private void Update()
    {
        Vector2 mousPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (isTrigger)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if(Collider2d.OverlapPoint(mousPos))
                {
                    
                    Action();
                }
            }
        }
    }


    private void Action()
    {
        Debug.Log("Click");
        objectToInteract.SetActive(false);
    }
}
