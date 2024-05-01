using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class echelle1 : MonoBehaviour
{
    [SerializeField] private BoxCollider2D Collider2d;
    private bool isTrigger = false;
    
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
                    Action();

                }
            }
        }

        playerController.enabled = true;
    }

    public Transform positionSalle3;
    public GameObject player;
    public SoundManager SoundManager;
    private void Action()
    {
        player.transform.position = positionSalle3.position;
        SoundManager.ActiveSounds();
        player.GetComponent<PlayerController>().PlayerCantMove();
        player.GetComponent<PlayerController>().PlayerCanMove();
    }


}