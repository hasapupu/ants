using Godot;
using System;
using System.Collections;
using System.Collections.Generic;

public partial class daddyScript : Control
{
	public int money = 30;
	public List<string> levels = new List<string>();
	public List<string> completedLevels = new List<string>();
	public Label textBox;
	
	public override void _Ready()
	{
		textBox = GetNode<Label>("Label");
		foreach(Node a in textBox.GetChildren())
		{
			if(a is levelSelect)
			{
				var b = a as levelSelect;
				levels.Add(b.name);
			}
			
		}
	}
}
