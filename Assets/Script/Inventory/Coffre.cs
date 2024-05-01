using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coffre : MonoBehaviour
{
    [SerializeField] private BoxCollider2D Collider2d;
    private bool isTrigger = false;
    public GameObject effect;
    public InventoryManager inventory;

    //private bool objectAvailable = true;
    public SpriteItem spriteItem;

    public PlayerController playerController;
    public Sprite spriteEmpty;
    public DragItem dragItem;
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
                    if(InventoryManager.objectInHand != null)
                        if (InventoryManager.objectInHand.GetComponent<Image>().sprite == spriteItem.cle)
                        {
                            Action();
                            effect.SetActive(true);
                            
                        }
                    
                }
            }
        }

        playerController.enabled = true;
    }

    public SoundManager SoundManager;
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
                inventory.slots_sprite[i].sprite = spriteItem.lampe;
                inventory.slots_sprite[i + 1].sprite = spriteItem.angrais;
                inventory.slots_sprite[i + 2].sprite = spriteItem.ciseaux;
                InventoryManager.objectInHand.GetComponent<Image>().sprite = spriteEmpty;
                InventoryManager.objectInHand.GetComponent<DragItem>().ResetSlotsPosition();
                Destroy(gameObject);
                inventory.notifications();
                SoundManager.ActiveSounds();
                break;
            }
        }
    }


}