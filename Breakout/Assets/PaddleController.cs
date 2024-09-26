using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public static CubeController Instance;
    public Color PressedColor;
    public Vector3 StartPosition, StartScale;
    private Color _startColor;
    public float Speed;
    public GameObject MaxPosition, MinPosition;

    void Start()
    {
        Instance = this;
        _startColor = GetComponent<SpriteRenderer>().color;
        transform.position = StartPosition;
        transform.localScale = StartScale;
    }
    void Update()
    {
        if (!GameManager.Instance.GameRunning) return;

        if (Input.GetKey(KeyCode.LeftArrow) 
            && transform.position.x - StartScale.x / 2f > MinPosition.transform.position.x)
            transform.position += Vector3.left * Time.deltaTime * Speed;
        if (Input.GetKey(KeyCode.RightArrow) 
            && transform.position.x + StartScale.x / 2f < MaxPosition.transform.position.x)
            transform.position += Vector3.right * Time.deltaTime * Speed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<SpriteRenderer>().color = PressedColor;
            Debug.Log("Hello");
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            GetComponent<SpriteRenderer>().color = _startColor;
        }
    }
}
