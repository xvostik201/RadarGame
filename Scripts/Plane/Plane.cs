using UnityEngine;
using System.Collections.Generic;

public class Plane : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private List<Transform> _wayPoints = new List<Transform>();

    [HideInInspector] public List<Vector3> Positions = new List<Vector3>();

    private int _currentIndex = 0;

    void Update()
    {
        if (_wayPoints == null || _wayPoints.Count == 0) return;

        Vector3 targetPos = _wayPoints[_currentIndex].position;

        Vector3 direction = (targetPos - transform.position).normalized;
        transform.position += direction * _moveSpeed * Time.deltaTime;

        if (Vector3.Distance(transform.position, targetPos) < 0.1f)
        {
            _currentIndex++;

            if (_currentIndex >= Positions.Count)
            {
                _currentIndex = 0;
            }
        }
    }
}
