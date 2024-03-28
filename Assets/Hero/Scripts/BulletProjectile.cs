using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int damage;
    [SerializeField] ParticleSystem hitExplosion;
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
            lifeform.TakeDamage(damage, gameObject);

        Instantiate(hitExplosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
