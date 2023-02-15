using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] private float time = 2f;
    [SerializeField] private UnityEvent onTime;


    // private void Start()
    // {
    //     onTime.Invoke();
    // }

    private void Update()
    {
        time -= Time.deltaTime;
        if (time < 0)
        {
            onTime.Invoke(); // вызывает всё, что подписано на событие UnityEvent onTime
        }
        
        
        // Time.realtimeSinceStartup; - Реальное время с запуска игры
        // Time.time; - Нереальное время с запуска игры: на него влияет Time.timeScale
        // Time.timeScale = 0.5f; - сделать слоу-мо

        // Time.timeSinceLevelLoad; - Время с запуска сцены
    }

    // Для физики было бы так:
    // private void FixedUpdate()
    // {
    //     Time.fixedDeltaTime
    // }
}
