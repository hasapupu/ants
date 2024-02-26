using Godot;
using System;

public enum wAntState {MARCHING, HUNTING, FIGHTING, MINING,RETURNING}
public partial class rewrittenWarrior : CharacterBody3D
{
    [Export] public wAntState state =  wAntState.MARCHING;
    [Export] public Vector3 target;
    [Export] public resources rSO;

    public override void _Ready()
    {
        target = rSO.currentOObject.GlobalPosition;
    }

    public override void _PhysicsProcess(double delta)
    {
        switch(state)
        {
            case wAntState.MARCHING:
                Velocity = target / 3;
                MoveAndSlide();
                LookAt(target);
                break;
            
            case wAntState.HUNTING:
                Velocity = rSO.enemyAnts[rSO.index].GlobalPosition;
                MoveAndSlide();
                LookAt(rSO.enemyAnts[rSO.index].GlobalPosition);
                break;

            case wAntState.FIGHTING:
                LookAt(rSO.enemyAnts[rSO.index].GlobalPosition);
                break;
            
            case wAntState.MINING:

                break;

            case wAntState.RETURNING:
                LookAt(target);
                break;
        }
    }

    public void _on_area_3d_2_body_entered(Node3D collision)
    {
        if(collision.IsInGroup("Enemy ant"))
        {
            if(state == wAntState.HUNTING)
            {
                state = wAntState.FIGHTING;
            }
        }
        if(collision.IsInGroup("Enemy hill"))
        {
            if(state == wAntState.MARCHING)
            {
                state = wAntState.MINING;
            }
        }
    }
}
