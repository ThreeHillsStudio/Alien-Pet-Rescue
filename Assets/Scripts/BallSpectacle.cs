using System.Collections;
using UnityEngine;
using DG.Tweening;

public class BallSpectacle : MonoBehaviour
{
    public Transform startTransform;
    public Transform middleTransform;
    public Transform endTransform;

    public SkinnedMeshRenderer skinnedMeshRenderer;
    public GameObject animal;
    public GameObject ball;

    private void Start()
    {
        StartCoroutine(AnimateAnimal());
    }

    private IEnumerator AnimateAnimal()
    {
        Vector3[] pathPoints = new Vector3[]
        {
            transform.position,
            startTransform.position + new Vector3(0, 2f, 2f),
            middleTransform.position
        };

        float moveDuration = 1.0f; // Skratili trajanje animacije
        transform.DOLocalPath(pathPoints, moveDuration, PathType.CatmullRom).SetEase(Ease.Linear);

        yield return new WaitForSeconds(moveDuration);

        yield return transform.DOMove(endTransform.position, 0.5f).SetEase(Ease.Linear).WaitForCompletion(); // Skratili trajanje animacije

        OpetTheAnimal();
        StartCoroutine(ScaleAnimal());
    }

    private IEnumerator ScaleAnimal()
    {
        float scaleDuration = 0.4f; // Skratili trajanje animacije
        Vector3 originalScale = animal.transform.localScale;
        Vector3 targetScale = Vector3.zero;

        float elapsedTime = 0f;
        while (elapsedTime < scaleDuration)
        {
            float t = elapsedTime / scaleDuration;
            animal.transform.localScale = Vector3.Lerp(originalScale, targetScale, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        animal.transform.localScale = targetScale;
    }

    private IEnumerator MoveAnimalToPosition(Vector3 targetPosition, float moveDuration)
    {
        Vector3 startPosition = animal.transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < moveDuration)
        {
            float t = elapsedTime / moveDuration;
            animal.transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        animal.transform.position = targetPosition;
    }

    private void OpetTheAnimal()
    {
        ball.transform.DORotateQuaternion(new Quaternion(0.563509583f, -0.727091253f, 0.222803652f, 0.322728753f), 0.5f); // Dodali tweening rotacije
        skinnedMeshRenderer.SetBlendShapeWeight(skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("Key 1"), 100);

        Vector3 targetPosition = endTransform.position;
        float moveDuration = 0.4f; // Skratili trajanje kretanja

        StartCoroutine(MoveAnimalToPosition(targetPosition, moveDuration));
    }
}
