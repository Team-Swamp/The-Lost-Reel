using System.Collections;
using UnityEngine;

public sealed class MonsterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject monsterPrefab;
    [SerializeField, Range(0, 30)] private float spawnDelay;
    [SerializeField] private Transform[] walkPoints;

    private void Start() => StartCoroutine(SpawnMonster());

    private IEnumerator SpawnMonster()
    {
        yield return new WaitForSeconds(spawnDelay);
        var monster = Instantiate(monsterPrefab, transform);
        monster.GetComponent<MonsterStateMachine>().SetWalkPoints(walkPoints);
    }
}
