using Godot;
using System;

public partial class anthillUI : Control
{
	Label healthText;
	Label currencyText;
	[Export]
	public resources rSO;
	Button workerButton;
	Button warriorButton;
	const int workerCost = 4;
	const int warriorCost = 8;
	
	public override void _Ready()
	{
		healthText = GetNode<Label>("Label");
		currencyText = GetNode<Label>("Label2");
		workerButton = GetNode<Button>("Button");
		warriorButton = GetNode<Button>("Button2");
	}
	
	public override void _Process(double delta)
	{
		healthText.Text = "Health:" + rSO.hillHealth;
		currencyText.Text = "Currency:" + rSO.currencyAmount;
		workerButton.Text = $"Worker ant button.\n Cost:{workerCost} \n Amount:{rSO.ants["Worker Ant"]}";
		warriorButton.Text = $"Warrior ant button.\n Cost:{warriorCost} \n Amount:{rSO.ants["Warrior Ant"]}";
	}

	private void _on_worker_button_button_down()
	{
		if(rSO.currencyAmount >= workerCost)
		{
			rSO.currencyAmount -= workerCost;
			rSO.ants["Worker Ant"]++;
		}
	}

	private void _on_warrior_button_down()
	{
		if(rSO.currencyAmount >= warriorCost)
		{
			rSO.currencyAmount -= warriorCost;
			rSO.ants["Warrior Ant"]++;
		}
	}
}





