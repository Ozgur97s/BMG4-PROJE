using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{
	//UI
	public Image[] hearts;

	//Stats
	public int health = 5;
	Rigidbody2D rb;
	Vector2 konum;
	Animator animator;
	GameObject karakter;
	
	

    public void Start()
    {
		animator = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int amount)
	{
		hearts[health - 1].enabled = false;
		health -= amount;

		rb.AddForce(Vector2.left * 2500);

		if (health <= 0)
		{
			Death();		
		}

	}

	public void Death()
    {
		animator.SetTrigger("Die");
		StartCoroutine(RestartDelay());
	}

	IEnumerator RestartDelay()
	{
		yield return new WaitForSeconds(3f);
		SceneManager.LoadScene("SampleScene");
	}

	private void Update()
	{
	
	}



}
