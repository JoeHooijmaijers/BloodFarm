using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public int maxHealth;
    public int health;
    public int damage;

    public GameObject attack;
    public GameObject spawnable;

    public GameObject dropOnDeath;
    public int amountdropped;

    public GameEvent objectDied;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public void TakeDamage(int Damage)
    {
        health -= Damage;
        if(health <= 0)
        {
            health = 0;
            Die();
        }
    }

    public void GainHealth(int amount)
    {
        health += amount;
        if(health > maxHealth)
        {
            health = maxHealth;
        }
    }

    public bool isFullHealth()
    {
        if(health >= maxHealth)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Attack(Vector3 pos)
    {
        Instantiate(attack, pos, Quaternion.identity).GetComponent<Hitbox>().InitializeDamage(damage);
    }

    private void Die()
    {
        Instantiate(dropOnDeath, transform.position, Quaternion.identity).GetComponent<Pickup>().InstantiateAmount(amountdropped);
        StartCoroutine(IELateDestroy());

        objectDied.Raise();

        if(GetComponent<PlantController>() != null)
        {
            GetComponent<PlantController>().FreeParent();
        }
    }

    IEnumerator IELateDestroy()
    {
        yield return new WaitForEndOfFrame();
        Destroy(gameObject);
    }

    public void SpawnMinion()
    {
        Instantiate(spawnable, transform.position, Quaternion.identity);
    }
}
