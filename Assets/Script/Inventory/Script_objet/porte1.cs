using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class porte1 : MonoBehaviour
{
    [SerializeField] private BoxCollider2D Collider2d;
    private bool isTrigger = false;
    
    public InventoryManager inventory;

    //private bool objectAvailable = true;
    public SpriteItem spriteItem;
    public SoundManager SoundManager;
    public PlayerController playerController;
    public Sprite spriteEmpty;
    
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
                    ChangeScene();

                }
            }
        }

        playerController.enabled = true;
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


}