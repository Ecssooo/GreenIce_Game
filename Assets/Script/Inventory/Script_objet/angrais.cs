using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class angrais : MonoBehaviour
{
    [SerializeField] private BoxCollider2D Collider2d;
    private bool isTrigger = false;
    
    public InventoryManager inventory;

    //private bool objectAvailable = true;
    public SpriteItem spriteItem;
    public GameObject effect;
    public GameObject effectCaisse;
    public PlayerController playerController;
    public Sprite spriteEmpty;
    public static string objectName = "angrais";
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
                        if (InventoryManager.objectInHand.GetComponent<Image>().sprite == spriteItem.angrais)
                        {
                            Action();
                            effect.SetActive(true);
                            effectCaisse.SetActive(true);
                            dialogueWindow.SetActive(true);
                            dialoguePlante.SetActive(true);
                        }
                    
                }
            }
        }

        playerController.enabled = true;
    }

    public GameObject dialogueWindow;
    public GameObject dialoguePlante;
    
    
    public GameObject plante;
    public GameObject caisse;
    public SoundManager SoundManager;
    public SoundManager fracas;
    private void Action()
    {
        InventoryManager.objectInHand.GetComponent<Image>().sprite = spriteEmpty;
        InventoryManager.objectInHand.GetComponent<DragItem>().ResetSlotsPosition();
        SoundManager.ActiveSounds();
        fracas.ActiveSounds();
        plante.SetActive(true);
        caisse.SetActive(false);

    }


}