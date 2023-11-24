using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Skills{
    DoubleJump, Melee, Gun
}


public class PlayerSkills : MonoBehaviour{
    
    public static PlayerSkills instance;

    public List<Skills> skills;

    void Awake()
    {
        instance = this;
    }



}
