using UnityEngine;

public abstract class CObjects : MonoBehaviour
{
    [SerializeField] private SerializVariablesObjects SerializVariable;

    private Rigidbody Rigidbody;
    protected int HP{ get; set; }
    public virtual void GetHit(int Damage)
    {
        HP -= Damage;
        if (HP <= 0)
        {
            Death();
        }
    }
    protected void Death()
    {
        Destroy(this.gameObject);
    }
    protected void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        HP = SerializVariable.HP;
    }
    protected void ScreenControll()
    {
        var onScreenPosition = Camera.main.WorldToScreenPoint(transform.position);
        var newPosition = onScreenPosition;
       
        if (onScreenPosition.x < 0)
            newPosition.x = Screen.width;
       
        if (onScreenPosition.x > Screen.width)
            newPosition.x = 0;
       
        if (onScreenPosition.y < 0)
            newPosition.y = Screen.height;
       
        if (onScreenPosition.y > Screen.height)
            newPosition.y = 0;
       
        var worldCoordinates = Camera.main.ScreenToWorldPoint(newPosition);
        this.transform.position = new Vector3(worldCoordinates.x,0, worldCoordinates.z);
    }
    protected abstract void Spawn();
}
