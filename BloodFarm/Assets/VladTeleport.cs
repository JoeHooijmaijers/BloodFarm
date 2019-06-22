using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VladTeleport : MonoBehaviour
{
    private bool fake = true;

    [SerializeField]
    private List<ParticleSystem> particles;
    [SerializeField]
    private GameObject attack;


    // Start is called before the first frame update
    void Awake()
    {
        DeactivateAllParticles();
    }

    public void IsTeleport(bool real)
    {
        if (real)
        {
            fake = false;
            RealParticles();
            StartCoroutine(IETeleport());
        }
        else
        {
            fake = true;
            FakeParticles();
            StartCoroutine(IEAttack());
        }  
    }

    private void DeactivateAllParticles()
    {
        foreach(ParticleSystem p in particles)
        {
            p.Stop();
        }
    }

    private void FakeParticles()
    {
        particles[0].Play();
        particles[1].Play();
    }

    private void RealParticles()
    {
        particles[0].Play();
        particles[1].Play();
        particles[2].Play();
    }

    IEnumerator IEAttack()
    {
        yield return new WaitForSeconds(10f);
        GameObject Attack = GameObject.Instantiate(attack, transform.position, Quaternion.identity);
        Attack.transform.localScale = new Vector3(6f, 6f);
        Attack.GetComponent<Hitbox>().InitializeDamage(30);
        Destroy(gameObject);
        
    }

    IEnumerator IETeleport()
    {
        yield return new WaitForSeconds(12.5f);
        Destroy(gameObject);
    }
}
