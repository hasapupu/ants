using Godot;
using System.Collections.Generic;
using MEC;
using System;

public partial class boulderOObject : overworldObjectBaseClass
{
	[Export] public resources rSO;
	protected string antsToCollect = "Worker Ant";
	public override void _Ready()
	{
		UIPath = "res://scenes/boulderUI.tscn";
	}
	protected override void handleInheritedLogic()
	{
		rSO.clock = GetNode<Timer>("Timer");
		var tempInst = runningInstance as boulderUI;
		tempInst.antsToCollect = antsToCollect;
	}
	
	private void _on_timer_timeout()
	{
		GetParent().GetParent<Node3D>().Visible = false;
		GetParent().GetParent<Node3D>().SetProcess(false);
		GetParent().GetParent<Node3D>().SetPhysicsProcess(false);
		var tempVar = runningInstance as boulderUI;
		rSO.currencyAmount += Convert.ToInt32(tempVar.strValue);
		runningInstance.QueueFree();
	}

	private void _on_node_3d_visibility_changed()
	{
		Timing.RunCoroutine(freeObjectFromMemory());
	}
	
	IEnumerator<double> freeObjectFromMemory()
	{
		//rSO.enemyAnts.Clear();
		rSO.isBusy = false;
		yield return Timing.WaitForSeconds(2f);
		QueueFree();
		onDeletionCallback();
	}
	
	protected virtual void onDeletionCallback(){}
}



