using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class ExitFromScene : MonoBehaviour
    {
        [SerializeField] private string _menuSceneName;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadSceneAsync(_menuSceneName);
            }
        }
    }
}