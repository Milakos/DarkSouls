using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SG
{
    public class WeaponInventorySlot : MonoBehaviour
    {
        PlayerInventory playerInventory;
        WeaponSlotManager weaponSlotManager;
        UiManager uiManager;
        public Image icon;
        WeaponItem item;

        private void Awake()
        {
            playerInventory = FindObjectOfType<PlayerInventory>();
            weaponSlotManager = FindObjectOfType<WeaponSlotManager>();
            uiManager = FindObjectOfType<UiManager>();
        }

        public void AddItem(WeaponItem newItem)
        {
            item = newItem;
            icon.sprite = item.itemIcon;
            icon.enabled = true;
            gameObject.SetActive(true);

        }

        public void ClearInventorySlot()
        {
            item = null;
            icon.sprite = null;
            icon.enabled = false;
            gameObject.SetActive(false);
        }

        public void EquipThisItem()
        {
            if (uiManager.rightHandSlot01Selected)
            {
                playerInventory.weaponInventory.Add(playerInventory.weaponItemRightHandSlots[0]);
                playerInventory.weaponItemRightHandSlots[0] = item;
                playerInventory.weaponInventory.Remove(item);
                
            }
            else if (uiManager.rightHandSlot02Selected)
            {
                playerInventory.weaponInventory.Add(playerInventory.weaponItemRightHandSlots[1]);
                playerInventory.weaponItemRightHandSlots[1] = item;
                playerInventory.weaponInventory.Remove(item);
            }
            else if (uiManager.leftHandSlot01Selected)
            {
                playerInventory.weaponInventory.Add(playerInventory.weaponItemLeftHandSlots[0]);
                playerInventory.weaponItemLeftHandSlots[0] = item;
                playerInventory.weaponInventory.Remove(item);
            }
            else if ((uiManager.leftHandSlot02Selected))
            {
                playerInventory.weaponInventory.Add(playerInventory.weaponItemLeftHandSlots[1]);
                playerInventory.weaponItemLeftHandSlots[1] = item;
                playerInventory.weaponInventory.Remove(item);
            }
            else { return; }

            playerInventory.rightWeapon = playerInventory.weaponItemRightHandSlots[playerInventory.currentRightWeaponIndex];
            playerInventory.leftWeapon = playerInventory.weaponItemLeftHandSlots[playerInventory.currentLeftWeaponIndex];

            weaponSlotManager.LoadWeaponOnSlot(playerInventory.rightWeapon, false);
            weaponSlotManager.LoadWeaponOnSlot(playerInventory.leftWeapon, true);

            uiManager.equipmentWindowUI.LoadWeaponOnEquipmentScreen(playerInventory);
            uiManager.ResetAllSelectedSlots();
        }
    }
}
