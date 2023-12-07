using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubDoor : MonoBehaviour
{
    public int keysToOpen = 3;
    public Sprite[] doorSprites;
    public GameObject sceneGoal;

    private int currentKeys = 0;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void AddKeys(){
        currentKeys++;

        UIManager.instance.SetKeys(currentKeys);

        Invoke("SetDoorSprite", 3f);

        if(currentKeys >= keysToOpen){
            sceneGoal.SetActive(true);
        }
    }

    void SetDoorSprite(){
        spriteRenderer.sprite = doorSprites[currentKeys];
    }

}
