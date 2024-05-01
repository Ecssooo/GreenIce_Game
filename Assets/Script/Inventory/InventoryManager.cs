using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public Canvas inventory;
    private bool _inventoryIsActive = false;
    public bool[] isFull;
    public GameObject[] slots;
    public Image[] slots_sprite;
    public PlayerController playerController;
    public RectTransform[] slots_position;
    
    public static GameObject objectInHand;
    public SoundManager SoundManager;
    
    public void ActiveInventory()
    {
        inventory.gameObject.SetActive(!_inventoryIsActive);
        if (!_inventoryIsActive)
        {
            playerController.PlayerCantMove();
            if (notifPoints.activeInHierarchy)
            {
                notifPoints.SetActive(false);
            }
            SoundManager.ActiveSounds();
        }
        else if(_inventoryIsActive)
        {
            playerController.PlayerCanMove();
            SoundManager.ActiveSounds();
        }
        _inventoryIsActive = !_inventoryIsActive;
    }

    public void StopMouvement()
    {
        playerController.PlayerCantMove();
    }

    public void ActiveMouvement()
    {
        playerController.PlayerCanMove();
    }

    public GameObject notifPoints;

    public void notifications()
    {
        notifPoints.SetActive(true);
    }
}
