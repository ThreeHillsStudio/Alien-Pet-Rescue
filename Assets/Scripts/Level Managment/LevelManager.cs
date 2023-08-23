using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public int MinimumCollectedAnimalsForNextLevel;
    
    public float delayBeforeNextLevel = 1.0f; 
    
    public AnimalCollector AnimalCollector;

    [SerializeField] private GameObject nextBtn;

    [SerializeField] private Vector3 winUiScale;
    
    private void Awake()
    {
        AnimalCollector.OnAnimalCollected += CheckIfShouldTransitionToNextScene;
    }

    private void CheckIfShouldTransitionToNextScene(int collectedAnimalsCount)
    {
        if (MinimumCollectedAnimalsForNextLevel == collectedAnimalsCount)
            LoadNextSceneWithDelay();
    }
    
    private void LoadNextSceneWithDelay()
    {
        nextBtn.transform.DOScale(winUiScale, 0.5f).SetDelay(delayBeforeNextLevel).SetEase(Ease.Linear);
    }

    
}
