using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private PutInBag _enemyBag;
    private void Update()
    {
        if (_enemyBag != null && Input.GetKeyDown(KeyCode.B))
        {
            _enemyBag.Put();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("DeadEnemy"))
            return;

        PutInBag inbag = collision.GetComponentInParent<PutInBag>();
        if (inbag != null)
            _enemyBag = inbag;
            Debug.Log("Can put in bag");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("DeadEnemy"))
            return;

        PutInBag inbag = collision.GetComponentInParent<PutInBag>();
        if (inbag != null && inbag == _enemyBag)
            _enemyBag = null;
    }
}
