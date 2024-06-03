using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    [SerializeField] int damage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent<HealthController>(out var player))
        {
            player.Hurt(damage);
        }
    }
}
