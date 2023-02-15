using DefaultNamespace;
using UnityEngine;

public class GrenadeThrow : MonoBehaviour
{
    [SerializeField] private float throwForce = 50f;
    [SerializeField] private GameObject grenadePrefab;

    private void Update()
    {
        // if (Input.GetMouseButtonDown(0))
        if (Input.GetMouseButtonDown(0))
        {
            GrenadeThrowForward();
        }
    }

    private void GrenadeThrowForward()
    {
        // создаём экземпляр гранаты
        GameObject grenade = Instantiate(grenadePrefab, transform.position, transform.rotation);
        
        // берём из нёе Rigidbody
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        
        // задаём толчок силы
        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
    }
}