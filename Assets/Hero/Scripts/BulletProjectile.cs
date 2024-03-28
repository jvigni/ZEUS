using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class BulletProjectile : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int damage;
    [SerializeField] ParticleSystem hitExplosion;
    [SerializeField] int secondsToSelfDestroy = 2;
    int selfDestroyCounter;

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
        InvokeRepeating("SelfDestroyCheck", 0, 1);
    }

    void SelfDestroyCheck() // TODO se puede mejorar. demora mas de lo que dice
    {
        selfDestroyCounter++;
        if (selfDestroyCounter > secondsToSelfDestroy)
            Destroy(gameObject);
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
