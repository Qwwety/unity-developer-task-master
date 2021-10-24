using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControlSpceShip : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private float BulletSpeed;
    [SerializeField] private int Damage;
    void Start()
    {
        LookAtPlayer();
        StartCoroutine(WaitTimeToDie());
    }
    private void FixedUpdate()
    {
        BulletMovement();
    }

    private void LookAtPlayer()
    {
        Vector3 TargetPosition = new Vector3(Player.transform.position.x, 0, Player.transform.position.z);
        Vector3 Direction = (TargetPosition-transform.position).normalized;
        float angle = Mathf.Atan2(Direction.x, Direction.z) * Mathf.Rad2Deg;
        Quaternion target = Quaternion.Euler(0, angle, 0);
        transform.rotation = target;
    }
   
    private void BulletMovement()
    {
        transform.position += transform.forward* BulletSpeed;
    }
    IEnumerator WaitTimeToDie()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            PlayerController.Instance.GetHit(Damage);
            Destroy(this.gameObject);
        }
    }
}
