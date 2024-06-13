using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneContoller : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int enemyNum = 10;

    private Vector3 spawnPoint = new Vector3(0, 0, 5);
    private GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        enemies = new GameObject[enemyNum];
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < enemyNum; i ++) {
            if (enemies[i] == null)
            {
                enemies[i] = Instantiate(enemyPrefab) as GameObject;
                enemies[i].transform.position = spawnPoint;
                float angle = Random.Range(0, 360);
                enemies[i].transform.Rotate(0, angle, 0);
            }
        }
    }
}
