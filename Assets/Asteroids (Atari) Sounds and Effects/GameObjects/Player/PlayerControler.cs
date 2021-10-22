using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : CObjects
{
    public static PlayerControler Instance;
    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        ScreenControll();
    }
    public override void GetHit(int Damage)
    {
        HP -= Damage;
        if (HP > 0)
        {
            Spawn();
        }
        else if (HP <= 0)
        {
            Death();
        }
    }
    private void Spawn()
    {

    }

    
}
