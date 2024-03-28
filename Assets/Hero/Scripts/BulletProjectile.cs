using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody _bulletRigidbody;
    public GameObject _owner;

    void Awake()
    {
        _bulletRigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        _bulletRigidbody.velocity = transform.forward * speed;
    }

    public void OnShooted(GameObject owner)
    {
        _owner = owner;
    }

    void OnTriggerEnter(Collider other)
    {
        var lifeform = other.GetComponent<Lifeform>();
        if (lifeform)
            lifeform.OnHit(_owner);

        Destroy(gameObject);
    }
}
