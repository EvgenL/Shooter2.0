using System;
using System.Linq;
using UnityEngine;

namespace DefaultNamespace
{
    public class WeaponSwap : MonoBehaviour
    {
        public Weapon CurrentWeapon { get; private set; } // получить может кто угодно, записать могу только я
        [SerializeField] private GameObject[] weapons;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SetWeapon(0);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SetWeapon(1);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                SetWeapon(2);
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                SetWeapon(3);
            }
        }

        private void Start()
        {
            SetWeapon(0);
        }

        private void SetWeapon(int weaponNumber)
        {
            // почитать Linq
            
            for (int i = 0; i < weapons.Length; i++)
            {
                // bool isWeaponCorrect = (i == weaponNumber);
                
                GameObject currentWeapon = weapons[i];

                // Если текущая итерация равна номеру запрошенного оружия, то:
                if (i == weaponNumber)
                {
                    currentWeapon.SetActive(true);
                    CurrentWeapon = currentWeapon.GetComponent<Weapon>();
                }
                else
                {
                    currentWeapon.SetActive(false);
                }
            }
        }
    }
}