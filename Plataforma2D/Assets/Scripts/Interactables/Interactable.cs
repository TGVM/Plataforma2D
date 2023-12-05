using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Interactable : MonoBehaviour
{
    public bool singleUse;

    public UnityEvent OnTrigger;
    public UnityEvent OnExit;

    private bool used;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(used) return;

        if(singleUse) used = true;

        OnTrigger.Invoke();

    }


    void OnTriggerExit2D(Collider2D other)
    {
        if(singleUse) return;
        OnExit.Invoke();
    }


}
