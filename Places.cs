using System.Collections.Generic;
using UnityEngine;

public class Places : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _placesContainer;

    private List<Transform> _places;
    private int _currentIndexPlace;

    private Vector3 _targetPlace;

    private void Start()
    {
        Fill();
    }

    private void Update()
    {
        if (transform.position == _targetPlace)
            GetNextPlace();
        else
            Move();
    }

    private void Move()
    {
        transform.Translate(_targetPlace * _speed * Time.deltaTime);
    }

    private void GetNextPlace()
    {
        _currentIndexPlace++;

        if (_currentIndexPlace >= _places.Count)
            _currentIndexPlace = 0;

        _targetPlace = (transform.position - _places[_currentIndexPlace].position).normalized;
    }

    private void Fill()
    {
        for (int i = 0; i < _placesContainer.childCount; i++)
            _places.Add(_placesContainer.GetChild(i).GetComponent<Transform>());
    }
}