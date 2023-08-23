using System.Collections.Generic;
using UnityEngine;

public class AnimalCollector : MonoBehaviour
{
    public delegate void AnimalCollected(int currentAnimalCount);
    public event AnimalCollected OnAnimalCollected;
    
    public List<CollectibleAnimal> CollectedAnimals = new();
    
    [SerializeField] private List<Transform> animalPositions = new();
    private int _currentPositionIndex = 0;

    public void AddAnimal(CollectibleAnimal animal)
    {
        CollectedAnimals.Add(animal);
        MoveAnimalToCorrectPosition(animal.transform);
        
        OnAnimalCollected?.Invoke(CollectedAnimals.Count);
    }

    private void MoveAnimalToCorrectPosition(Transform animalTransform)
    {
        if (_currentPositionIndex + 1 > animalPositions.Count)
            return;

        animalTransform.position = animalPositions[_currentPositionIndex].position;
        _currentPositionIndex++;
    }
}
