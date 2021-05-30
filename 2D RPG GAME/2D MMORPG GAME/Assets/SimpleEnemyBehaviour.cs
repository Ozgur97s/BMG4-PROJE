using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyBehaviour : MonoBehaviour
{

    public int speed;
    public int turnDelay;
    public int health;
    Rigidbody2D rb;



    bool faceRight = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(SwitchDirection()); 
    }

    private void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        
    }

    IEnumerator SwitchDirection()
    {
        yield return new WaitForSeconds(turnDelay);
        Switch();
    }

    private void Switch()
    {
        faceRight = !faceRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;

        speed *= -1;

        StartCoroutine(SwitchDirection());
    }

    public void TakeDamage(int amount)
    {
        rb.AddForce(Vector2.right * 100);

        health -= amount;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
         

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.transform.GetComponent<CharacterStats>().TakeDamage(1);
        }
    }



}
