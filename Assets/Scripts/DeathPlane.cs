using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class DeathPlane : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            var currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadSceneAsync(currentSceneName);
        }
    }
}