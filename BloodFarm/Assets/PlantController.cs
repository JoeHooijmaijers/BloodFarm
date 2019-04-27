using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantController : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float attackRange;
    [SerializeField]
    private float attackDelay;
    [SerializeField]
    private float maxAttackTimer;
    [SerializeField]
    private float attackTimer;

    [SerializeField]
    private float maxSpawnTimer;
    [SerializeField]
    private float spawnTimer;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (InRange() && attackTimer <= 0)
        {
            SpawnAttack(attackDelay);
            attackTimer = maxAttackTimer;
        }
        else
        {
            attackTimer -= Time.deltaTime;
        }

        if(spawnTimer <= 0)
        {
            SpawnMinion();
            spawnTimer = maxSpawnTimer;
        }
        else
        {
            spawnTimer -= Time.deltaTime;
        }
        

    }

    bool InRange()
    {
        float distance = Vector2.Distance(transform.position, target.position);
        if(distance <= attackRange)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SpawnAttack(float delay)
    {
        StartCoroutine(IESpawnAttack(delay));
    }

    IEnumerator IESpawnAttack(float delay)
    {
        Vector2 targetLoc = target.position;
        yield return new WaitForSeconds(delay);
        Combat cmb = GetComponent<Combat>();
        cmb.Attack(targetLoc);
    }

    public void SpawnMinion()
    {
        GetComponent<Combat>().SpawnMinion();
    }
}
