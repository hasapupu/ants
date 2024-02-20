using Godot;
using System;

public partial class rewrittenEUI : Control
{
	[Export] public resources rSO;
	[Export] public Label l1;
	[Export] public Label l2;

	public void _on_button_button_down()
	{
		for(int i = 0; i < rSO.ants["Worker Ant"]; i++)
		{
			var rnd = new RandomNumberGenerator();
			PackedScene antScene;
			antScene = ResourceLoader.Load<PackedScene>("res://rewrittenWarrior.tscn");
			var antNode = antScene.Instantiate<Node>();
			GetTree().CurrentScene.GetNode("SubViewportContainer/SubViewport/Node3D").AddChild(antNode);
			var antInstance = antNode as rewrittenWarrior;
			antInstance.Position = new Vector3(rnd.Randfn(-1,1)/2,0.12f,rnd.Randfn(-1,1)/2);
		}
	}

	public override void _Process(double delta)
	{
		GD.Print(rSO.currentOObject is rewrittenHill);
		var hill = rSO.currentOObject as rewrittenHill; 
		l1.Text = $"Enemy army size: {hill.armySize}";
		l2.Text = $"Reward for conquest: {hill.reward}";
	}
}
