using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControls : MonoBehaviour
{
    [SerializeField]
    private GameObject storeWindow;

    [SerializeField]
    private GameObject seedStoreWindow;

    [SerializeField]
    private GameObject itemStoreWindow;

    [SerializeField]
    private GameObject upgradeStoreWindow;

    [SerializeField]
    private GameObject briberyWindow;

    [SerializeField]
    private GameObject optionsMenu;

    [SerializeField]
    private GameObject bloodTitheMenu;

    [SerializeField]
    private GameObject vampireMessage;

    [SerializeField]
    private Text vampireText;

    [SerializeField]
    private GameObject deathScreen;

    //[SerializeField]
    //private RectTransform HealthBarOutline;

    //[SerializeField]
    //private RectTransform HealthBar;

    private List<string> messages = new List<string>();
    private List<string> angryMessages = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        storeWindow.SetActive(false);
        optionsMenu.SetActive(false);
        bloodTitheMenu.SetActive(false);
        vampireMessage.SetActive(false);
        InitializeVampireMessages();
    }

    public void ShowShopWindow()
    {
        storeWindow.SetActive(true);
    }

    public void HideShopWindow()
    {
        storeWindow.SetActive(false);
    }

    public void ShowSeedShopWindow()
    {
        seedStoreWindow.SetActive(true);
    }

    public void HideSeedShopWindow()
    {
        seedStoreWindow.SetActive(false);
    }

    public void ShowItemShopWindow()
    {
        itemStoreWindow.SetActive(true);
    }

    public void HideItemShopWindow()
    {
        itemStoreWindow.SetActive(false);
    }

    public void ShowUpgradeShopWindow()
    {
        upgradeStoreWindow.SetActive(true);
    }

    public void HideUpgradeShopWindow()
    {
        upgradeStoreWindow.SetActive(false);
    }

    public void ShowBriberyWindow()
    {
        briberyWindow.SetActive(true);
    }

    public void HideBriberyWindow()
    {
        briberyWindow.SetActive(false);
    }

    public void ShowOptionsMenu()
    {
        optionsMenu.SetActive(true);
    }

    public void HideOptionsMenu()
    {
        optionsMenu.SetActive(false);
    }

    public void ShowBloodTitheMenu()
    {
        bloodTitheMenu.SetActive(true);
    }

    public void HideBloodTitheMenu()
    {
        bloodTitheMenu.SetActive(false);
    }

    public void ShowVampireMessage()
    {
        vampireMessage.SetActive(true);
        int rnd = Random.Range(0, messages.Count - 1);
        vampireText.color = new Color(255, 255, 255);
        vampireText.text = messages[rnd];
        StartCoroutine(IEHideMessageAfterDelay(5));
    }

    public void ShowAngryVampireMessage()
    {
        vampireMessage.SetActive(true);
        int rnd = Random.Range(0, angryMessages.Count - 1);
        vampireText.color = new Color(188, 50, 50);
        vampireText.text = angryMessages[rnd];
        StartCoroutine(IEHideMessageAfterDelay(5));
    }



    IEnumerator IEHideMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        HideVampireMessage();
    }

    public void InitializeVampireMessages()
    {
        messages.Add("The time for the tithe has come, bring us some blood!");
        messages.Add("We thirst! Bring us your blood!");
        messages.Add("Bring blood sla- erm... Non-consential, upaid worker!");
        messages.Add("We are in need of sustinence, you will oblige us with your life-juices!");
        messages.Add("Give us your man-juice! Erm. blood. Bring us blood. quickly.");
    }

    public void InitializeAngryMessages()
    {
        angryMessages.Add("We've grown tired of your idle actions, we will take the blood ourselves!");
        angryMessages.Add("Your slacky behaviour must needs be punished, it seems!");
        angryMessages.Add("Lazy pests such as yourself must be punished!");
        angryMessages.Add("If you won't give us blood, we will take it by force!");

    }

    public void HideVampireMessage()
    {
        vampireMessage.SetActive(false);
    }

    public void ShowDeathScreen()
    {
        deathScreen.SetActive(true);
    }

    public void HideDeathScreen()
    {
        deathScreen.SetActive(false);
    }

}
