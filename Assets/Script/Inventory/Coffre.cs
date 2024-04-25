using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffre : MonoBehaviour
{
    [SerializeField] private BoxCollider2D Collider2d;
    private bool isTrigger = false;
    
    public InventoryManager inventory;
    public PlayerController playerController;
    

    public SpriteItem spriteItem;

    public GameObject cle;
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
            if (Collider2d.OverlapPoint(mousPos))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (!cle.activeInHierarchy)
                    {
                        playerController.enabled = false;
                        Action();
                    }
                }
            }
        }

        playerController.enabled = true;
    }

    private void Action()
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            int j = i;
            if (inventory.isFull[i] == false)
            {
                inventory.isFull[i] = true;
                inventory.isFull[i+1] = true;
                inventory.isFull[i+2] = true;
                inventory.slots_sprite[i].sprite = spriteItem.cle_molette;
                inventory.slots_sprite[i + 1].sprite = spriteItem.angrais;
                inventory.slots_sprite[i + 2].sprite = spriteItem.ciseaux;
                Destroy(gameObject);
                break;
            }
        }
    }
    
}