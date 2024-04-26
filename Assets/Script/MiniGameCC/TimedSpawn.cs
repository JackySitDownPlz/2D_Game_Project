using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpawn : MonoBehaviour
{
    public GameObject spawnee;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;
    public GameObject quad;
    void Start()
    {
        stopSpawning = false;
        StartCoroutine(StartingCoroutine());
    }
    public void SpawnObject()
    {
        MeshCollider c = quad.GetComponent<MeshCollider>();
        float screenX, screenY;
        Vector2 pos;

        screenX = UnityEngine.Random.Range(c.bounds.min.x, c.bounds.max.x);
        screenY = UnityEngine.Random.Range(c.bounds.min.y, c.bounds.max.y);
        pos = new Vector2(screenX, screenY);

        if (Timer.timerIsRunning) 
        { 
            Instantiate(spawnee, pos, transform.rotation); 
        }
        
        else
        {
            stopSpawning = true;
        }

    }
    private System.Collections.IEnumerator StartingCoroutine()
    {
        yield return new WaitForSeconds(spawnTime);
        StartCoroutine(SpawnCoroutine());

    }

    private System.Collections.IEnumerator SpawnCoroutine()
    {
        yield return new WaitForSeconds(spawnDelay);
        if (!stopSpawning)
        {
            SpawnObject();
            StartCoroutine(SpawnCoroutine());
        }
        else
        {
            SpawnObject();
        }
        
    }
}
