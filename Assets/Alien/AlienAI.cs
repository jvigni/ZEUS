using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float movementSpeed;

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;

        transform.position = Vector3.MoveTowards(transform.position, target.position, movementSpeed * Time.deltaTime);
        //transform.rotation = Quaternion.FromToRotation(transform.position, target.position);
        transform.LookAt(target.position);
    }

    public void Init(Transform newTarget)
    {
        target = newTarget;
    }
}
