using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float damage;
    private void OnCollisionEnter(Collision collision)
    {
        Transform hitTransform = collision.transform;
        if (hitTransform.CompareTag("Player") || collision.gameObject.CompareTag("enemy"))
        {
            Debug.Log("Hit Player");
            hitTransform.GetComponent<Health>().TakeDamage(damage);
        }
        Destroy(gameObject);
    }

}

public interface Health
{
    void TakeDamage(float damage);
}
