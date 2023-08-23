using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZoomInLevel2 : MonoBehaviour
{
    [SerializeField] private new Camera camera;
    [SerializeField] private float zoomOut = 120f;
    [SerializeField] private float zoomIn = 20f;
    public bool _zoomInToggle = true;
    public List<Animator> aliensAnimators = new List<Animator>();
    public Transform player;
    public GameObject gameObject;

    [SerializeField] private Transform []enemies;
    
    private bool _isFirstTime;

    public bool isShooting = false;
    public bool isTimerFinished = false;
    public static ZoomInLevel2 instance;

    private Vector3 initCameraPosition;
    private void Awake()
    {
        initCameraPosition = camera.transform.position;
        instance = this;
    }
    public void ZoomIn()
    {
        gameObject.SetActive(false);
        foreach (Transform enemy in enemies)
        {
            enemy.LookAt(player);
        }
        _zoomInToggle = false;
        camera.fieldOfView = zoomIn;
        
        camera.transform.position = new Vector3(-4,9.68000031f,-28.2600002f);
        
        if (!isShooting && !isTimerFinished)
        {
            SetAnimation("Aim");
        } 
    }
    public void ZoomOut()
    {
        camera.fieldOfView = zoomOut;
        camera.transform.position  = new Vector3(-1.33000004f,15.5f,-34.7900009f);
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
