using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Health : MonoBehaviour
{

    [SerializeField] int health = 100;

    [SerializeField] GameObject deathVFX;

    public void DealDamage(int damage)
    {

        health -= damage;

        if (health <= 0)
        {
            //AudioSource.PlayClipAtPoint(deathSound, Camera.main, 1f);
            TriggerDeathVFX();
            Destroy(gameObject);

        }

    }


    private void TriggerDeathVFX()
    {
        if (!deathVFX)
            return;

        Destroy(Instantiate(deathVFX, transform.position, transform.rotation), 1f);
    }


}
