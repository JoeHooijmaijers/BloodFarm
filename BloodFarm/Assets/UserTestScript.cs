using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserTestScript : MonoBehaviour
{
    public TestVariables vars;

    private void Start()
    {
        transform.localScale = vars.size;
    }
}
