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

public enum Team
{
    TeamA,
    TeamB
}

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public List<Transform> transforms = new List<Transform>();
    [HideInInspector]
    public int[] Player = new int[5];
    [HideInInspector]
    public Mode mode;
    [HideInInspector]
    public Team team;

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
    MiniMap map;

    [SerializeField]
    private GameObject Plane;
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
    [SerializeField]
    private GameObject obstacle;
    [SerializeField]
    private GameObject A;
    [SerializeField]
    private GameObject B;
    [SerializeField]
    private GameObject PlayerA;
    [SerializeField]
    private GameObject PlayerB;

    private void Start()
    {
        Instance = this;
        isEnd = false;
        Passer.Instance.Setting();
        manager = FindObjectOfType<UIManager>();
        map = FindObjectOfType<MiniMap>();
        Spawn(obstacle, 50, 85, Plane.transform);
        if (SceneManager.GetActiveScene().name == "Polisi2an" || SceneManager.GetActiveScene().name == "DelikJepung")
            Spawn(coin, 50f, 100, transform);
        if (SceneManager.GetActiveScene().name != "Benteng" || SceneManager.GetActiveScene().name != "Boy2an")
        {
            Setup();
        }
        else
            SetupTeam();
        foreach (iDSetup iD in FindObjectsOfType<iDSetup>())
        {
            iD.Setup(i + 1);
            i++;
        }
        foreach(EnemyMovement enemy in FindObjectsOfType<EnemyMovement>())
        {
            enemies.Add(enemy);
        }
        SpawnWaypoints(50f, 100);
        for(int i = 0; i < enemies.Count; i++)
        {
            enemies[i].Setup(true, transforms);
        }
        
        if(SceneManager.GetActiveScene().name == "Base2an")
        {
            BasePooling pooling = GetComponent<BasePooling>();
            StartCoroutine(BaseRandom(pooling, 50f, "Seek"));
            StartCoroutine(BaseRandom(pooling, 50f, "Hide"));
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

    public void SetupTeam()
    {
        switch (team)
        {
            case Team.TeamA:
                Spawn(A, 50f, 2, null);
                Spawn(PlayerA, 50f, 1, null);
                Spawn(B, 50f, 3, null);
                break;
            case Team.TeamB:
                Spawn(A, 50f, 3, null);
                Spawn(B, 50f, 2, null);
                Spawn(PlayerB, 50f, 1, null);
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
            if(genEnemy.layer == LayerMask.NameToLayer("Sight"))
            {
                map.Player = genEnemy;
            }
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

    private IEnumerator BaseRandom(BasePooling pooling, float radius, string name)
    {
        while (true)
        {
            for (int i = 0; i < 3; i++)
            {
                Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * radius;
                randomDirection += transform.position;
                NavMeshHit hit;
                NavMesh.SamplePosition(randomDirection, out hit, radius, 1);
                Vector3 pos = new Vector3(hit.position.x, 0.1f, hit.position.z);
                GameObject baseA = pooling.GetPooledObject(name, pos);
            }
            yield return new WaitForSecondsRealtime(20f);
            for (int i = 0; i < 3; i++)
            {
                GameObject baseA = pooling.RemovePooledObject(name);
            }
            yield return null;
        }
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
