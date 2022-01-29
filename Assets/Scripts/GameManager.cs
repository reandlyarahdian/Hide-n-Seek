using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public enum Mode
{
    AI,
    PlayerSeek,
    PlayerHide
}

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public List<Transform> transforms = new List<Transform>();
    [HideInInspector]
    public int[] Player = new int[5];
    [HideInInspector]
    public Mode mode;

    public static GameManager Instance;
    
    int[] ID;
    int[] HP;
    int i = 0;
    GameObject transformEmpty;
    List<EnemyMovement> enemies = new List<EnemyMovement>();
    UIManager manager;
    [HideInInspector]
    public bool isPaused = false;
    bool isEnd = false;

    [SerializeField]
    private GameObject enemyChase;
    [SerializeField]
    private GameObject enemyHide;
    [SerializeField]
    private GameObject playerChase;
    [SerializeField]
    private GameObject playerHide;
    [SerializeField]
    private GameObject coin;

    private void Start()
    {
        Instance = this;
        isEnd = false;
        Passer.Instance.Setting();
        manager = FindObjectOfType<UIManager>();
        Spawn(coin, 50f, 200, transform);
        Setup();
        foreach(EnemyMovement enemy in FindObjectsOfType<EnemyMovement>())
        {
            enemies.Add(enemy);
        }
        SpawnWaypoints(50f, 100);
        for(int i = 0; i < enemies.Count; i++)
        {
            enemies[i].Setup(true, transforms);
        }
        foreach(iDSetup iD in FindObjectsOfType<iDSetup>())
        {
            iD.Setup(i + 1);
            i++;
        }
        StartCoroutine(GameTimer(60f));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isEnd)
        {
            isPaused = !isPaused;
            PauseMenu(isPaused);
        }
    }

    public void Setup()
    {
        switch (mode)
        {
            case Mode.AI:
                Spawn(enemyHide, 50f, 4, null);
                Spawn(enemyChase, 20f, 1, null);
                break;
            case Mode.PlayerSeek:
                Spawn(enemyHide, 50f, 4, null);
                Spawn(playerChase, 20f, 1, null);
                break;
            case Mode.PlayerHide:
                Spawn(enemyHide, 50f, 3, null);
                Spawn(playerHide, 50f, 1, null);
                Spawn(enemyChase, 20f, 1, null);
                break;
            default:
                break;
        }
    }

    private void Spawn(GameObject Prefab, float radius, int count, Transform parent)
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * radius;
            randomDirection += transform.position;
            NavMeshHit hit;
            NavMesh.SamplePosition(randomDirection, out hit, radius, 1);
            GameObject genEnemy = Instantiate(Prefab, new Vector3(hit.position.x, 1f, hit.position.z), Quaternion.identity, parent);
        }
    }

    private void SpawnWaypoints(float radius, int count)
    {
        transformEmpty = new GameObject("Way");
        for (int i = 0; i < count; i++)
        {
            Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * radius;
            randomDirection += transform.position;
            NavMeshHit hit;
            NavMesh.SamplePosition(randomDirection, out hit, radius, 1);
            GameObject genTransform = Instantiate(transformEmpty, hit.position, Quaternion.identity, transform);
            transforms.Add(genTransform.transform);
        }
    }

    public void PointAdder(int ID, int Points)
    {
        Player[ID - 1] += Points;
        manager.PointText(ID - 1, ID, Player[ID - 1]);
    }

    public void PauseMenu(bool isPaused)
    {
        if (isPaused)
        {
            manager.MenuObj(isPaused);
            Time.timeScale = 0f;
        }
        else
        {
            manager.MenuObj(isPaused);
            Time.timeScale = 1f;
        }
    }
    
    private void SortingArray(int[] vs)
    {
        List<int> vs1 = vs.OfType<int>().ToList();
        var sorted = vs1
            .Select((x, i) => (Value: x, OriginalIndex: i))
            .OrderByDescending(x => x.Value)
            .ToList();
        List<int> vs2 = sorted.Select(x => x.Value).ToList();
        List<int> vs3 = sorted.Select(x => x.OriginalIndex).ToList();
        ID = vs3.ToArray();
        HP = vs2.ToArray();
    }

    private IEnumerator GameTimer(float seconds)
    {
        while (true)
        {
            if(seconds >= 0)
            {
                seconds -= Time.deltaTime;
                manager.TimerText(seconds);
            }
            else
            {
                isEnd = true;
                SortingArray(Player);
                manager.EndObj(true);
                manager.LeaderBoard(ID, HP);
                Time.timeScale = 0f;
                break;
            }

            yield return null;
        }
    }
}
