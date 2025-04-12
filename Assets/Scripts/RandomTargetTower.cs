using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTargetTower : Tower
{
    protected override Enemy FindClosestEnemy()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        List<Enemy> validEnemies = new List<Enemy>();

        foreach (Enemy e in enemies)
        {
            if (Vector3.Distance(transform.position, e.transform.position) <= _range)
            {
                validEnemies.Add(e);
            }
        }

        if (validEnemies.Count > 0)
        {
            int randomIndex = Random.Range(0, validEnemies.Count);
            return validEnemies[randomIndex];
        }

        return null;
    }
}

