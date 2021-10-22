using UnityEngine;

[SerializeField]
public abstract class CMovement : MonoBehaviour
{
    [SerializeField] private SerializVariablesMovement SerializVariable;

    private Rigidbody Rigidbody;

    protected int MovementSpeed { get; set; }
    protected int MaxMovementSpeed { get; set; }
    protected int TurnSpeed { get; set; }
    protected float VerticalMovment { get; set; }
    protected float HorizontalMovment { get; set; }

    protected abstract void GetAxis();
    protected abstract void Rotation();

    protected void Movement()
    {
        Vector3 MoveDirection = Rigidbody.transform.forward * -VerticalMovment; // определение направление движения 
        Rigidbody.AddForce(MoveDirection * MovementSpeed, ForceMode.Acceleration);
    }
    protected void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        MovementSpeed = SerializVariable.MovementSpeed;
        MaxMovementSpeed = SerializVariable.MaxMovementSpeed;
        TurnSpeed = SerializVariable.TurnSpeed;
    }
    protected void FixedUpdate()
    {
        if (Rigidbody.velocity.magnitude>MaxMovementSpeed)
        {
            Rigidbody.velocity = Vector3.ClampMagnitude(Rigidbody.velocity, MaxMovementSpeed);
        }
        GetAxis();
    }
    protected void Update()
    {
        Movement();
        Rotation();
    }
}