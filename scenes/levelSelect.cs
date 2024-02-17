using Godot;
using System;

public partial class levelSelect : Button
{
	[ExportGroup("Properties")]
	[Export]
	public string name;
	[Export]
	public int reward;
	
	public Label textBox;
	
	public override void _Ready()
	{
		textBox = GetParent<Label>();
	}
	
	private void _on_pressed()
	{
		
	}
	 
}



