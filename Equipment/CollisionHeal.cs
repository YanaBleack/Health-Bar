using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHeal : MonoBehaviour
{
    [SerializeField] private int _collisionHeal;
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerHealth playerHealth))
        {
            playerHealth.SetHealth(_collisionHeal);        
            Destroy(gameObject);
        }
    }
}
