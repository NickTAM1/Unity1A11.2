using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField][Tooltip("Speed of the bullet impulse force")] private float _bulletSpeed = 30f;

    private Rigidbody _rb;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody>();

        _rb.AddForce(transform.forward *  _bulletSpeed, ForceMode.Impulse);

        GameObject.Destroy(gameObject, 2);
    }



}
