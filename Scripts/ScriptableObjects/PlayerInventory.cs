using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class PlayerInventory : MonoBehaviour
    {
        WeaponSlotManager weaponSlotManager;

        public WeaponItem rightWeapon;
        public WeaponItem leftWeapon;

        public WeaponItem unarmedWeaponItem;

        public WeaponItem[] weaponItemRightHandSlots = new WeaponItem[1];
        public WeaponItem[] weaponItemLeftHandSlots = new WeaponItem[1];

        public int currentRightWeaponIndex = -1;
        public int currentLeftWeaponIndex = -1;

        public List<WeaponItem> weaponInventory;

        private void Awake()
        {
            weaponSlotManager = GetComponentInChildren<WeaponSlotManager>();

        }
        private void Start()
        {
            rightWeapon = weaponItemRightHandSlots[0];
            leftWeapon = weaponItemLeftHandSlots[0];
            weaponSlotManager.LoadWeaponOnSlot(rightWeapon, false);
            weaponSlotManager.LoadWeaponOnSlot(leftWeapon, true);
        }
        public void ChangeRightWeapon()
        {
            currentRightWeaponIndex = currentRightWeaponIndex + 1;
            if (currentRightWeaponIndex == 0 && weaponItemRightHandSlots[0] != null)
            {
                rightWeapon = weaponItemRightHandSlots[currentRightWeaponIndex];
                weaponSlotManager.LoadWeaponOnSlot(weaponItemRightHandSlots[currentRightWeaponIndex], false);
            }
            else if (currentRightWeaponIndex == 0 && weaponItemRightHandSlots[0] == null)
            {
                currentRightWeaponIndex = currentRightWeaponIndex + 1;
            }
            else if (currentRightWeaponIndex == 1 && weaponItemRightHandSlots[1] != null)
            {
                rightWeapon = weaponItemRightHandSlots[currentRightWeaponIndex];
                weaponSlotManager.LoadWeaponOnSlot(weaponItemRightHandSlots[currentRightWeaponIndex], false);
            }
            else
            {
                currentRightWeaponIndex = currentRightWeaponIndex + 1;
            }
            if (currentRightWeaponIndex > weaponItemRightHandSlots.Length - 1)
            {
                currentRightWeaponIndex = -1;
                rightWeapon = unarmedWeaponItem;
                weaponSlotManager.LoadWeaponOnSlot(unarmedWeaponItem, false);
            }
        }

        public void ChangeLefttWeapon()
        {
            currentLeftWeaponIndex = currentLeftWeaponIndex + 1;
            if (currentLeftWeaponIndex == 0 && weaponItemLeftHandSlots[0] != null)
            {
                leftWeapon = weaponItemLeftHandSlots[currentLeftWeaponIndex];
                weaponSlotManager.LoadWeaponOnSlot(weaponItemLeftHandSlots[currentLeftWeaponIndex], true);
            }
            else if (currentLeftWeaponIndex == 0 && weaponItemLeftHandSlots[0] == null)
            {
                currentLeftWeaponIndex = currentLeftWeaponIndex + 1;
            }
            else if (currentLeftWeaponIndex == 1 && weaponItemLeftHandSlots[1] != null)
            {
                leftWeapon = weaponItemLeftHandSlots[currentLeftWeaponIndex];
                weaponSlotManager.LoadWeaponOnSlot(weaponItemLeftHandSlots[currentLeftWeaponIndex], true);
            }
            else
            {
                currentLeftWeaponIndex = currentLeftWeaponIndex + 1;
            }
            if (currentLeftWeaponIndex > weaponItemLeftHandSlots.Length - 1)
            {
                currentLeftWeaponIndex = -1;
                leftWeapon = unarmedWeaponItem;
                weaponSlotManager.LoadWeaponOnSlot(unarmedWeaponItem, true);
            }
        }
    }
}