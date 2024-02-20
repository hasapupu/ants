using Godot;
using System;

public partial class rewrittenHill : overworldObjectBaseClass
{
  [Export]  public int armySize = 1;
  [Export]  public int reward = 10;
    public override void _Ready()
    {
		  UIPath = "res://rewrittenEUI.tscn";
    }
}
