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
    int _selfDestroyCounter;
    Vector3 _dir;

    Rigidbody _bulletRigidbody;
    public GameObject _owner;

    void Awake()
    {
        _bulletRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.Translate(_dir * speed);
    }

    public void OnShooted(GameObject owner, Vector3 dir)
    {
        _owner = owner;
        _dir = dir;
        InvokeRepeating("SelfDestroyCheck", 0, 1);
    }

    void SelfDestroyCheck() // TODO se puede mejorar. demora mas de lo que dice
    {
        _selfDestroyCounter++;
        if (_selfDestroyCounter > secondsToSelfDestroy)
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
