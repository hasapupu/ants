using Godot;
using System;

public partial class mouseTracker : Node2D
{
	public override void _Process(double delta)
	{
		GD.Print(GetViewport().GetMousePosition());
		GD.Print(DisplayServer.WindowGetSize());
		GD.Print(GetViewport().GetVisibleRect().Size);
		GD.Print((GetViewport().GetVisibleRect().Size.Y / 8) * 3);
	}
}
