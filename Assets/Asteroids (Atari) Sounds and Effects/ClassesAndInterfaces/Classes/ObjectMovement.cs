using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CObjectMovement : MonoBehaviour
{
    protected int MovementSpeed { get; set; }
    protected int MaxMovementSpeed { get; set; }

    protected Rigidbody Rigidbody;

    protected abstract void Movement();
    protected abstract void Start();
    protected abstract void Update();
    protected abstract void FixedUpdate();
}
