using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New TestVariableObject", menuName ="UserTest/Variables")]
public class TestVariables : ScriptableObject
{
    public float speed = 4;
    public float xSize = 1;
    public float ySize = 1;
    public Vector3 size;

    private void OnEnable()
    {
        speed = 4.5f;
        xSize = 1;
        ySize = 1;
        SetSize();
    }

    public void SetSize()
    {
        size = new Vector3(xSize, ySize);
    }

    public void IncreaseDifficulty()
    {
        speed += 0.3f;
        xSize += 0.05f;
        ySize += 0.05f;

        //speed += 0.5f;
        SetSize();
    }

    public void IncreaseSpeed()
    {
        speed += 0.1f;
    }
    


}
