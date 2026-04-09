using UnityEngine;

public class Target : MonoBehaviour
{
    public float Health = 100f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && other.TryGetComponent(out Enemy enemy))
        {
            Health -= enemy.damage;
            Destroy(enemy.gameObject);
        }
    }
}
