using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoumnSpanwer : MonoBehaviour
{
    [SerializeField] private ColoumnMove coloumnPrefab;
    [SerializeField] private int count;
    [SerializeField] private bool autoExpand = false;
    [SerializeField] private float spawnTime = 3f;
    private Vector3 rPos;
    private GameDifficulty difficulty;

    private Pool<ColoumnMove> pool;

    private void Awake()
    {
        difficulty = new GameDifficulty();
        pool = new Pool<ColoumnMove>(coloumnPrefab, count, transform)
        {
           autoExpand = this.autoExpand
        };
    }
    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(spawnTime);
        CreateColoumn();
        yield return null;
        Repeat();
    }
    private void Repeat()
    {
        StartCoroutine(Spawn());
    }
    private void Update()
    {
        spawnTime = difficulty.ChangeDifficulty();
    }

    private void CreateColoumn()
    {
        rPos.x = 6;
        rPos.y = Random.Range(-2f, 3f);
        rPos.z = 0;

        var colm = pool.GetFreeElement();
        colm.transform.position = rPos;
    }
}
