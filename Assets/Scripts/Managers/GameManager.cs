using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject EnemyPrefab;
    [SerializeField] private Transform SpawnTransform;
    public Transform Target;

    [SerializeField] private float SpawnTime = 5f;
    private Coroutine enemySpawnCoroutine = null;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        enemySpawnCoroutine = StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(SpawnTime);
            Instantiate(EnemyPrefab, SpawnTransform.position, Quaternion.identity);
        }
    }
}
