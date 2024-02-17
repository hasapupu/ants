using Godot;
using System;
using System.Collections.Generic;
using MEC;

public partial class boulderUI : Control
{
	Label name;
	Label value;
	[Export] public string strName;
	[Export] public string strValue;
	[Export] resources rSO;
	Button extractButton;
	Vector3 ra;
	public string antsToCollect = "Worker Ant";
	
	public override void _Ready()
	{
		name = GetNode<Label>("Label");
		value = GetNode<Label>("Label2");
		extractButton = GetNode<Button>("Button");
	}
	
	public override void _Process(double delta)
	{
		name.Text = strName;
		value.Text = "The reward is \n" + strValue + "currency";
		extractButton.Text = Convert.ToString(Math.Ceiling(rSO.clock.TimeLeft));
		GD.Print(rSO.clock.TimeLeft);
		GD.Print(GetTree().CurrentScene.GetNode("SubViewportContainer/SubViewport/Node3D"));
	}

	private void _on_button_button_down()
	{
		GD.Print(rSO.isBusy);
		if(rSO.ants[antsToCollect] > 0 && rSO.isBusy == false)
		{
			rSO.isBusy = true;
			rSO.currentSelectedOObject = rSO.currentOObject;
			rSO.clock.WaitTime = 60/rSO.ants[antsToCollect];
			Timing.RunCoroutine(spawnAnts());
			rSO.clock.Start();
		}
	}
	protected IEnumerator<double> spawnAnts()
	{
		var rnd = new RandomNumberGenerator();
		for(int i = 0; i < rSO.ants[antsToCollect]; i++)
		{
			PackedScene antScene;
			if(antsToCollect == "Worker Ant")
			{
				antScene = ResourceLoader.Load<PackedScene>("res://ant.tscn");
			}
			else
			{
				antScene = ResourceLoader.Load<PackedScene>("res://warriorAnt.tscn");
			}
			var antNode = antScene.Instantiate<Node>();
			GetTree().CurrentScene.GetNode("SubViewportContainer/SubViewport/Node3D").AddChild(antNode);
			var antInstance = antNode as antScript;
			antInstance.targetPos = rSO.currentSelectedOObject;
			antInstance.Position = new Vector3(rnd.Randfn(-1,1)/2,0.12f,rnd.Randfn(-1,1)/2);
			if(antsToCollect == "Warrior Ant")
			{
				//var wIn = antInstance as warriorAnt;
				//wIn.isPlayers = true;
			}
			GD.Print(ra);
			yield return Timing.WaitForSeconds(1f);
		}
	}
}
