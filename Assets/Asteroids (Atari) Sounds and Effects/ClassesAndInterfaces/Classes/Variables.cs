using UnityEngine;

public class VariablesPlayerMovement
{
    [SerializeField]
    public int MaxMovementSpeed;
    public int MovementSpeed;
    public int TurnSpeed;
}
public class VariablesObjects
{
    [SerializeField]
    public int HP;
}

[System.Serializable] public class SerializVariablesPlayerMovement : VariablesPlayerMovement { }
[System.Serializable] public class SerializVariablesObjects : VariablesObjects { }

