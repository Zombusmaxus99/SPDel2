using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{

    [SerializeField] private int damageGiven = 1;
    [SerializeField] private float activationDelay;
    [SerializeField] private float activeTime;

    [SerializeField] private float knockbackForce = 100f;
    [SerializeField] private float upwardForce = 50f;


    private Animator anim;
    private SpriteRenderer spriteRend;

    private bool triggered;
    private bool active;

    private PlayerMovement player;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (!triggered)
                StartCoroutine(ActivateFiretrap());



            player = other.GetComponent<PlayerMovement>();

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        player = null;
    }

    private void Update()
    {
        if (active && player != null)
        {
            player.TakeDamage(damageGiven);

            if (player.transform.position.x > transform.position.x)
            {
                player.gameObject.GetComponent<PlayerMovement>().TakeKnockback(knockbackForce, upwardForce);
            }
            else
            {
                player.gameObject.GetComponent<PlayerMovement>().TakeKnockback(-knockbackForce, upwardForce);
            }
        }
    }

    private IEnumerator ActivateFiretrap()
    {
        triggered = true;
        spriteRend.color = Color.red;

        yield return new WaitForSeconds(activationDelay);
        spriteRend.color = Color.white;
        active = true;
        anim.SetBool("activated", true);

        yield return new WaitForSeconds(activeTime);
        active = false;
        triggered = false;
        anim.SetBool("activated", false);
    }
}
