using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHealthBar : MonoBehaviour
{
    public GameObject player;
    private float currentHealth;
    private float maxHealth;
    [SerializeField]
    private float width;
    private RectTransform img;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        img = GetComponent<RectTransform>();
        maxHealth = (float)player.GetComponent<Combat>().maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = (float)player.GetComponent<Combat>().health;

        img.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width * (currentHealth/maxHealth));
    }
}
