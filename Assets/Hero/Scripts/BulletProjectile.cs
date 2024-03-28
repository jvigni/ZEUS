using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody _bulletRigidbody;

    void Awake()
    {
        _bulletRigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        _bulletRigidbody.velocity = transform.forward * speed;
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
