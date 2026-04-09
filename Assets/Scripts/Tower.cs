using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private float AttackSpeed = 1f;

    private Enemy currentTarget = null;
    private List<Enemy> enemiesInRange = new();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && other.TryGetComponent(out Enemy enemy))
        {
            enemiesInRange.Add(enemy);
            if (currentTarget == null)
            {
                currentTarget = enemy;
                StartCoroutine(AttackCoroutine());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy") && other.TryGetComponent(out Enemy enemy))
        {
            enemiesInRange.Remove(enemy);
            if (currentTarget == enemy)
            {
                currentTarget = null;
                if (enemiesInRange.Count > 0)
                {
                    currentTarget = enemiesInRange[0];
                    StartCoroutine(AttackCoroutine());
                }
            }
        }
    }

    private IEnumerator AttackCoroutine()
    {
        while (true)
        {
            if (currentTarget == null) yield break;

            yield return new WaitForSeconds(AttackSpeed);


        }
    }
}
