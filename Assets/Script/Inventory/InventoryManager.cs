using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public Canvas inventory;
    private bool _inventoryIsActive = false;
    public bool[] isFull;
    public GameObject[] slots;
    public Image[] slots_sprite;
    public PlayerController playerController;

    
    private void ActiveInventory()
    {
        inventory.gameObject.SetActive(!_inventoryIsActive);
        playerController.enabled = _inventoryIsActive;
        _inventoryIsActive = !_inventoryIsActive;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ActiveInventory();
        }
    }
}
