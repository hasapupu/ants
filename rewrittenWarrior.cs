using Godot;
using System;

public enum wAntState {MARCHING, HUNTING, FIGHTING, MINING,RETURNING}
public partial class rewrittenWarrior : CharacterBody3D
{
    [Export] public wAntState state =  wAntState.MARCHING;
    [Export] public Vector3 target;
    [Export] public resources rSO;
    [Export] public daddy father;

    public override void _Ready()
    {
        target = rSO.currentOObject.GlobalPosition;
        father = GetTree().Root.GetNode<daddy>("Control/SubViewportContainer/SubViewport/Node3D");
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
                Velocity = father.enemyCurrentPos / 3;
                MoveAndSlide();
                LookAt(father.enemyCurrentPos);
                break;

            case wAntState.FIGHTING:
                LookAt(father.enemyCurrentPos);
                Velocity = new Vector3(0,0,0);
                break;
            
            case wAntState.MINING:
                break;

            case wAntState.RETURNING:
                LookAt(target);
                break;
        }
    }

    public override void _Process(double delta)
    {
        if(rSO.friendlyAnts[rSO.friendlyIndex] == this as Node3D)
        {
            father.friendlyCurrentPos = GlobalTransform.Origin - rSO.enemyAnts[rSO.index].GlobalTransform.Origin;
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
