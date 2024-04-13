using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _targetsContainer;

    private List<Transform> _targets;
    private int _currentIndexTarget;

    private Vector3 _target;

    private void Start()
    {
        Fill();
    }

    private void Update()
    {
        if (transform.position == _target)
            GetNextPlace();
        else
            Move();
    }

    private void Move()
    {
        transform.Translate(_target * _speed * Time.deltaTime);
    }

    private void GetNextPlace()
    {
        _currentIndexTarget++;

        if (_currentIndexTarget >= _targets.Count)
            _currentIndexTarget = 0;

        _target = (_targets[_currentIndexTarget].position - transform.position).normalized;
    }

    private void Fill()
    {
        for (int i = 0; i < _targetsContainer.childCount; i++)
            _targets.Add(_targetsContainer.GetChild(i).transform);
    }
}