using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public Color PressedColor; 
    public Vector3 StartPosition, StartScale; 
    public Color _startColor; 
    public float Speed = 2;
    public float MaxPositionX, MinPositionX;
    // Start is called before the first frame update
    void Start()
    {
        _startColor = GetComponent<SpriteRenderer>().color;
        transform.position = StartPosition;
        transform.localScale = StartScale;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKey(KeyCode.LeftArrow) && transform.position.x > MinPositionX && StartScale.x / 2f > MinPositionX)
        {
            transform.position += Vector3.left * Time.deltaTime * Speed;
        }
        if(Input.GetKey(KeyCode.RightArrow) && transform.position.x < MaxPositionX && StartScale.x / 2f < MaxPositionX)
        {
            transform.position += Vector3.right * Time.deltaTime * Speed;
        }


        if(Input.GetKeyDown(KeyCode.Space)){GetComponent<SpriteRenderer>().color = new Color(1, 0, 0); Debug.Log("Hello");}
    }
}
