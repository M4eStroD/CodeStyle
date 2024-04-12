using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float _timeShoots = 1f;

    [SerializeField] private Bullet _bullet;

    [SerializeField] private Transform _target;
    [SerializeField] private Transform _bulletSpawn;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        WaitForSeconds wait = new WaitForSeconds(_timeShoots);

        while (true)
        {
            Vector3 direction = (transform.position - _target.position).normalized;

            Bullet bullet = Instantiate(_bullet, _bulletSpawn.position, Quaternion.identity);

            bullet.transform.LookAt(_target);

            yield return wait;
        }
    }
}