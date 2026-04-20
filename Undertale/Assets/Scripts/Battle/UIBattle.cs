using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIBattle : MonoBehaviour
{
    public GameObject fightButton;
    public GameObject actButton;
    public GameObject itemButton;
    public GameObject mercyButton;

    public TextMeshProUGUI dialogueText;

    public BattleManager battle;

    public void EnableButtons(bool active)
    {
        fightButton.SetActive(active);
        actButton.SetActive(active);
        itemButton.SetActive(active);
        mercyButton.SetActive(active);
    }

    public void ShowText(string text)
    {
        dialogueText.text = text;
    }

    public void OnFight()
    {
        battle.PlayerAction("FIGHT");
    }

    public void OnAct()
    {
        battle.PlayerAction("ACT");
    }
}
