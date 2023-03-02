using UnityEngine;

namespace DefaultNamespace
{
    public static class SpreadCalculator
    {
        public static Vector3 CalculateSpread(float spreadConfig)
        {
            var randomX = Random.Range(-spreadConfig / 2, spreadConfig / 2);
            var randomY = Random.Range(-spreadConfig / 2, spreadConfig / 2);
            var spread = new Vector3(randomX, randomY, 0f);

            return spread;
        }
    }
}