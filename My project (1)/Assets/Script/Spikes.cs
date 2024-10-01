using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField] private int damageGiven = 1;
    [SerializeField] private float knockbackForce = 200f;
    [SerializeField] private float upwardForce = 100f;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerMovement>().TakeDamage(damageGiven);

            if (other.transform.position.x > transform.position.x)
            {
                other.gameObject.GetComponent<PlayerMovement>().TakeKnockback(knockbackForce, upwardForce);
            }
            else
            {
                other.gameObject.GetComponent<PlayerMovement>().TakeKnockback(-knockbackForce, upwardForce);
            }
        }
    }
}
