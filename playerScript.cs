using Godot;
using System;

public partial class playerScript : CharacterBody3D
{
	Node3D cameraPivot;
	float sens = 0.5f;
	
	public override void _Ready()
	{
		cameraPivot = GetNode<Node3D>("CameraPivot");
		Input.MouseMode = Input.MouseModeEnum.Captured;
	}
	
	/*public override void _Input(InputEvent @event)
	{
		if(@event is InputEventMouseMotion)
		{
			RotateY(DegToRad(@event.Relative.X * sens));
			cameraPivot.RotateX(DegToRad(-@event.Relative.Y * sens));
			//pivot.Rotation.X = clamp(cameraPivot.Rotation.X, DegToRad(-90),)
		}
	}*/
}
