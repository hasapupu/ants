using Godot;
using System;

public partial class antScript : CharacterBody3D
{
	[Export] public Node3D targetPos;
	[Export] public resources rSO;
	protected bool isTaskCompleted = false;
	
	public override void _PhysicsProcess(double delta)
	{
		if(targetPos.Visible == false)
		{
			targetPos = rSO.hill;
			isTaskCompleted = true;
		}

		var velocity = ((targetPos.GlobalTransform.Origin - GlobalTransform.Origin));
		Velocity = velocity.Normalized();
		MoveAndSlide();
		var lookPos = new Vector3(targetPos.GlobalPosition.X, 0.12f,targetPos.GlobalPosition.Z);
		LookAt(lookPos);
		for (int i = 0; i < GetSlideCollisionCount(); i++)
		{
			var collision = GetSlideCollision(i);
			if(((Node)collision.GetCollider()).Name == "Area3D" && isTaskCompleted)
			{
				QueueFree();
			}
			inheritedCollider((Node)collision.GetCollider());
		}
		GD.Print(Position);
	}
	
	protected virtual void inheritedCollider(Node node)
	{}
}
