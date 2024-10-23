using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{   
    [SerializeField] string[] tutorialSteps = new string[] { "",};
    [SerializeField] TMP_Text tutorialText = null;
    [SerializeField] PlayerManager playerManager = null;

    private HealthComponent healthComponent = null;    
    private int currentStep = 0;
    private int numberOfJumps = 0;
    private int score = 0;

    void OnEnable()
    {
        EventManager.OnUpdateTutorial += GoToNextTutorialStep;
        EventManager.OnPlayerJump += AddJump;
        EventManager.OnGotDestroyedOffScreen += RetryStep;
        EventManager.OnAddScore += AddScore;
    } 

    void OnDisable()
    {
        EventManager.OnUpdateTutorial -= GoToNextTutorialStep;
        EventManager.OnPlayerJump -= AddJump;
        EventManager.OnGotDestroyedOffScreen -= RetryStep;
        EventManager.OnAddScore -= AddScore;
    }

    private void RetryStep(GameObject gameObject, string key)
    {
        if (gameObject.CompareTag("Apple") || gameObject.CompareTag("Obstacle"))
        {

            var currentHealth = healthComponent.CurrentHealth();
            if (gameObject.CompareTag("Obstacle") && currentHealth >= healthComponent.MaxHealth())
            {
                GoToNextTutorialStep();
                return;
            }

            SpawnNewObject(key);

        }
    }

    void AddScore(int score)
    {
        this.score = score;

        if (score >= 15)
        {
            GoToNextTutorialStep();
        }
    }

    void AddJump()
    {
        numberOfJumps++;

        if (numberOfJumps == 3)
        {
            GoToNextTutorialStep();   
        }
    }

    void Start()
    {
        healthComponent = playerManager.GetComponent<HealthComponent>();
        tutorialText = GetComponentInChildren<TMP_Text>();
        tutorialText.text = tutorialSteps[currentStep];
    }
   
    void GoToNextTutorialStep()
    {
        if (currentStep == 0)
        {
            SpawnNewObject("Apple");
        }

        if (currentStep == 1)
        {
            SpawnNewObject("Obstacle");
        }

        currentStep++;
        
        if (currentStep > tutorialSteps.Length - 1)
        {
            EndTutorial();
            return;
        }

        tutorialText.text = tutorialSteps[currentStep];
        
                
    }

    void SpawnNewObject(string key)
    {
        EventManager.SpawnTutorialItem(key);
    }

    void EndTutorial()
    {
        EventManager.StartGame();
    }
}
