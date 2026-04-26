using UnityEngine;
using System.Collections;
public class Gun : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private Transform shellPoint;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject shellPrefab;

    [SerializeField] private float _fireRate = 0.15f;
    [SerializeField] private float _shellForce = 2f;

    [SerializeField] private int _currentAmmo = 10;
    [SerializeField] private int _reserveAmmo = 30;
    [SerializeField] private int _magazineSize = 20;
    [SerializeField] private float _reloadTime = 3f;
    private bool _canShoot = true;
    [SerializeField] private Animator _animator;
    public int CurrentAmmo => _currentAmmo;
    public int MaxAmmo => _magazineSize;
    public float torque = 150f;

    private float lastShootTime;

    private void Update()
    {
        if (_canShoot)
        {
            if (Input.GetMouseButton(0))
            {
                Shoot();
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (_currentAmmo < _magazineSize && _reserveAmmo > 0)
            {
                StartCoroutine(ReloadRoutine());
            }
        }
    }

    private void Shoot()
    {
        if (Time.time < lastShootTime + _fireRate)
            return;
        if (_currentAmmo <= 0)
            return;
        lastShootTime = Time.time;
        _currentAmmo--;
        _animator.SetTrigger("shot");
        ShootBullet();
        SpawnShell();
    }

    private void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Vector2 dir = firePoint.up;
        
        Bullet bulletScript = bullet.GetComponent<Bullet>();

        if (bulletScript != null)
        {
            bulletScript.Shoot(dir);
        }
    }

    private void SpawnShell()
    {
        if (shellPrefab == null || shellPoint == null)
            return;

        GameObject shell = Instantiate(shellPrefab, shellPoint.position, shellPoint.rotation);

        Rigidbody2D shellRb = shell.GetComponent<Rigidbody2D>();

        if (shellRb != null)
        {
            Vector2 shellDir = shellPoint.up + (Vector3)(-firePoint.right * 0.5f);
            shellRb.AddForce(shellDir.normalized * _shellForce, ForceMode2D.Impulse);
            shellRb.AddTorque(torque);
        }
    }
    private void Reload()
    {
        int neededAmmo = _magazineSize - _currentAmmo;
        int ammoToReload = Mathf.Min(neededAmmo, _reserveAmmo);

        _currentAmmo += ammoToReload;
        _reserveAmmo -= ammoToReload;
    }
    private IEnumerator ReloadRoutine()
    {
        Debug.Log("reloading...");
        _canShoot = false;
        yield return new WaitForSeconds(_reloadTime);
        Reload();
        _canShoot = true;

    }
}
