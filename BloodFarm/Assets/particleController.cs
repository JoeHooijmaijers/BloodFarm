using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleController : MonoBehaviour
{
    public List<ParticleSystem> particleSystems;

    private void Start()
    {
        DeactivateAllSystems();
    }

    public void ActivateSystem(int index)
    {
        particleSystems[index].Play();
    }

    public void DeactivateSystem(int index)
    {
        particleSystems[index].Stop();
    }

    public void ActivateAllSystems()
    {
        foreach(ParticleSystem p in particleSystems)
        {
            p.Play();
        }
    }

    public void DeactivateAllSystems()
    {
        foreach(ParticleSystem p in particleSystems)
        {
            p.Stop();
        }
    }
}
