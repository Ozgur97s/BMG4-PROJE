using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health;

    public void GetDamage(int amount)
    {
        health -= amount;
    }
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }

}