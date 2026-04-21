using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIBattle : MonoBehaviour
{
    //Creamos un Game object de cada botón
    public GameObject fightButton;
    public GameObject actButton;
    public GameObject itemButton;
    public GameObject mercyButton;
    //Llamamos a la textMesh del dialogo
    public TextMeshProUGUI dialogueText;
    //objeto de battleManager
    public BattleManager battle;
    //String para cada opción
    private string[] options = { "FIGHT", "ACT", "ITEM", "MERCY" };
    private int selectedIndex = 0;
    //Índice inicializado en 0

    void Start()
    {
        //se actualizará nada más empezar
        UpdateUI();
    }

    void Update()
    {
        //Se actualizará en cada frame
        HandleInput();
    }

    void HandleInput()
    {
        if (!battle) return;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            selectedIndex--;
            if (selectedIndex < 0) selectedIndex = options.Length - 1;
            UpdateUI();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            selectedIndex++;
            if (selectedIndex >= options.Length) selectedIndex = 0;
            UpdateUI();
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Tab))
        {
            SelectOption();
        }
    }

    void SelectOption()
    {
        string choice = options[selectedIndex];
        battle.PlayerAction(choice);
    }

    void UpdateUI()
    {
        dialogueText.text =
            (selectedIndex == 0 ? "> " : "  ") + "FIGHT\n" +
            (selectedIndex == 1 ? "> " : "  ") + "ACT\n" +
            (selectedIndex == 2 ? "> " : "  ") + "ITEM\n" +
            (selectedIndex == 3 ? "> " : "  ") + "MERCY";
    }

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
}