using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAttack : MonoBehaviour
{
    public UnityEvent OnAttack;
    public UnityEvent ReleaseAttack;

    public float attackRate = 0.5f;

    private bool canAttack = true;

   private PlayerAnimation playerAnimation;
   private PlayerController playerController;
   
    void Awake()
    {
        playerAnimation = GetComponent<PlayerAnimation>();
        playerController = GetComponent<PlayerController>();
        
    }

    public void MeleeAttack(){
        if(canAttack){
            canAttack = false;
            OnAttack.Invoke();
            playerAnimation.SetMeleeAttack();
            if(!playerController.IsOnIce()){
                playerController.DisableControls();
            }
            Invoke("FinishAttack", attackRate);

        }
        
    }

    void FinishAttack(){
        ReleaseAttack.Invoke();
        canAttack = true;
    }

}
