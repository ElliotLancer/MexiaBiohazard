using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine.Rendering;
public class Gun : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private Transform shellPoint;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject shellPrefab;

    [SerializeField] private float _fireRate = 0.15f;
    [SerializeField] private float _shellForce = 14f;

    [SerializeField] private int _currentAmmo = 10;
    [SerializeField] private int _reserveAmmo = 30;
    [SerializeField] private int _magazineSize = 20;
    [SerializeField] private float _reloadTime;
    [SerializeField] private string _shootAnimationName;
    [SerializeField] private string _idleAnimationName;
    [SerializeField] private int _sortingLayerNumber;
    [SerializeField] private SortingGroup _sorting;
    [SerializeField] private PlayerInteract _interact;
    private IShootPattern _shootPattern;
    private bool _canShoot = true;
    private Coroutine _reloadRoutine;
    public Animator _animator;

    public int CurrentAmmo => _currentAmmo;
    public int MaxAmmo => _magazineSize;
    public float torque = 120f;
    public bool isReloading { get; private set; }

    private float lastShootTime;
    private void Awake()
    {
        _shootPattern = GetComponent<IShootPattern>();
    }
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
                Reload();
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
        ShootBullet();
        SpawnShell();
        _interact.CancelPutInBag();
        
    }

    private void ShootBullet()
    {
        if(_shootPattern == null)
        {
            Debug.Log("There is no IShootPattern on the gun");
            return;
        }
        _shootPattern.Shoot(firePoint, bulletPrefab);
        _animator.Play(_shootAnimationName, 0, 0f);
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
    private void UpdateAmmo()
    {
        int neededAmmo = _magazineSize - _currentAmmo;
        int ammoToReload = Mathf.Min(neededAmmo, _reserveAmmo);

        _currentAmmo += ammoToReload;
        _reserveAmmo -= ammoToReload;
    }
    private void Reload()
    {
        if (isReloading)
            return;
        _reloadRoutine = StartCoroutine(ReloadRoutine());
    }
    private IEnumerator ReloadRoutine()
    {
        isReloading = true;
        _animator.SetTrigger("reload");
        _canShoot = false;
        yield return new WaitForSeconds(_reloadTime);
        UpdateAmmo();
        _canShoot = true;
        isReloading = false;
    }
    public void CancelReload()
    {
        if (_reloadRoutine != null)
            StopCoroutine(_reloadRoutine);
        _animator.ResetTrigger("reload");
        isReloading = false;
        _canShoot = true;
    }
    public void SetAnimationToIdle()
    {
        _animator.Play(_idleAnimationName, 0, 0f);
        _animator.Update(0f);
    }
    public void ChangeWeaponSortingLayer()
    {
        _sorting.sortingLayerName = "Weapon";
        _sorting.sortingOrder = _sortingLayerNumber;
    }
}
