using System.Collections;
using UnityEngine;
using DG.Tweening;

public class BallWin : MonoBehaviour
{
    public SkinnedMeshRenderer skinnedMeshRenderer;
    public Transform endPosition;
    public float duration = 5.0f;
    public float delaySeconds = 2.0f;
    public float delaySeconds2 = 2.0f;
    public float blendShapeTargetWeight = 100.0f; // Ciljna težina blend oblika
    public float blendShapeTweenDuration = 2.0f; // Trajanje animacije promene težine blend oblika

    private Vector3 startPosition;
    private bool isMoving = false;

    public GameObject animal;

    public Camera mainCamera;
    public Camera secendCamera;

    void Start()
    {
        mainCamera.enabled = true;
        secendCamera.enabled = false;
        startPosition = transform.position;
        StartMoving();
    }

    private void StartMoving()
    {
        isMoving = true;
        StartCoroutine(WaitAndMove());
    }

    private IEnumerator WaitAndMove()
    {
        yield return new WaitForSeconds(delaySeconds);

        // Postepeno povećavanje težine blend oblika koristeći DG.Tweening
        skinnedMeshRenderer.DOKill(); // Prekida trenutnu animaciju, ako postoji
        DOTween.To(() => skinnedMeshRenderer.GetBlendShapeWeight(skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("Key 1")),
            blendWeight => skinnedMeshRenderer.SetBlendShapeWeight(skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("Key 1"), blendWeight),
            blendShapeTargetWeight, blendShapeTweenDuration).OnComplete(() =>
        {
            StartCoroutine(MoveToTarget());
        });
    }

    private IEnumerator MoveToTarget()
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            transform.position = Vector3.Lerp(startPosition, endPosition.position, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = endPosition.position;
        isMoving = false;
        mainCamera.enabled = false;
        secendCamera.enabled = true;
        BallRotate();
    }

    private void BallRotate()
    {
        animal.transform.localScale = new Vector3(0.54f, 0.54f, 0.54f);
        animal.transform.rotation = new Quaternion(0, 0.881303489f, 0, -0.47255066f); 
        StartCoroutine(CloseTheBall());
    }

    private IEnumerator CloseTheBall()
    {
        yield return new WaitForSeconds(delaySeconds2);

        
        skinnedMeshRenderer.SetBlendShapeWeight(skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("Key 1"), 0);
    }
}
