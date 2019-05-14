using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float smoothing;
    private int zPos = -10;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FollowTarget();
    }

    void FollowTarget()
    {
        Vector3 targetpos = new Vector3(target.position.x, target.position.y, zPos);
        transform.position = Vector3.Lerp(transform.position, targetpos, smoothing);
    }
}
