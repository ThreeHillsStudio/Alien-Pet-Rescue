using UnityEngine;

public class AnimalCollectingBall : MonoBehaviour
{
    public AnimalCollector AnimalCollector;

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out CollectibleAnimal collectibleAnimal))
        {
            collectibleAnimal.OnCollisionWithBall();
            AnimalCollector.AddAnimal(collectibleAnimal);
        }
    }
}
