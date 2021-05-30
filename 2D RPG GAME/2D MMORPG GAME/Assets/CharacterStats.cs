using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{
	//UI
	public Image[] hearts;

	//Stats
	public int health = 5;
	int maxHealth = 5;

	Rigidbody2D rb;

    public void Start()
    {
		rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int amount)
	{
		hearts[health - 1].enabled = false;
		health -= amount;

		rb.AddForce(Vector2.left * 5000);

	}

	public void Regen(int amount)
	{
		health += amount;

		for(int i = 0; i < health; i++)
		{
			hearts[i].enabled = true;
		}
	}

	private void Update()
	{
		if(health > maxHealth)
		{
			health = maxHealth;
		}


		if (Input.GetKeyDown(KeyCode.J))
		{
			if(health < maxHealth)
			{
				Regen(1);
			}
		}
	}
}
