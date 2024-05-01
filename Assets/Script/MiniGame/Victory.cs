using UnityEngine;
using UnityEngine.UI;

public class Victory : MonoBehaviour
{
    public float timeRemaining = 20; // Temps restant en secondes
    public Canvas canva;
    public GameObject Script;
    public GameObject lumiere;
    public GameObject lightFollow;

    public GameObject dialogueWindow;
    public GameObject dialogueVictoire;
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime; // Réduire le temps restant en fonction du temps écoulé
            UpdateCountdownUI();
        }
        else
        {
            timeRemaining = 0;
            Script.SetActive(false);
            canva.gameObject.SetActive(true);
            lumiere.SetActive(true);
            lightFollow.SetActive(false);
            dialogueWindow.SetActive(true);
            dialogueVictoire.SetActive(true);
            // Le compte à rebours est terminé, vous pouvez ajouter du code pour gérer cela ici
        }
    }

    void UpdateCountdownUI()
    {
        float time = Mathf.Round(timeRemaining * 1);
    }
}