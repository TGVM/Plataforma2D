using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Sprite checkpointLit;
    public GameObject lights;

    private bool isActive;

    private SpriteRenderer spriteRenderer;
    private CheckpointController checkpointController;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    void Start()
    {
        checkpointController = FindObjectOfType<CheckpointController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(isActive) return;

        if(other.CompareTag("Player")){
            checkpointController.SetPos(transform.position);
            spriteRenderer.sprite = checkpointLit;
            lights.SetActive(true);
            isActive = true;
        }
    }

}
