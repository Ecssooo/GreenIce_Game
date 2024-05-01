using UnityEngine;

public class SuivreSouris : MonoBehaviour
{
    // Définir la vitesse de déplacement de l'objet
    //public float vitesseDeDeplacement = 5f;

    void Update()
    {
        // Obtenir la position de la souris dans l'espace du monde
        Vector3 mousPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousPos.z = 0f; // Assurer que la position z reste constante (2D)

        // Déplacer l'objet vers la position de la souris
        transform.position = new Vector3(mousPos.x, mousPos.y,transform.position.z);
    }
}