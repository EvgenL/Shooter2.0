using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class Weapon : MonoBehaviour
    {
        // [SerializeField] - говорит о том, что переменную можно редачить в юнити
        [SerializeField] private float force = 4; // сила выстрела
        [SerializeField] private float damage = 1; // урон от выстрела
        [SerializeField] private GameObject impactPrefab; // префаб эффекта попадания
        [SerializeField] private GameObject muzzleFlashPrefab; // префаб эффекта выстрела
        [SerializeField] private Transform shootPoint; // точка, отуда идет выстрел
        [SerializeField] private float spreadConfig = 0.1f;

        // Стандартный юнити метод Update - вызывается каждый кадр
        public void Shoot()
        {
            // Создать эффект выстрела
            CreateMuzzleEffect();

            var spread = SpreadCalculator.CalculateSpread(spreadConfig);
            Vector3 direction = shootPoint.forward + spread;

            // Выпускаем физический луч (Raycast) // Если не попал - выходим из метода
            if (!Physics.Raycast(shootPoint.position, direction, out var hit)) return;

            // Создаём префаб эффекта попадания
            SpawnImpactEffect(hit);

            // Пытаемся получить из объекта, куда попали DestructibleObject
            TryDamageDestructibleObject(hit);

            // Пытаемся получить из объекта, куда попали Rigidbody
            TryPushRigidbody(hit);
        }

        private void CreateMuzzleEffect()
        {
            if (muzzleFlashPrefab == null) return;
            
            var flashEffect = Instantiate(muzzleFlashPrefab, shootPoint);
            Destroy(flashEffect, 0.2f);
        }

        private void TryPushRigidbody(RaycastHit hit)
        {
            var rigidbody = hit.transform.GetComponent<Rigidbody>();
            // если Rigidbody есть то
            if (rigidbody != null)
            {
                // Добавить отбрасывание
                // вызываем AddForce, в который нужно передать
                // 1) направление силы: shootPoint.forward (куда смотрит наше оружие)
                // умноженное на force (силу)
                // 2) ForceMode.Impulse - говорит о том, что мы учитываем вес объекта, к
                // которому добавляем силу
                rigidbody.AddForce(shootPoint.forward * force, ForceMode.Impulse);
            }
        }

        private void TryDamageDestructibleObject(RaycastHit hit)
        {
            var destructible = hit.transform.GetComponent<DestructibleObject>();
            // если DestructibleObject есть то
            if (destructible != null)
            {
                // Нанести урон
                destructible.ReceiveDamage(damage);
            }
        }

        private void SpawnImpactEffect(RaycastHit hit)
        {
            var impactEffect =
                Instantiate(impactPrefab, hit.point, Quaternion.LookRotation(hit.normal, Vector3.up));
            Destroy(impactEffect, 0.5f);
        }

        // Юнити метод, который рисует графику для редактора
        // в нём можно обращаться к классу Gizmos
        // Так же вызвается на каждом кадре, даже когда игра не запущена
        private void OnDrawGizmos()
        {
            // Выставляем красный цвет
            Gizmos.color = Color.red;
            
            // Рисуем луч, идущий из позиции нашего объекта shootPoint, направленный в shootPoint.forward
            // длина луча 9999 метров
            Gizmos.DrawRay(shootPoint.position, shootPoint.forward * 9999);
        }
    }
}