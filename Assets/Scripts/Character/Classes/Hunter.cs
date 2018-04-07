using UnityEngine;

public class Hunter : Character
{
    
    [SerializeField] private float moveSpeed;
    
    protected override void Start()
    {
        base.Start();
        MoveSpeed = moveSpeed;

    }
}
