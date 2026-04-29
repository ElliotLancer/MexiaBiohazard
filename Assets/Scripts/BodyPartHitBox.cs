using UnityEngine;

public class BodyPartHitBox : MonoBehaviour
{
    [SerializeField] private float _multiplier;
    [SerializeField] private EnemyHealth _health;

    public void TakeHit(int damage)
    {
        int finalDamage = Mathf.RoundToInt(damage * _multiplier);
        _health.takeDamage(finalDamage);
    }
}
