using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Tank : Character
{
    protected override void Start()
    {
        base.Start();
        MoveSpeed = 4;
    }
}
