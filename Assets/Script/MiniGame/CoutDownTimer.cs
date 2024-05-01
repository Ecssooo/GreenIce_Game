using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    public float timeRemaining = 20; // Temps restant en secondes
    public Text countdownText;
    public GameObject Script;
    public GameObject lumiere;
    public Text textHelp;
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime; // Réduire le temps restant en fonction du temps écoulé
            UpdateCountdownUI();
            if (timeRemaining < 1)
            {
                lumiere.SetActive(true);
            }
        }
        else
        {
            timeRemaining = 0;
            Script.SetActive(true);
            countdownText.enabled = false;
            textHelp.enabled = false;
            // Le compte à rebours est terminé, vous pouvez ajouter du code pour gérer cela ici
        }
    }

    void UpdateCountdownUI()
    {
        float time = Mathf.Round(timeRemaining * 1);
        countdownText.text = time.ToString();
    }
}