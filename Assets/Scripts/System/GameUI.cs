using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private GameObject levelUpPopUp;
    [SerializeField]
    private Text nectarText;

    private int nectarAmount;

    void Start()
    {
        GameEvents.instance.onLevelUp += ShowLevelUpPopUp;
        GameEvents.instance.onAddNectar += AddNectar;
        GameEvents.instance.onSubstractNectar += SubstractNectar;
    }

    private void ShowLevelUpPopUp()
    {
        levelUpPopUp.SetActive(true);
        Time.timeScale = 0;
    }

    public void onButtonAddBee()
    {
        levelUpPopUp.SetActive(false);
        Time.timeScale = 1;

        GameEvents.instance.AddBee();
    }

    public void onButtonSpeedUp()
    {
        levelUpPopUp.SetActive(false);
        Time.timeScale = 1;

        GameEvents.instance.SpeedUp();
    }

    private void AddNectar(int amount)
    {
        nectarAmount += amount;
        nectarText.text = nectarAmount.ToString();
    }

    private void SubstractNectar(int amount)
    {
        if (nectarAmount > 0)
        {
            nectarAmount -= amount;
            nectarText.text = nectarAmount.ToString();
        }
    }
}
