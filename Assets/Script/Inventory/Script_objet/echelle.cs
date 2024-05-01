using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class echelle : MonoBehaviour
{
    [SerializeField] private BoxCollider2D Collider2d;
    private bool isTrigger = false;
    
    public InventoryManager inventory;

    public GameObject effect;
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
                        if (InventoryManager.objectInHand.GetComponent<Image>().sprite == spriteItem.balai)
                        {
                            Action();
                            effect.SetActive(true);
                        }
                    
                }
            }
        }

        playerController.enabled = true;
    }

    public GameObject echelleHaut;
    public GameObject echelleBas;
    public SoundManager SoundManager;
    private void Action()
    {
        inventory.slots_sprite[0].sprite = spriteEmpty;
        InventoryManager.objectInHand.GetComponent<DragItem>().ResetSlotsPosition();
        SoundManager.ActiveSounds();
        echelleHaut.SetActive(false);
        echelleBas.SetActive(true);
    }


}