using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentScriptCall : MonoBehaviour
{
    public VladBossBehaviour behavior;
    // Start is called before the first frame update
    void Start()
    {
        behavior = GetComponentInParent<VladBossBehaviour>();
    }

    public void CallProjectilePattern1()
    {
        behavior.ProjectilePattern1();
    }

    public void CallProjectilePattern2()
    {
        behavior.ProjectilePattern2();
    }

    public void CallCooldown(float waittime)
    {
        behavior.Cooldown(waittime);
    }
    
    public void CallSetAttackTargetLoc()
    {
        behavior.SetAttackTargetLoc();
    }

    public void CallInvincibility(float invistime)
    {
        behavior.Invincibility(invistime);
    }

    public void CallSlashAttack()
    {
        behavior.SlashAttack();
    }

    public void CallStabAttack()
    {
        behavior.StabAttack();
    }

    public void CallCircularAOESmall()
    {
        behavior.CircularAOEAttackInner();
    }

    public void CallFinalFurySequence()
    {
        behavior.StartFinalFurySequence();
    }

    public void CallFinalFuryAOE()
    {
        behavior.FinalFuryAOELarge();
    }
}
