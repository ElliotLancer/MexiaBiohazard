using UnityEngine;

public class ShotgunShoot : MonoBehaviour, IShootPattern
{
    [SerializeField] private int _bulletAmount = 3;
    [SerializeField] private float _spread = 10f;
    public void Shoot(Transform firePoint, GameObject bulletPrefab)
    {
        for (int i = 0; i < _bulletAmount; i++)
        {
            float angle = Random.Range(-_spread, _spread);
            Quaternion rotation = firePoint.rotation * Quaternion.Euler(0, 0, angle);
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, rotation);
            Vector2 dir = rotation * Vector2.up;
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            if(bulletScript != null)
            {
                bulletScript.Shoot(dir);
            }
        }
    }
}
