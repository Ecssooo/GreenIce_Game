using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class generateur : MonoBehaviour
{
    [SerializeField] private BoxCollider2D Collider2d;
    private bool isTrigger = false;
    
    public InventoryManager inventory;

    //private bool objectAvailable = true;
    public SpriteItem spriteItem;

    public PlayerController playerController;
    public Sprite spriteEmpty;

    public GameObject dialogueWindow;
    public GameObject dialogueCO2;
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

    public GameObject effect;
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
                    if (balaiCollider.OverlapPoint(mousPos) && balai.activeInHierarchy)
                    {
                        RecupBalai();
                        effect.SetActive(true);
                    }

                    if (InventoryManager.objectInHand.GetComponent<Image>().sprite == spriteItem.defibrilateur)
                    {
                        GeneInteract();
                        dialogueWindow.SetActive(true);
                        dialogueCO2.SetActive(true);
                    }
                }
            }
        }

        playerController.enabled = true;
    }

    public GameObject balai;
    public Collider2D balaiCollider;
    private bool objectAvailable = true;

    public GameObject lumiere;
    private void RecupBalai()
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.isFull[i] == false && objectAvailable)
            {
                inventory.isFull[i] = true;
                inventory.slots_sprite[i].sprite = spriteItem.balai;
                objectAvailable = false;
                
                balai.SetActive(false);
                inventory.notifications();
                break;
            }
        }
    }

    public static bool geneActive = false;
    public SoundManager SoundManager;
    private void GeneInteract()
    {
        lumiere.SetActive(true);
        geneActive = true;
        SoundManager.ActiveSounds();
        Debug.Log("Generateur activé");
        InventoryManager.objectInHand.GetComponent<Image>().sprite = spriteEmpty;
        InventoryManager.objectInHand.GetComponent<DragItem>().ResetSlotsPosition();
    }



}