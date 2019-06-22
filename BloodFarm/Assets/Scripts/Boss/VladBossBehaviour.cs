using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum MoveType
{
    ShortRange = 1,
    MidRange,
    LongRange,
    Teleport,
    Nothing
}
public class VladBossBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject SpawnableSeed;
    [SerializeField]
    private GameObject SpawnableTeleport;
    private Transform target;

    private Vector2 teleportTarget;

    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float attackRangeClose;
    [SerializeField]
    private float attackRangeMid;
    [SerializeField]
    private float attackRangeFar;

    [SerializeField]
    private bool enraged = false;

    [SerializeField]
    private bool FinalFuryUsed = false;

    private Combat cmb;
    private SpriteRenderer _renderer;
    private Animator anim;

    private float resttime = 0.0f;
    private float distance;
    private Vector2 attackTargetLocation;
    private List<Vector2> seedSpawns = new List<Vector2>();

    [SerializeField]
    private MoveType nextMove;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        _renderer = GetComponentInChildren<SpriteRenderer>();
        target = FindObjectOfType<PlayerController>().transform;
        cmb = GetComponent<Combat>();
        PopulateSeedSpawns();
        Debug.Log(seedSpawns);
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(target.position, transform.position);
        if (resttime <= 0)
        {
            Movement();

            if(cmb.health <= (cmb.maxHealth / 2) && FinalFuryUsed == false)
            {
                anim.SetBool("Walking", false);
                anim.SetTrigger("FinalFury");
                FinalFuryUsed = true;
            }

            if(nextMove == MoveType.Nothing)
            {
                SelectNextMove();
            }
            else
            {
                if (nextMove == MoveType.ShortRange && distance <= attackRangeClose)
                {
                    CloseAttack();
                }
                else if (nextMove == MoveType.MidRange && distance <= attackRangeMid)
                {
                    CloseAttack();
                }
                else if (nextMove == MoveType.LongRange && distance <= attackRangeFar)
                {
                    FarAttack();
                }
                else if (nextMove == MoveType.Teleport)
                {
                    SpawnTeleports();
                    Cooldown(11f);
                    nextMove = MoveType.Nothing;
                }
            }
        }
        else
        {
            resttime -= Time.deltaTime;
        }
    }

    private void Movement()
    {

        Vector2 targetLoc = Vector2.MoveTowards(transform.position, target.position, movementSpeed * Time.deltaTime);
        transform.position = targetLoc;
        if(targetLoc != new Vector2(0, 0))
        {
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
        }

        if (target.position.x > transform.position.x)
        {
            _renderer.flipX = true;
        }
        else
        {
            _renderer.flipX = false;
        }
    }

    public void StartFinalFurySequence()
    {
        ProjectilePattern2();
        StartCoroutine(IEFinalFuryPhase1());
    }

    IEnumerator IEFinalFuryPhase1()
    {
        SpawnSeeds();
        ProjectilePattern2();
        yield return new WaitForSeconds(3);
        ProjectilePattern2();
        yield return new WaitForSeconds(3);
        ProjectilePattern2();
        yield return new WaitForSeconds(4);
        ProjectilePattern2();
        StartCoroutine(IEFinalFuryPhase2());
    }

    IEnumerator IEFinalFuryPhase2()
    {
        SpawnTeleports();
        ProjectilePattern1();
        yield return new WaitForSeconds(5);
        ProjectilePattern1();
        yield return new WaitForSeconds(5);
        anim.SetTrigger("FinalFuryAOE");
    }

    public void FinalFuryAOELarge()
    {
        cmb.Attack(transform.position, 4);
    }


    [SerializeField]
    private void SelectNextMove()
    {
        if(distance <= attackRangeClose)
        {
            int x = Random.Range(1, 5);
            if (x < 4)
            {
                nextMove = MoveType.ShortRange;
            }
            else
            {
                nextMove = MoveType.MidRange;
            }
        }
        else if(distance > attackRangeClose && distance <= attackRangeMid)
        {
            int x = Random.Range(1, 10);
            if (x < 4)
            {
                nextMove = MoveType.ShortRange;
            }else if(x >=4 &&x < 8)
            {
                nextMove = MoveType.MidRange;
            }
            else
            {
                nextMove = MoveType.LongRange;
            }
        }
        else if(distance <= attackRangeFar)
        {
            int x = Random.Range(1, 14);
            if (x < 7)
            {
                nextMove = MoveType.LongRange;
            }
            else if(x >= 7 && x < 10)
            {
                nextMove = MoveType.Teleport;
            }
            else
            {
                nextMove = MoveType.ShortRange;
            }
        }
        else
        {
            nextMove = MoveType.Teleport;
        }
        
        
    }

    public void Cooldown(float Amount)
    {
        resttime += Amount;
        nextMove = MoveType.Nothing;
    }

    public void SetAttackTargetLoc()
    {
        attackTargetLocation = target.transform.position;
    }


    private void CloseAttack()
    {
        anim.SetBool("Walking", false);
        ClearAllAnimationTriggers();
        int x = Random.Range(1, 100);
        if (!enraged)
        {
            if (x < 40)
            {
                anim.SetTrigger("SlashAttack");
            }
            else if (x >= 40 && x < 80)
            {
                anim.SetTrigger("StabAttack");
            }
            else
            {
                anim.SetTrigger("CircularAOESmall");
            }
        }
        else
        {
            
        }
    }

    private void MidAttack()
    {
        anim.SetBool("Walking", false);
        ClearAllAnimationTriggers();
        int x = Random.Range(1, 100);
        if (!enraged)
        {
            if(x < 40)
            {

            }else if(x >=40 && x< 80){

            }
            else
            {

            }
        }
        else
        {

        }
    }

    private void FarAttack()
    {
        int x = Random.Range(1, 100);
        anim.SetBool("Walking", false);
        ClearAllAnimationTriggers();
        if (!enraged)
        {
            if(x < 80)
            {
                anim.SetTrigger("Projectiles");
            }
            else
            {
                anim.SetTrigger("Teleport");
            }
        }
        else
        {
            if (x < 80)
            {
                anim.SetTrigger("Projectiles2");
            }
            else
            {
                SpawnTeleports();
                Cooldown(11f);
            }
        }
    }

    private void SpawnSeeds()
    {
        List<Vector2> SeedSpawns = new List<Vector2>();
        int x = Random.Range(0, 3);

        foreach (Vector2 spawn in seedSpawns)
        {
            SeedSpawns.Add(spawn);
        }
        SeedSpawns.RemoveAt(x);
        

        foreach (Vector2 spawn in SeedSpawns)
        {
            GameObject attack = GameObject.Instantiate(SpawnableSeed, spawn, Quaternion.identity);
        }
    }

    private void SpawnTeleports()
    {
        List<Vector2> TeleportSpawns = new List<Vector2>();
        foreach(Vector2 spawn in seedSpawns)
        {
            TeleportSpawns.Add(spawn);
        }
        
        int x = Random.Range(0, 3);
        for (int i = 0; i < 3; i++)
        {
            GameObject attack = GameObject.Instantiate(SpawnableTeleport, TeleportSpawns[i], Quaternion.identity);
            Debug.Log(TeleportSpawns.Count);
            if(i == x)
            {
                attack.GetComponent<VladTeleport>().IsTeleport(true);
                teleportTarget = attack.transform.position;
                StartCoroutine(IETeleport());
            }
            else
            {
                attack.GetComponent<VladTeleport>().IsTeleport(false);
            }
        }
    }

    public void ProjectilePattern1()
    {
        Vector2 target1 = new Vector2(transform.position.x, transform.position.y + 50);
        Vector2 target2 = new Vector2(transform.position.x, transform.position.y -50);
        Vector2 target3 = new Vector2(transform.position.x + 50, transform.position.y);
        Vector2 target4 = new Vector2(transform.position.x - 50, transform.position.y);

        cmb.ShootAttack(transform.position, target1, 0);
        cmb.ShootAttack(transform.position, target2, 0);
        cmb.ShootAttack(transform.position, target3, 0);
        cmb.ShootAttack(transform.position, target4, 0);
    }

    public void ProjectilePattern2()
    {
        Vector2 target1 = new Vector2(transform.position.x, transform.position.y + 50);
        Vector2 target2 = new Vector2(transform.position.x, transform.position.y - 50);
        Vector2 target3 = new Vector2(transform.position.x + 50, transform.position.y);
        Vector2 target4 = new Vector2(transform.position.x - 50, transform.position.y);
        Vector2 target5 = new Vector2(transform.position.x - 50, transform.position.y + 50);
        Vector2 target6 = new Vector2(transform.position.x + 50, transform.position.y - 50);
        Vector2 target7 = new Vector2(transform.position.x + 50, transform.position.y + 50);
        Vector2 target8 = new Vector2(transform.position.x - 50, transform.position.y - 50);

        cmb.ShootAttack(transform.position, target1, 0);
        cmb.ShootAttack(transform.position, target2, 0);
        cmb.ShootAttack(transform.position, target3, 0);
        cmb.ShootAttack(transform.position, target4, 0);
        cmb.ShootAttack(transform.position, target5, 0);
        cmb.ShootAttack(transform.position, target6, 0);
        cmb.ShootAttack(transform.position, target7, 0);
        cmb.ShootAttack(transform.position, target8, 0);
    }

    public void Invincibility(float Invincibility)
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        StartCoroutine(IEInvincibility(Invincibility));
    }

    IEnumerator IEInvincibility(float Invincibility)
    {
        yield return new WaitForSeconds(Invincibility);
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }

    IEnumerator IETeleport()
    {
        yield return new WaitForSeconds(11f);
        transform.position = teleportTarget;
    }

    private void SeedSpawning()
    {
        anim.SetTrigger("SpawnSeeds");
    }

    private void SeedToss()
    {
        anim.SetTrigger("SeedToss");
    }

    private void BloodToss()
    {
        anim.SetTrigger("BloodToss");
    }

    public void CircularAOEAttackInner()
    {
        cmb.Attack(transform.position, 3);
    }

    public void CircularAOEAttackOuter()
    {
        cmb.Attack(transform.position, 4);
    }

    public void StabAttack()
    {
        cmb.Attack(attackTargetLocation, transform.position, 1);
    }

    public void SlashAttack()
    {
        cmb.Attack(attackTargetLocation, transform.position, 2);
    }

    private void Enrage()
    {
        enraged = true;
    }

    private void ClearAllAnimationTriggers()
    {
        anim.ResetTrigger("StabAttack");
        anim.ResetTrigger("SlashAttack");
        anim.ResetTrigger("CircularAOELarge");
        anim.ResetTrigger("CircularAOESmall");
        anim.ResetTrigger("BloodToss");
        anim.ResetTrigger("SeedToss");
        anim.ResetTrigger("BackDashing");
        anim.ResetTrigger("SpawnSeeds");
        anim.ResetTrigger("Projectiles");

    }

    private void PopulateSeedSpawns()
    {
        seedSpawns.Add(new Vector2(4, -3));
        seedSpawns.Add(new Vector2(4, -9));
        seedSpawns.Add(new Vector2(-6, -3));
        seedSpawns.Add(new Vector2(-6, -9));
    }

    private void ProjectileAttack()
    {

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRangeClose);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRangeMid);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attackRangeFar);
    }
}
