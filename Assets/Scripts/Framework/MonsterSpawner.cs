using System.Collections;
using UnityEngine;

public sealed class MonsterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject monster;
    [SerializeField, Range(0, 30)] private float spawnDelay;

    private void Start()
    {
        monster.SetActive(false);
        StartCoroutine(SpawnMonster());
    }

    private IEnumerator SpawnMonster()
    {
        yield return new WaitForSeconds(spawnDelay);
        monster.SetActive(true);
    }
}
