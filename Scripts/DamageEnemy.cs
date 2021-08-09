using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class DamageEnemy : MonoBehaviour
    {
        public int damage = 25;


        private void OnTriggerEnter(Collider other)
        {

            EnemyStats enemyStats = other.GetComponent<EnemyStats>();


            if (enemyStats != null)
            {
                enemyStats.TakeDamage(damage);
            }

        }
        
    }
}