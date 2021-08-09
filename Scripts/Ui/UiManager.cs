using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SG
{
    public class UiManager : MonoBehaviour
    {
        public PlayerInventory playerInventory;
        public EquipmentWindowUI equipmentWindowUI;

        [Header("UI Windows")]
        public GameObject hudWindow;
        public GameObject selectWindow;
        public GameObject equipmentScreenWindow;
        public GameObject weaponInventoryWindow;

        [Header("Equipment Window Slot Selected")]
        public bool rightHandSlot01Selected;
        public bool rightHandSlot02Selected;
        public bool leftHandSlot01Selected;
        public bool leftHandSlot02Selected;

        [Header("Weapon Inventory")]
        public GameObject weaponInventorySlotPrefab;
        public Transform weaponInventorySlotsParent;
        public WeaponInventorySlot[] weaponInventorySlot;

        private void Awake()
        {
            playerInventory = FindObjectOfType<PlayerInventory>();
            equipmentWindowUI = FindObjectOfType<EquipmentWindowUI>();
        }
        public void Start()
        {
            weaponInventorySlot = weaponInventorySlotsParent.GetComponentsInChildren<WeaponInventorySlot>();
            //equipmentWindowUI.LoadWeaponOnEquipmentScreen(playerInventory);
        }

        public void UpadateUI()
        {
            #region Weapon Inventory Slots
            for (int i = 0; i< weaponInventorySlot.Length; i++)
            {
                if (i < playerInventory.weaponInventory.Count)
                {
                    if (weaponInventorySlot.Length < playerInventory.weaponInventory.Count)
                    {
                        Instantiate(weaponInventorySlotPrefab, weaponInventorySlotsParent);
                        weaponInventorySlot = weaponInventorySlotsParent.GetComponentsInChildren<WeaponInventorySlot>();
                    }
                    weaponInventorySlot[i].AddItem(playerInventory.weaponInventory[i]);
                }
                else
                {
                    weaponInventorySlot[i].ClearInventorySlot();
                }
            }
            #endregion
        }

        public void OpesSelecteWindow()
        {
            selectWindow.SetActive(true);
        }

        public void CloseSelectedWindow()
        {
            selectWindow.SetActive(false);
        }

        public void CloseAllInventoryWindows()
        {
            ResetAllSelectedSlots();
            weaponInventoryWindow.SetActive(false);
            equipmentScreenWindow.SetActive(false);
        }

        public void ResetAllSelectedSlots()
        {
            rightHandSlot01Selected = false;
            rightHandSlot02Selected = false;
            leftHandSlot01Selected = false;
            leftHandSlot02Selected = false;
        }
    }
}
