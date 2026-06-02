using UnityEngine;
using System.Collections;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private float _putTime = 3f;
    [SerializeField] private PutInBagUI _progressCircle;
    private float _putTimer;
    private PutInBag _enemyBag;
    private PutInBagUI _currentProgressCirle;
    private void Update()
    {
        if (_enemyBag == null)
        {
            _putTimer = 0f;
            return;
        }
        if (Input.GetKey(KeyCode.B))
        {
            _putTimer += Time.deltaTime;
            _currentProgressCirle.SetProgress(_putTimer / _putTime);
            if(_putTimer >= _putTime)
            {
                _enemyBag.Put();
                _enemyBag = null;
                _putTimer = 0f;
                Destroy(_currentProgressCirle.gameObject);
                _currentProgressCirle = null;
            }
        }
        else
        {
            _putTimer = 0f;
            if(_currentProgressCirle != null)
            {
                _currentProgressCirle.SetProgress(0f);
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
            if(_currentProgressCirle != null)
            {
                Destroy(_currentProgressCirle.gameObject);
            }
            _currentProgressCirle = Instantiate(_progressCircle, inbag.transform.position + Vector3.up, Quaternion.identity);
            _currentProgressCirle.Setup(inbag.transform);
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
            Destroy(_currentProgressCirle.gameObject);
            _enemyBag = null;
        }
    }
    public void CancelPutInBag()
    {
        _putTimer = 0f;
    }
}
