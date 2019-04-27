using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControls : MonoBehaviour
{
    [SerializeField]
    private GameObject storeWindow;

    [SerializeField]
    private RectTransform HealthBarOutline;

    [SerializeField]
    private RectTransform HealthBar;

    // Start is called before the first frame update
    void Start()
    {
        storeWindow.SetActive(false); 
    }

    public void ShowShopWindow()
    {
        storeWindow.SetActive(true);
    }

    public void HideShopWindow()
    {
        storeWindow.SetActive(false);
    }

}
