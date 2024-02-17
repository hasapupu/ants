using Godot;
using System;
using System.Collections;
using System.Collections.Generic;

public partial class cameraControll : Control
{
	public bool isMouseIn = false;
	public CharacterBody3D body;
	Vector2 mouse;
	
	public override void _Ready()
	{
		body = GetParent().GetParent() as CharacterBody3D;
		
	}
	
	private void _on_mouse_entered()
	{
		GD.Print("RAAAAAAAAAAA");
		isMouseIn = true;
		body.Velocity = Vector3.Zero;
	}


	private void _on_mouse_exited()
	{
		int x;
		int y;
		isMouseIn = false;
		if(GetViewport().GetMousePosition().X < GetViewport().GetVisibleRect().Size.X / 8)
		{
			x = -2;
		}
		else if(GetViewport().GetMousePosition().X > (GetViewport().GetVisibleRect().Size.X / 8) * 6)
		{
			x = 2;
		}
		else
		{
			x = 0;
		}
		if(GetViewport().GetMousePosition().Y < (GetViewport().GetVisibleRect().Size.Y) / 6)
		{
			y = -2;
		}
		else if(GetViewport().GetMousePosition().Y > ((GetViewport().GetVisibleRect().Size.Y) / 8) * 6)
		{
			y = 2;
		}
		else
		{
			y = 0;
		}
		body.Velocity = new Vector3(x,body.Velocity.Y, y);
		GD.Print(body.Velocity);
	}
}
