using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject BallPrefab;
    public float RespawnTimer;
    [SerializeField] [Range(0, 15)] private int _maxRespawns;
    public int _respawnCount = 1;
    [SerializeField]private TextMeshProUGUI _ballText;
    [SerializeField] private GameObject _failedPanel;
    [HideInInspector] public bool GameRunning;

    void Start()
    {
        _failedPanel.SetActive(false);
        GameRunning = true;
        Instance = this;
        GameObject ballObject = Instantiate(BallPrefab);
        ballObject.GetComponent<BallBehaviour>().ObjectVelocity = Vector3.down;
        UpdateBallText();
    }   
    public void BallOutOfBounds(GameObject ball)
    {
        Destroy(ball);
        _respawnCount += 1;
        if (_respawnCount < _maxRespawns)
        {
            StartCoroutine(WaitandRespawn());
        }
        else
        {
            UpdateBallText();
            _failedPanel.SetActive(true);
            GameRunning = false;
        }
    }
    private IEnumerator WaitandRespawn()
    {
        UpdateBallText();
        GameObject ballObject = Instantiate(BallPrefab);
        ballObject.GetComponent<BallBehaviour>().ObjectVelocity = Vector3.zero;
        yield return new WaitForSeconds(RespawnTimer);
        ballObject.GetComponent<BallBehaviour>().ObjectVelocity = Vector3.down;
    }

    private void UpdateBallText()
    {
        _ballText.text = "Balls Remaining: " + (_maxRespawns - _respawnCount) + " / 3";
    }
}
