using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public int maxHealth;
    public int health;
    public int damage;

    public List<GameObject> attacks;
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

    public void Attack(Vector3 pos, int index)
    {
        GameObject attack = GameObject.Instantiate(attacks[index], pos, Quaternion.identity);
        attack.GetComponent<Hitbox>().InitializeDamage(damage);
        if (attack.GetComponent<Flipping>() != null)
            attack.GetComponent<Flipping>().SetParent(transform);
    }

    public void Attack(Vector3 pos, Vector3 parent, int index)
    {
        Vector2 vectorToTarget = parent - pos;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        GameObject attack = GameObject.Instantiate(attacks[index], pos, Quaternion.Slerp(transform.rotation, q, 1));
        attack.GetComponent<Hitbox>().InitializeDamage(damage);
        
        if (attack.GetComponent<Flipping>() != null)
            attack.GetComponent<Flipping>().SetParent(transform);
    }

    public void ShootAttack(Vector3 pos, Transform target, int index)
    {
        GameObject attack = GameObject.Instantiate(attacks[index], pos, Quaternion.identity);
        attack.GetComponent<Hitbox>().InitializeDamage(damage);
        attack.GetComponent<Projectile>().SetTarget(target);
        if (attack.GetComponent<Flipping>() != null)
            attack.GetComponent<Flipping>().SetParent(transform);
    }

    public void ShootAttack(Vector2 pos, Vector2 targetPos, int index)
    {
        GameObject attack = GameObject.Instantiate(attacks[index], pos, Quaternion.identity);
        attack.GetComponent<Hitbox>().InitializeDamage(damage);
        attack.GetComponent<Projectile>().SetTarget(targetPos);
        if (attack.GetComponent<Flipping>() != null)
            attack.GetComponent<Flipping>().SetParent(transform);
    }

    public void ExplodeAttack(Vector2 pos, int index)
    {
        GameObject attack = GameObject.Instantiate(attacks[index], pos, Quaternion.identity);
        attack.GetComponent<Hitbox>().InitializeDamage(damage * 5);
    }

    public void BossAttack(Vector2 targetos, int index)
    {

    }

    public void BossAttack(Vector2 pos, Vector2 targetPos, int index)
    {
        GameObject attack = GameObject.Instantiate(attacks[index], pos, Quaternion.identity);
        attack.GetComponent<Projectile>().SetTarget(targetPos);
        if(attack.GetComponent<Flipping>() != null)
        attack.GetComponent<Flipping>().SetParent(transform);
    }

    private void Die()
    {
        if(dropOnDeath != null)
        {
            Instantiate(dropOnDeath, transform.position, Quaternion.identity).GetComponent<Pickup>().InstantiateAmount(amountdropped);
        }
        
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
