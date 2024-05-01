using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectInventory : MonoBehaviour
{
    [SerializeField] private BoxCollider2D Collider2d;
    private bool isTrigger = false;
    
    public InventoryManager inventory;

    private bool objectAvailable = true;
    public SpriteItem spriteItem;

    public PlayerController playerController;
    public static string objectName = "cle";

    public SoundManager SoundManager;
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
                    playerController.enabled = false;
                    Action();
                }
            }
        }

        playerController.enabled = true;
    }

    public GameObject cle;
    private void Action()
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.isFull[i] == false && objectAvailable)
            {
                inventory.isFull[i] = true;
                inventory.slots_sprite[i].enabled = true;
                inventory.slots_sprite[i].sprite = spriteItem.cle;
                objectAvailable = false;
                cle.SetActive(false);
                inventory.notifications();
                SoundManager.ActiveSounds();
                break;
            }
        }
    }


}