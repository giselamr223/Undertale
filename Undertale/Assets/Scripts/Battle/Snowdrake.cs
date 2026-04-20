using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowdrake : MonoBehaviour
{
    public int hp = 20;
    public SnowAttack attack;

    public void TakeDamage(int dmg)
    {
        hp -= dmg;
        Debug.Log("Snowdrake HP: " + hp);

        if (hp <= 0)
        {
            Debug.Log("Snowdrake derrotado");
        }
    }

    public void Attack(BattleManager battle)
    {
        StartCoroutine(AttackRoutine(battle));
    }

    IEnumerator AttackRoutine(BattleManager battle)
    {
        attack.ShootSnow();

        yield return new WaitForSeconds(3f);

        battle.EndEnemyTurn();
    }
}