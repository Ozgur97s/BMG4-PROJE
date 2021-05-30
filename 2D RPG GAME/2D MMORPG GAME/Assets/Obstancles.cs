using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstancles : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.transform.GetComponent<CharacterStats>().Death();
        }
    }

}
