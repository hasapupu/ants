using Godot;
using System;

public partial class daddy : Node3D
{
    [Export] public resources rSO;

    public override void _Process(double delta)
    {
        if(rSO.friendlyAnts.Count > 0)
        {
            if(rSO.enemyAnts.Count > 0)
            {
                foreach(var ant in rSO.friendlyAnts)
                {
                    rewrittenWarrior wIn = ant as rewrittenWarrior;
                    wIn.state = wAntState.HUNTING;
                }
            }
            else
            {
                foreach(var ant in rSO.friendlyAnts)
                {
                    rewrittenWarrior wIn = ant as rewrittenWarrior;
                    wIn.state = wAntState.MARCHING;
                }
            }
        }
    }
}
