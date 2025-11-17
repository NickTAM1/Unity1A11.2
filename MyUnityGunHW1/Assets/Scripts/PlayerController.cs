using System;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Player")]
    [SerializeField] private int _speed = 10;
    [SerializeField] private float _mouseSensitivity = 400f;


    private Rigidbody _rb;
    private Vector3 _moveVector;
    private float _xRotation = 0f;

    [Header("Gun")]
    public Transform _gunTip;
    public GameObject _bulletPrefab;
    public GameObject _bulletPrefabAlternate;

    private void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
        _moveVector = Vector3.zero;

        Camera.main.transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        Camera.main.transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);

        gameObject.transform.Rotate(Vector3.up * mouseX);


        float zMovement = Input.GetAxis("Vertical");
        float xMovement = Input.GetAxis("Horizontal");

        // _moveVector = new Vector3(xMovement, 0f, zMovement)
        _moveVector = transform.right * xMovement + transform.forward * zMovement;

        if (Input.GetButtonDown("Fire1")) Fire(false);
        if (Input.GetButtonDown("Fire2")) Fire(true);
    }

    private void Fire(bool isAlternate)
    {
        Instantiate(isAlternate ? _bulletPrefabAlternate : _bulletPrefab, _gunTip.position, _gunTip.rotation);
    }

    private void FixedUpdate()
    {
        _rb.AddForce(_moveVector * _speed);
    }


}
