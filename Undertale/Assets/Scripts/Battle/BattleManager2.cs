using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager2 : MonoBehaviour
{
    public enum BattleState { START, PLAYER_TURN, ENEMY_TURN }

    public BattleState state;

    public Snowdrake enemy;
    public UIBattle ui;

    void Start()
    {
        if (enemy == null)
            Debug.LogError("? Snowdrake no asignado en Inspector");

        if (ui == null)
            Debug.LogError("? UI no asignada en Inspector");

        StartBattle();
    }

    void StartBattle()
    {
        state = BattleState.PLAYER_TURN;
        ui.ShowText("¡Un Snowdrake aparece!");
        ui.EnableButtons(true);
    }

    public void PlayerAction(string action)
    {
        if (state != BattleState.PLAYER_TURN) return;

        ui.EnableButtons(false);

        if (action == "FIGHT")
        {
            enemy.TakeDamage(5);
            ui.ShowText("¡Atacas a Snowdrake!");
        }

        StartCoroutine(EnemyTurnDelay());
    }

    IEnumerator EnemyTurnDelay()
    {
        yield return new WaitForSeconds(2f);
        EnemyTurn();
    }

    void EnemyTurn()
    {
        state = BattleState.ENEMY_TURN;
        ui.ShowText("Turno de Snowdrake ??");

        enemy.Attack(this);
    }

    public void EndEnemyTurn()
    {
        state = BattleState.PLAYER_TURN;
        ui.ShowText("Tu turno");
        ui.EnableButtons(true);
    }
}