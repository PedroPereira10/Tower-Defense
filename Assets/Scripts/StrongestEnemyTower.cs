using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongestEnemyTower : Tower
{
    protected override Enemy FindClosestEnemy()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Enemy strongest = null;
        float maxHealth = 0;

        foreach (Enemy e in enemies)
        {
            float dist = Vector3.Distance(transform.position, e.transform.position);
            if (dist <= _range && e.Health > maxHealth)
            {
                strongest = e;
                maxHealth = e.Health;
            }
        }

        return strongest;
    }
}

