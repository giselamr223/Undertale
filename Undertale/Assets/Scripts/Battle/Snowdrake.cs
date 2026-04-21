using System.Collections;
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
            Debug.Log("Snowdrake derrotado ❄️");
        }
    }

    public void Attack(BattleManager battle)
    {
        if (attack == null)
        {
            Debug.LogError("SnowAttack no asignado en Inspector");
            return;
        }

        StartCoroutine(AttackRoutine(battle));
    }

    IEnumerator AttackRoutine(BattleManager battle)
    {
        Debug.Log("Snowdrake ataca ❄️");

        attack.ShootSnow();

        yield return new WaitForSeconds(3f);

        battle.EndEnemyTurn();
    }
}