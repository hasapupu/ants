using Godot;
using System;

public enum enemyAntModes {MARCHING, RETURNING, ATTACKING}
public partial class enemyAnt : CharacterBody3D
{
    [Export] public enemyAntModes state = enemyAntModes.MARCHING;
    [Export] public resources rSO;
    [Export] public daddy father;

    public override void _Ready()
    {
        state = enemyAntModes.MARCHING;
        father = GetTree().Root.GetNode<daddy>("Control/SubViewportContainer/SubViewport/Node3D");
        GD.Print(GetTree().Root.GetNode<daddy>("Control/SubViewportContainer/SubViewport/Node3D") + "faszribanc");
    }

    public void _on_area_3d_body_entered(Node3D body)
    {
        GD.Print("Gigagoon");
        if(body is rewrittenWarrior fAnt)
        {
            fAnt.state = wAntState.FIGHTING;
            state = enemyAntModes.ATTACKING;
        }
    }

    public override void _PhysicsProcess(double delta)
    {
        switch(state)
        {
            case enemyAntModes.MARCHING:
                Velocity = father.friendlyCurrentPos / 3;
                MoveAndSlide();
                LookAt(rSO.friendlyAnts[rSO.friendlyIndex].GlobalPosition);
                break;
            
            case enemyAntModes.RETURNING:
                Velocity = rSO.currentOObject.GlobalPosition / 3;
                MoveAndSlide();
                LookAt(rSO.friendlyAnts[rSO.friendlyIndex].GlobalPosition);
                break;

            case enemyAntModes.ATTACKING:
                Velocity = new Vector3(0,0,0);
                break;

            
        }
    }

    public override void _Process(double delta)
    {
        if(rSO.enemyAnts[rSO.index] == this as Node3D)
        {
            father.enemyCurrentPos = GlobalTransform.Origin - rSO.friendlyAnts[rSO.friendlyIndex].GlobalTransform.Origin;
        }
    }
}
