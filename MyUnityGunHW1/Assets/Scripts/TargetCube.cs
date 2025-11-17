using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class TargetCube : MonoBehaviour
{

    public string bulletTag = "Bullet";

    public bool destroyBulletOnHit = true;

    public ParticleSystem destroyEffect;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag(bulletTag))
        {
            HandleHit(collision.collider.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(bulletTag))
        {
            HandleHit(other.gameObject);
        }
    }

    private void HandleHit(GameObject bullet)
    {
        if (destroyEffect)
        {
            ParticleSystem fx = Instantiate(destroyEffect, transform.position, Quaternion.identity);
            fx.Play();
            Destroy(fx.gameObject, fx.main.startLifetime.constantMax + 0.5f);
        }

        if (destroyBulletOnHit)
        {
            Destroy(bullet);
        }

        Destroy(gameObject);

    }




}
