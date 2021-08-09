using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    [CreateAssetMenu (menuName = "Items/Weapons Item")]

    public class WeaponItem : Item
    {
        public GameObject modelPrefab;
        public bool isUnarmed;

        [Header("Idle Animations")]
        public string right_Hand_Idle;
        public string left_hand_Idle;
        public string th_idle;

        [Header("Attack Animations")]
        public string OH_Light_Attack_1;
        public string OH_Heavy_Attack_1;
        public string th_Light_Attack_01;
        public string th_Light_Attack_02;

        [Header("Stamina Costs")]
        public int baseStamina;
        public float lightAttackMultiplier;
        public float heavyAttackMultiplier;
    }
}
