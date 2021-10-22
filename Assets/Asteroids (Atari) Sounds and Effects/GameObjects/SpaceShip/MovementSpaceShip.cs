using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSpaceShip : MonoBehaviour
{
    public static MovementSpaceShip Instance;

    [SerializeField] private float Speed;

    public Vector3 Destination;

    private void Awake()
    {
        Instance = this;
    }

    void FixedUpdate()
    {
        SetDestinationPoint();
    }
    private void Update()
    {
        CheckDistance();
    }

    private void CheckDistance()
    {
        if (Vector3.Distance(transform.position, Destination)<0.5f)
        {
            Destroy(this.gameObject);
        }
    }
    private void SetDestinationPoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, Destination, Speed);
    }
}
