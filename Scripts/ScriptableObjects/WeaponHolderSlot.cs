using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{

    public class WeaponHolderSlot : MonoBehaviour
    {
        public Transform parentOverridde;
        public WeaponItem currentWeapon;

        public bool isLeftHandSlot;
        public bool isRightHandSlot;
        public bool isBackSlot;

        public GameObject currentWeaponModel;

        public void UnloadWeapon()
        {
            if(currentWeaponModel != null)
            {
                currentWeaponModel.SetActive(false);
            }
        }
        public void UnloadWeaponANdDestory()
        {
            if (currentWeaponModel != null)
            {
                Destroy(currentWeaponModel);
            }
        }

        public void LoadWeaponModel(WeaponItem weaponItem)
        {
            UnloadWeaponANdDestory();

            if (weaponItem == null)
            {
                return;

            }
            GameObject model = Instantiate(weaponItem.modelPrefab) as GameObject;

            if (model != null)
            {
                if (parentOverridde != null)
                {
                    model.transform.parent = parentOverridde;
                }
                else
                {
                    model.transform.parent = transform;
                }

                model.transform.localPosition = Vector3.zero;
                model.transform.localRotation = Quaternion.identity;
                model.transform.localScale = Vector3.one;
            }
            currentWeaponModel = model; 
        }
    }
}
