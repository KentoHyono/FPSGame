 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneContoller : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int enemyNum = 10;

    [SerializeField] private GameObject iguanaPrefab;
    [SerializeField] private int iguanaNum = 10;
    [SerializeField] private Transform iguanaSpawnPt;

    [SerializeField] private UIContoller ui;
    private int score = 0;

    private Vector3 spawnPoint = new Vector3(0, 0, 5);
    private GameObject[] enemies;
    private GameObject[] iguanas;

    // Start is called before the first frame update
    void Start()
    {
        enemies = new GameObject[enemyNum];
        iguanas = new GameObject[iguanaNum];
        spawnIguanas();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < enemyNum; i ++) {
            if (enemies[i] == null)
            {
                enemies[i] = Instantiate(enemyPrefab) as GameObject;
                enemies[i].transform.position = spawnPoint;
                WanderingAI ai = enemies[i].GetComponent<WanderingAI>();
                ai.SetDifficulty(GetDifficulty());
                float angle = Random.Range(0, 360);
                enemies[i].transform.Rotate(0, angle, 0);
            }
        }
    }

    private void Awake()
    {
        Messenger.AddListener(GameEvent.ENEMY_DEAD, OnEnemyDead);
        Messenger<int>.AddListener(GameEvent.DIFFICULTY_CHANGED, OnDifficultyChanged);
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.ENEMY_DEAD, OnEnemyDead);
        Messenger<int>.RemoveListener(GameEvent.DIFFICULTY_CHANGED, OnDifficultyChanged);
    }

    private void OnEnemyDead()
    {
        score++;
        ui.updateScore(score);
    }

    private void OnDifficultyChanged(int newDifficulty)
    {
        Debug.Log("Scene.OnDifficultyChanged(" + newDifficulty + ")");
        for (int i = 0; i < enemies.Length; i ++)
        {
            WanderingAI ai = enemies[i].GetComponent <WanderingAI>();
            ai.SetDifficulty(newDifficulty);
        }
    }

    private void spawnIguanas()
    {
        for (int i = 0; i < iguanaNum; i ++)
        {
            iguanas[i] = Instantiate(iguanaPrefab) as GameObject;
            iguanas[i].transform.position = iguanaSpawnPt.position;
            float angle = Random.Range(0, 360);
            iguanas[i].transform.Rotate(0, angle, 0);

        }
    }

    public int GetDifficulty()
    {
        return PlayerPrefs.GetInt("difficulty", 1);
    }
}
