using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class InstantiateBulletsShooting : MonoBehaviour
{
    [SerializeField] private float _velocityMultiplier;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _objectToShoot;
    [SerializeField] private float _timeWaitShooting;

    void Start()
    {
        StartCoroutine(ShootingWorker());
    }

    private IEnumerator ShootingWorker()
    {
        var time = new WaitForSeconds(_timeWaitShooting);
        bool isWork = enabled;

        while (isWork)
        {
            Vector3 vector3Direction = (_objectToShoot.position - transform.position).normalized;
            GameObject newBullet = Instantiate(_bullet, transform.position + vector3Direction, Quaternion.identity);

            Rigidbody newBulletRigidbody = newBullet.GetComponent<Rigidbody>();

            newBulletRigidbody.transform.up = vector3Direction;
            newBulletRigidbody.velocity = vector3Direction * _velocityMultiplier;

            yield return time;
        }
    }
}