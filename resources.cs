using Godot;
using Godot.Collections;
using System;
using MonoCustomResourceRegistry;

[RegisteredType(nameof(resources),"",nameof(Resource))]
public partial class resources : Resource
{
	[Export]
	public int hillHealth{get; set;}
	[Export]
	public int currencyAmount{get; set;}
	[Export]
	public Dictionary<string,int> ants {get;set;}
	[Export]
	public Timer clock;
	[Export]
	public Node3D hill;
	[Export]
	public Node3D currentSelectedOObject;
	[Export]
	public Node3D currentOObject;
	[Export]
	public bool isBusy;
	[Export]
	public int index;
	[Export]
	public Array<Node3D> friendlyAnts;
	[Export]
	public Array<Node3D> enemyAnts;
	public resources()
	{
		hillHealth = 100;
		currencyAmount = 1;
		ants = new Dictionary<string,int>();
		clock = new Timer();
		hill = new Node3D();
		currentSelectedOObject = new Node3D();
		currentOObject = new Node3D();
		isBusy = false;
		index = 0;
		friendlyAnts = new Array<Node3D>();
		enemyAnts = new Array<Node3D>();
	}
}
