using UnityEngine;

public interface IShootPattern
{
    void Shoot(Transform firePoint, GameObject bulletPrefab);
}
