using Godot;
using System;

public partial class overworldObjectBaseClass : StaticBody3D
{
	public string UIPath = "res://scenes/anthillUI.tscn";
	protected Node runningInstance;
	public void initUI()
	{
		GD.Print(GetParent().GetParent().GetParent().GetParent().GetParent().GetParent().GetNodeOrNull("Control"));
		foreach(Node a in GetParent().GetParent().GetParent().GetParent().GetParent().GetParent().GetChildren())
		{
			if(a.Name != "SubViewportContainer")
			{
				a.QueueFree();
			}
		}
		var UIScene = ResourceLoader.Load<PackedScene>(UIPath);
		var UIInstance = UIScene.Instantiate<Node>();
		GetParent().GetParent().GetParent().GetParent().GetParent().GetParent().AddChild(UIInstance);
		runningInstance = UIInstance;
		handleInheritedLogic();
	}
	protected virtual void handleInheritedLogic(){}
}
