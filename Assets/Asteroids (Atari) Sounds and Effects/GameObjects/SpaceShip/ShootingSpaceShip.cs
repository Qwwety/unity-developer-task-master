using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSpaceShip : MonoBehaviour
{

    [SerializeField] private GameObject Bullet;
    [SerializeField] private Transform Player;
    [SerializeField] private Transform ShootPoint;
    [SerializeField] private float MaxHoldTime;
    [SerializeField] private float MinHoldTime;

    private float TimeToShoot;
    void Start()
    {
        StartCoroutine(ShootingPlayer());
    }
    IEnumerator ShootingPlayer()
    {
        while (true)
        {
            TimeToShoot = Random.Range(MinHoldTime, MaxHoldTime + 1);
            yield return new WaitForSeconds(TimeToShoot);
            Instantiate(Bullet, transform.position, Quaternion.identity);
        }
       
    }
}
