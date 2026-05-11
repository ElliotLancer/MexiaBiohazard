using UnityEngine;

public class SingleShoot : MonoBehaviour, IShootPattern
{
    public void Shoot(Transform firepoint, GameObject bulletPrefab)
    {
        GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        Vector2 dir = firepoint.up;
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null)
        {
            bulletScript.Shoot(dir);
        }
    }
}
