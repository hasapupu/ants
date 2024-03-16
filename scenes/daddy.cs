using Godot;
using Godot.Collections;
using System;

public partial class daddy : Node3D
{
	[Export] public resources rSO;
	[Export] public Array<Node3D> debugIndex;
	[Export] public Vector3 friendlyCurrentPos;
	[Export] public Vector3 enemyCurrentPos;

	public override void _Process(double delta)
	{
		debugIndex = rSO.enemyAnts;
	}
}
