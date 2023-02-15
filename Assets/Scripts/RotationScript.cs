using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class RotationScript : MonoBehaviour
    {
        private void Start()
        {
            // создать угол идентично тому, как мы его видим в редакторе - через углы эйлера
            var rot = Quaternion.Euler(45, 0, 0);

            transform.rotation = rot;

            var forward = new Vector3(1, 1, 0); // 
            var up = new Vector3(0, 1, 0); // вектор вверх в юнити прострранстве это всегда Y=1
            transform.rotation = Quaternion.LookRotation(forward, up);
        }
    }
}