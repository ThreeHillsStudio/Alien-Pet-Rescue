using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZoomInWeapon : MonoBehaviour
{
    [SerializeField] private new Camera camera;
    [SerializeField] private float zoomOut = 120f;
    [SerializeField] private float zoomIn = 20f;
    public bool _zoomInToggle = true;
    public List<Animator> aliensAnimators = new List<Animator>();
    public Transform player;
    public SkinnedMeshRenderer skinnedMeshRenderer;

    [SerializeField] private Transform []enemies;
    
    private bool _isFirstTime;

    public bool isShooting = false;
    public bool isTimerFinished = false;
    public static ZoomInWeapon instance;

    private Vector3 initCameraPosition;
    
    public Vector3 zoomInCameraPosition1;
    public Vector3 zoomOutCameraPosition2;
    
    public GameObject gameObject;
    
    
    private void Awake()
    {
        initCameraPosition = camera.transform.position;
        instance = this;
    }

    public void ZoomIn()
    {
        gameObject.SetActive(false);
        skinnedMeshRenderer.enabled = false;
        foreach (Transform enemy in enemies)
        {
            enemy.LookAt(player);
        }

        _zoomInToggle = false;
        camera.fieldOfView = zoomIn;

        camera.transform.position = zoomInCameraPosition1;

        if (!isShooting && !isTimerFinished)
        {
            SetAnimation("Aim");
        }
        }
    public void ZoomOut()
    {
        gameObject.SetActive(true);
        skinnedMeshRenderer.enabled = true;
        camera.fieldOfView = zoomOut;
        camera.transform.position  = zoomOutCameraPosition2;
        _zoomInToggle = true;
        SetAnimation("Walk");
    }
    public void SetAnimation( string animationName)
    {
        aliensAnimators.ForEach((e) =>
        {
            e.Play(animationName);
        });
    }
    public void SetAnimation( string animationName, Animator animator)
    {
        animator.Play(animationName);
    }
    
}
