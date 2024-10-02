using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] protected int damageGiven;

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
            other.GetComponent<PlayerMovement>().TakeDamage(damageGiven);
    }
}