using UnityEngine;

[SerializeField]
public abstract class CPlayerMovement : CObjectMovement
{
    [SerializeField] private SerializVariablesPlayerMovement SerializVariable;

    protected int TurnSpeed { get; set; }
    protected float VerticalMovment { get; set; }
    protected float HorizontalMovment { get; set; }

    protected abstract void Rotation();
    protected override void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        MovementSpeed = SerializVariable.MovementSpeed;
        MaxMovementSpeed = SerializVariable.MaxMovementSpeed;
        TurnSpeed = SerializVariable.TurnSpeed;
    }
    protected abstract void GetAxis();
    protected override void FixedUpdate()
    {
        if (Rigidbody.velocity.magnitude>MaxMovementSpeed)
        {
            Rigidbody.velocity = Vector3.ClampMagnitude(Rigidbody.velocity, MaxMovementSpeed);
        }
        GetAxis();
    }
    protected override void Update()
    {
        Movement();
        Rotation();
    }
    protected override void Movement()
    {
        Vector3 MoveDirection = Rigidbody.transform.forward * -VerticalMovment; // определение направление движения 
        Rigidbody.AddForce(MoveDirection * MovementSpeed, ForceMode.Acceleration);
    }
}