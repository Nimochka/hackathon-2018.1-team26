using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class Tank : Character
{
    [SerializeField] private float moveSpeed;

    protected override void Start()
    {
        base.Start();
        MoveSpeed = moveSpeed;
    }
}
