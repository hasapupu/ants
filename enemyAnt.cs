using Godot;
using System;

public enum enemyAntModes {MARCHING, RETURNING, ATTACKING}
public partial class enemyAnt : CharacterBody3D
{
    [Export] public enemyAntModes state = enemyAntModes.MARCHING;
    [Export] public resources rSO;
    public override void _Process(double delta)
    {
        switch(state)
        {
            case enemyAntModes.MARCHING:
                Velocity = rSO.friendlyAnts[rSO.friendlyIndex].GlobalPosition;
                MoveAndSlide();
                LookAt(rSO.friendlyAnts[rSO.friendlyIndex].GlobalPosition);
                break;
            
            case enemyAntModes.RETURNING:
                Velocity = rSO.currentOObject.GlobalPosition;
                MoveAndSlide();
                LookAt(rSO.currentOObject.GlobalPosition);
                break;

            case enemyAntModes.ATTACKING:
                Velocity = new Vector3(0,0,0);
                break;

            
        }
    }
}
