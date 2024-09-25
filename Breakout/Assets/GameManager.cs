using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject BallPrefab;
    public float RespawnTimer;
    [SerializeField] [Range(0, 15)] private int _maxRespawns;
    public int _respawnCount;

    void Start()
    {
        Instance = this;
        GameObject ballObject = Instantiate(BallPrefab);
        ballObject.GetComponent<BallBehaviour>().ObjectVelocity = Vector3.down;
        
    }   
    public void BallOutOfBounds(GameObject ball)
    {
        Destroy(ball);
        _respawnCount += 1;

        if (_respawnCount <= _maxRespawns)
        {
            StartCoroutine(WaitandRespawn());
        }
    }
    private IEnumerator WaitandRespawn()
    {
        GameObject ballObject = Instantiate(BallPrefab);
        ballObject.GetComponent<BallBehaviour>().ObjectVelocity = Vector3.zero;
        yield return new WaitForSeconds(2);
        ballObject.GetComponent<BallBehaviour>().ObjectVelocity = Vector3.down;
    }
}
