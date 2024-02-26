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
  public void _on_area_3d_body_entered(Node3D body)
  {
    if(body is rewrittenWarrior ant)
    {
      
    }
  }
}
