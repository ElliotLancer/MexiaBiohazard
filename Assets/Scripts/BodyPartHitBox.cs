using UnityEngine;

public class BodyPartHitBox : MonoBehaviour
{
    [SerializeField] private float _multiplier;
    [SerializeField] private ZombieEnemyHealth _health;

    public void TakeHit(int damage)
    {
        int finalDamage = Mathf.RoundToInt(damage * _multiplier);
        _health.takeDamage(finalDamage);
    }
}
