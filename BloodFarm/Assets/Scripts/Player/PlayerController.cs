using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum FacingDirection
{
    right = 1,
    left
}
[RequireComponent(typeof(Combat))]
public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    [SerializeField]
    private FacingDirection facingDirection;
    private Combat cmb;

    public int seed1, seed2, seed3, seed4;
    public GameObject plantSeed1, plantSeed2, plantSeed3, plantSeed4;
    public GameObject bloodwater;

    private Transform currentTile;

    private SpriteRenderer _renderer;

    public GameEvent plantSeed;
    
    // Start is called before the first frame update
    void Start()
    {
        facingDirection = FacingDirection.left;
        cmb = GetComponent<Combat>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            WaterSeed();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlantSeed1();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            PlantSeed2();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            PlantSeed3();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            PlantSeed4();
        }
    }

    private void Movement()
    {
        float moveX = Input.GetAxisRaw("Horizontal") * (movementSpeed * Time.deltaTime);
        float moveY = Input.GetAxisRaw("Vertical") * (movementSpeed * Time.deltaTime);

        Vector2 targetloc = new Vector2(moveX, moveY);
        if(targetloc.x > 0)
        {
            facingDirection = FacingDirection.right;
            _renderer.flipX = true;
        }
        else if(targetloc.x < 0)
        {
            facingDirection = FacingDirection.left;
            _renderer.flipX = false;
        }
        transform.Translate(targetloc);
        
    }

    private void Attack()
    {
        Vector3 posL = new Vector3(transform.position.x - 1, transform.position.y);
        Vector3 posR = new Vector3(transform.position.x + 1, transform.position.y);
        if(facingDirection == FacingDirection.left)
        {
            cmb.Attack(posL);
        }
        else
        {
            cmb.Attack(posR);
        }
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (Input.GetKeyDown(KeyCode.Alpha1))
    //    {
    //        PlantSeed1();
    //    }else if (Input.GetKeyDown(KeyCode.Alpha2))
    //    {
    //        PlantSeed2();
    //    }else if (Input.GetKeyDown(KeyCode.Alpha3))
    //    {
    //        PlantSeed3();
    //    }else if (Input.GetKeyDown(KeyCode.Alpha4))
    //    {
    //        PlantSeed4();
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentTile = collision.transform;
    }

    public void OfferBlood(int amount)
    {
        cmb.TakeDamage(amount);
    }

    public void ReceiveSeed1()
    {
        seed1++;
    }
    public void ReceiveSeed2()
    {
        seed2++;
    }
    public void ReceiveSeed3()
    {
        seed3++;
    }
    public void ReceiveSeed4()
    {
        seed4++;
    }


    public bool CheckIfTileisClear()
    {
        if(currentTile != null)
        {
            if (currentTile.CompareTag("PlantableTile") && currentTile.GetComponent<PlantableTile>().isFree)
            {

                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public void PlantSeed1()
    {
        if(seed1 > 0 && CheckIfTileisClear())
        {
            Instantiate(plantSeed1, currentTile.position, Quaternion.identity, currentTile);
            seed1--;
            currentTile.GetComponent<PlantableTile>().BecomeOccupied();
        }
    }

    public void PlantSeed2()
    {
        if (seed2 > 0 && CheckIfTileisClear())
        {
            Instantiate(plantSeed2, currentTile.transform.position, Quaternion.identity, currentTile.transform);
            seed2--;
            currentTile.GetComponent<PlantableTile>().BecomeOccupied();
        }
    }

    public void PlantSeed3()
    {
        if (seed3 > 0 && CheckIfTileisClear())
        {
            Instantiate(plantSeed3, currentTile.transform.position, Quaternion.identity, currentTile.transform);
            seed3--;
            currentTile.GetComponent<PlantableTile>().BecomeOccupied();
        }
    }

    public void PlantSeed4()
    {
        if (seed4 > 0 && CheckIfTileisClear())
        {
            Instantiate(plantSeed4, currentTile.transform.position, Quaternion.identity, currentTile.transform);
            seed4--;
            currentTile.GetComponent<PlantableTile>().BecomeOccupied();
        }
    }

    public void WaterSeed()
    {
        Vector3 posL = new Vector3(transform.position.x - 1, transform.position.y);
        Vector3 posR = new Vector3(transform.position.x + 1, transform.position.y);
        if (facingDirection == FacingDirection.left)
        {
            Instantiate(bloodwater, posL, Quaternion.identity, currentTile.transform);
        }
        else
        {
            Instantiate(bloodwater, posR, Quaternion.identity, currentTile.transform);
        }
        cmb.TakeDamage(1);
    }
}
