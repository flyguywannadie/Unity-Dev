using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] float damage = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IDamageable>(out IDamageable player))
        {
            player.Hurt(damage);
        }
    }
}

public interface IDamageable
{
    public void Hurt(float damage);
}
