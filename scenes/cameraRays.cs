using Godot;
using System;

public partial class cameraRays : Camera3D
{
	[Export] public resources rSO;
	
	public override void _PhysicsProcess(double delta)
	{
		var spaceState = GetWorld3D().DirectSpaceState;
		var start = ProjectRayOrigin(GetViewport().GetMousePosition());
		var end = ProjectPosition(GetViewport().GetMousePosition(), 1000);
		var result = spaceState.IntersectRay(PhysicsRayQueryParameters3D.Create(start,end));
		GD.Print(result[Variant.From<string>("collider")].AsGodotObject().GetType().Name);
		if(Input.IsMouseButtonPressed(MouseButton.Left))
		{
			if(result[Variant.From<string>("collider")].AsGodotObject().GetType().Name == "overworldObjectBaseClass")
			{
				var oObject = result[Variant.From<string>("collider")].AsGodotObject() as overworldObjectBaseClass;
				GD.Print("Debug msg");
				oObject.initUI();
			}
			else if(result[Variant.From<string>("collider")].AsGodotObject().GetType().Name == "boulderOObject" || result[Variant.From<string>("collider")].AsGodotObject().GetType().Name == "enemyAnthill")
			{
				GD.Print("Succ");
				var oObject = result[Variant.From<string>("collider")].AsGodotObject() as boulderOObject;
				rSO.currentOObject = oObject.GetParent().GetParent() as Node3D;
				oObject.initUI();
			}
			else if(result[Variant.From<string>("collider")].AsGodotObject().GetType().Name == "rewrittenHill")
			{
				var oObject = result[Variant.From<string>("collider")].AsGodotObject() as rewrittenHill;
				rSO.currentOObject = oObject as Node3D;
				oObject.initUI();
			}
		}
	
	}
}
