using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPickup : MonoBehaviour
{
    public Skills skill;
    public Sprite pickedSprite;

    private bool picked;
    private SpriteRenderer spriteRenderer;
    

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(picked) return;

        PlayerAnimation player = other.GetComponent<PlayerAnimation>();

        if(player != null){
            picked = true;
            spriteRenderer.sprite = pickedSprite;
            PlayerSkills.instance.skills.Add(skill);
            if(skill == Skills.Gun){
                player.SetGun();
            }
        }
    }
    
}
