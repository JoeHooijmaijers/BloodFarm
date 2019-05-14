using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroPanel : MonoBehaviour
{
    public GameEvent pause;
    public GameEvent unPause;

    public GameObject nextPanel;
    // Start is called before the first frame update
    void Start()
    {
        pause.Raise();
    }

    public void closeScreen()
    {
        gameObject.SetActive(false);
        unPause.Raise();
    }

    public void NextScreen()
    {
        nextPanel.SetActive(true);
        gameObject.SetActive(false);
    }

}
