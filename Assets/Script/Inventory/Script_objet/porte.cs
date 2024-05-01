using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class porte : MonoBehaviour
{
    [SerializeField] private BoxCollider2D Collider2d;
    private bool isTrigger = false;
    
    public InventoryManager inventory;

    //private bool objectAvailable = true;
    public SpriteItem spriteItem;

    public PlayerController playerController;
    public Sprite spriteEmpty;
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

    public GameObject effect1;
    public GameObject effect2;

    public GameObject dialogueWindow;
    public GameObject dialogueCable;
    public GameObject dialogueCableRepare;
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
                    if (cable.GetComponent<SpriteRenderer>().sprite == spriteItem.cable)
                    {
                        if (InventoryManager.objectInHand.GetComponent<Image>().sprite == spriteItem.ciseaux)
                        {
                            Action();
                            effect1.SetActive(true);
                            dialogueWindow.SetActive(true);
                            dialogueCable.SetActive(true);
                        }
                    }else if (cable.GetComponent<SpriteRenderer>().sprite == spriteItem.cable_coupe)
                    {
                        if (InventoryManager.objectInHand.GetComponent<Image>().sprite == spriteItem.pansemant)
                        {
                            RepareCable();
                            effect2.SetActive(true);
                            dialogueWindow.SetActive(true);
                            dialogueCableRepare.SetActive(true);
                        }
                            
                        else
                        {
                            ChangeScene();
                        }
                        
                    }
                    
                }
            }
        }

        playerController.enabled = true;
    }

    public GameObject cable;
    private void Action()
    {
        cable.GetComponent<SpriteRenderer>().sprite = spriteItem.cable_coupe;
        InventoryManager.objectInHand.GetComponent<Image>().sprite = spriteEmpty;
        InventoryManager.objectInHand.GetComponent<DragItem>().ResetSlotsPosition();
        lumiere.SetActive(false);
        lumiereGen.SetActive(false);
    }

    public Transform _PositionSalle2;
    public GameObject player; 
    private void ChangeScene()
    {
        player.transform.position = _PositionSalle2.position;
        SoundManager.ActiveSounds();
        player.GetComponent<PlayerController>().PlayerCantMove();
        player.GetComponent<PlayerController>().PlayerCanMove();
        
    }

    public GameObject lumiere;
    public GameObject lumiereGen;
    private void RepareCable()
    {
        cable.GetComponent<SpriteRenderer>().sprite = spriteItem.cable_repare;
        InventoryManager.objectInHand.GetComponent<Image>().sprite = spriteEmpty;
        InventoryManager.objectInHand.GetComponent<DragItem>().ResetSlotsPosition();
        Debug.Log(generateur.geneActive);
        if (generateur.geneActive)
        {
            lumiere.SetActive(true);
            Debug.Log(lumiere.activeInHierarchy);
        }
    }
}