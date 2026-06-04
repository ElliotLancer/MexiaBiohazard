using UnityEngine;
using System.Collections;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private float _putTime = 3f;
    [SerializeField] private PutInBagUI _progressCircle;
    private float _putTimer;
    private PutInBag _enemyBag;
    private PutInBagUI _currentProgressCircle;
    private void Update()
    {
        if (_enemyBag == null)
        {
            return;
        }
        if (Input.GetKey(KeyCode.B))
        {
            if (_currentProgressCircle == null)
            {
                _currentProgressCircle = Instantiate(_progressCircle, _enemyBag.transform.position + Vector3.up, Quaternion.identity);
                _currentProgressCircle.Setup(_enemyBag.EnemyBody);
            }
            _putTimer += Time.deltaTime;
            _currentProgressCircle.SetProgress(_putTimer / _putTime);
            if (_putTimer >= _putTime)
            {
                if (_currentProgressCircle != null)
                {
                    Destroy(_currentProgressCircle.gameObject);
                    _currentProgressCircle = null;
                }
                _enemyBag.Put();

                _currentProgressCircle = null;
                _enemyBag = null;
                _putTimer = 0f;
            }
        }
        else
        {
            _putTimer = 0f;
            if (_currentProgressCircle != null)
            {
                _currentProgressCircle.SetProgress(0f);
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("DeadEnemy"))
            return;

        PutInBag inbag = collision.GetComponentInParent<PutInBag>();
        if (inbag != null)
        {
            _enemyBag = inbag;
            Debug.Log("Can put in bag");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("DeadEnemy"))
            return;

        PutInBag inbag = collision.GetComponentInParent<PutInBag>();
        if (inbag != null && inbag == _enemyBag)
        {
            if (_currentProgressCircle != null)
            {
                Destroy(_currentProgressCircle.gameObject);
                _currentProgressCircle = null;
            }
        }
        _enemyBag = null;
        _putTimer = 0f;
    }
    public void CancelPutInBag()
    {
        _putTimer = 0f;
    }
}
