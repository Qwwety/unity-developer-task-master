using UnityEngine;

public class VariablesMovement<T>
{
    [SerializeField]
    public T MaxMovementSpeed;
    public T MovementSpeed;
    public T TurnSpeed;
}
public class VariablesObjects<T>
{
    [SerializeField]
    public T HP;
}

[System.Serializable] public class SerializVariablesMovement : VariablesMovement<int> { }
[System.Serializable] public class SerializVariablesObjects : VariablesObjects<int> { }

