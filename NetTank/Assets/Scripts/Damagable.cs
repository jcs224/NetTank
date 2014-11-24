using UnityEngine;
using System.Collections;

public class Damagable : MonoBehaviour 
{
	public int health;
	public int maxHealth;


	public void heal(int power)
	{
		health = Mathf.Min(maxHealth, health + power);
	}

	public void hurt(int damage)
	{
		health = Mathf.Max(0, health - damage);
	}

	public bool isDead()
	{
		if(health == 0)
			return true;
	}
}
