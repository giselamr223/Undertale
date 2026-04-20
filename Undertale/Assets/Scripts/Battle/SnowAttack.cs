using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowAttack : MonoBehaviour
{
    public GameObject snowBullet;
    public Transform spawnPoint;

    public void ShootSnow()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(snowBullet, spawnPoint.position, Quaternion.identity);
        }

        Debug.Log("Snowdrake lanza nieve ❄️");
    }
}
