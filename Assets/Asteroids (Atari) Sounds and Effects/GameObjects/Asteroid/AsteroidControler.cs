using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidControler : MonoBehaviour
{
    //[SerializeField] private int SpawnAmount = 1;
    [SerializeField] private float Scale;

    private void Awake()
    {

    }

    void Update()
    {
        
    }
    private void Start()
    {
        Scale = transform.localScale.x;
    }
  
    public void GetHit()
    {
        Scale -= 1;
        if (Scale<=0)
        {
            Destroy(this.gameObject);
        }
        else
        {
            for (int i=0;i<2;i++)
            {
                ObjectPoolDynamic.Instance.SpawnFromPool(transform.position, transform.rotation, Scale);
            }
            
        }
    }

}
