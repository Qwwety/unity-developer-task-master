using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: CObjects
{
    public static PlayerController Instance;
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
    protected override void Spawn()
    {
        Instantiate(this, new Vector3(0,0,0),Quaternion.identity);
    }

}
