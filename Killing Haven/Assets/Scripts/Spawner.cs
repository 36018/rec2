using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject monster;
    [SerializeField] private Vector2 offset;
    [SerializeField] private Transform target;
    [SerializeField] private float spawnDelay;
    [SerializeField] private float spawnAmount;
    [SerializeField] private Transform parent;
    private float spawned;

    void Start()
    {
        StartCoroutine(StartSpawnCycle());
    }

    void SpawnCubert() { 
    
        Vector3 startPoint = Path.availableWPS[1].transform.position;

        float x = startPoint.x +  Random.Range(-offset.x, offset.x);
        float y = startPoint.y +Random.Range(-offset.y, offset.y);

        Vector3 pos = new Vector3(transform.position.x + x, transform.position.y + y);
        GameObject newMonster = Instantiate(monster, pos, transform.rotation);
    }

    IEnumerator StartSpawnCycle()
    {
        yield return new WaitForSeconds(Random.Range(0f, 4f));
        while(spawned < spawnAmount)
        {
            SpawnCubert();
            yield return new WaitForSeconds(spawnDelay);
            spawned++;
        }
    }
}
