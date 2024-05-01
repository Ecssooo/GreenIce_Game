using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal;
public class Lampe : MonoBehaviour
{
    public SpriteItem spriteItem;
    public GameObject lampeTorche;
    private void Update()
    {
        if(InventoryManager.objectInHand != null)
            if (InventoryManager.objectInHand.GetComponent<Image>().sprite == spriteItem.lampe)
            {
                lampeTorche.SetActive(true);
            }
            else
            {
                lampeTorche.SetActive(false);
            }
    }
}

   

