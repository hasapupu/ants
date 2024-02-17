using Godot;
using System;
using System.Collections;
using System.Collections.Generic;

public partial class cameraPhysics : CharacterBody3D
{
	public List<cameraControll> buttons = new List<cameraControll>();
	Vector3 velocity = Vector3.Zero;
	
	public override void _Ready()
	{
		foreach(cameraControll a in GetNode("Camera3D").GetChildren())
		{
			var b = a as cameraControll;
			buttons.Add(b);
			GD.Print(a);
		}
	}
	
	public override void _PhysicsProcess(double delta)
	{
		/*GD.Print(buttons.Count);
		foreach(cameraControll a in buttons)
		{
			if(a.isMouseIn == true)
			{
				velocity = new Vector3(a.x,a.y,0);
				GD.Print("RAAAAAAAA");
			}
		}
		//GD.Print(velocity);
		Velocity = velocity;8*/
		if(Input.IsActionPressed("LftCtrl"))
			MoveAndSlide();
	}
}
