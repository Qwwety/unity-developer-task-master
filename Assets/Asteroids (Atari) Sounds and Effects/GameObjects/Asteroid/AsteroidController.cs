using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController: CObjects
{
    [SerializeField] private float Scale;

    private void Awake()
    {
        Scale = transform.localScale.x;
    }
    public override void GetHit(int Damage)
    {
        Scale -= Damage;
        if (Scale<=0)
        {
            Death();
        }
        else
        {
            Spawn();
        }
    }

    private void Update()
    {
        ScreenControll();
    }

    protected override void Spawn()
    {
        for (int i = 0; i < 2; i++)
        {
            ObjectPoolDynamic.Instance.SpawnFromPool(transform.position, transform.rotation, Scale);
        }
    }
}
