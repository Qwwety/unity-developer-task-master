using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipMovement : CObjectMovement
{
    public static SpaceShipMovement Instance;

    [SerializeField] private float Speed;

    public Vector3 Destination;

    protected override void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    protected override void Update()
    {
        CheckDistance();
    }

    protected override void FixedUpdate()
    {
        Movement();
    }

    protected override void Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, Destination, Speed);
    }
    private void Awake()
    {
        Instance = this;
    }
    private void CheckDistance()
    {
        if (Vector3.Distance(transform.position, Destination)<0.5f)
        {
            Destroy(this.gameObject);
        }
    }
}
