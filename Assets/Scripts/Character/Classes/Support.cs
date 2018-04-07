using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Boss : Character
{
    protected override void Start()
    {
        HealthPoints = 4;
        base.Start();

    }
    
    private class HealtSkill: Skill
    {
        
        
    }
}
