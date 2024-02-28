using Godot;
using System;

public partial class rewrittenHill : overworldObjectBaseClass
{
  [Export]  public int armySize = 1;
  [Export]  public int reward = 10;
  [Export]  public resources rSO;
  
  public override void _Ready()
  {
	  UIPath = "res://rewrittenEUI.tscn";
  }
  public void _on_area_3d_body_entered(Node3D body)
  {
    if(body is rewrittenWarrior ant)
    {
      for(int i = 0; i < armySize; i++)
      {
        PackedScene antScene;
        antScene = ResourceLoader.Load<PackedScene>("res://enemyAnt.tscn");
        var antNode = antScene.Instantiate<Node>();
			  GetTree().CurrentScene.GetNode("SubViewportContainer/SubViewport/Node3D").AddChild(antNode);
        var temp = antNode as Node3D;
        temp.GlobalPosition = GlobalPosition - new Vector3(1,0,0);
			  rSO.enemyAnts.Add(antNode as Node3D);
      }
    }
  }
}
