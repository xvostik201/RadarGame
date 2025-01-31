using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Missle : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 5f;

    [SerializeField] private float _velocitySpeed = 4f;

    private Transform _target;

    private Rigidbody _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (_target != null)
        {
            transform.position += transform.forward * _velocitySpeed * Time.deltaTime;
            Vector3 direction = _target.transform.position - transform.position;

            Quaternion targetRotation = Quaternion.LookRotation(direction);

            Quaternion angle = Quaternion.RotateTowards(
                transform.rotation,
                targetRotation,
                _rotationSpeed * Time.deltaTime);

            transform.rotation = Quaternion.Euler(angle.eulerAngles.x, angle.eulerAngles.y, 0);
        }
    }

    public void LaunchMissle(Transform target)
    {
        _target = target;
        transform.parent = null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Взрыв");
        gameObject.SetActive(false);
    }
}
