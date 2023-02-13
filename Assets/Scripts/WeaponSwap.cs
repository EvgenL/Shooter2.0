using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class WeaponSwap : MonoBehaviour
    {
        [SerializeField] private GameObject[] weapons;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                weapons[0].SetActive(true);
                weapons[1].SetActive(false);
                weapons[2].SetActive(false);
            }
        }
    }
}