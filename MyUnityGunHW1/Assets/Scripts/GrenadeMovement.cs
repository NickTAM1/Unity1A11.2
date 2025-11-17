using UnityEngine;

public class GrenadeMovement : MonoBehaviour
{
    [SerializeField] private float _grenadeSpeed = 15f;
    [SerializeField] private float _explosionTime = 1.5f;
    [SerializeField] private int _bulletCount = 12;
    [SerializeField] private GameObject _grenadeexplosion;
    [SerializeField] private float _explosionBulletLifetime = 2f;

    private Rigidbody _rb;
    private float _timer = 0f;
    private bool _hasExploded = false;


    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
        _rb.AddForce(transform.forward * _grenadeSpeed, ForceMode.Impulse);
    }

    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _explosionTime && !_hasExploded)
        {
            Explode();
        }
    }

    private void Explode()
    {
        _hasExploded = true;

        // Shoot bullets in a circle around the grenade
        float angleStep = 360f / _bulletCount;
        
        for (int i = 0; i < _bulletCount; i++)
        {
            float angle = i * angleStep;
            
            // Calculate direction for each bullet
            Vector3 direction = Quaternion.Euler(0f, angle, 0f) * Vector3.forward;
            Quaternion rotation = Quaternion.LookRotation(direction);

            // Spawn bullet
            GameObject bullet = Instantiate(_grenadeexplosion, transform.position, rotation);
            Destroy(bullet, _explosionBulletLifetime);
        }

        // Destroy the grenade after explosion
        GameObject.Destroy(gameObject);
    }
}
