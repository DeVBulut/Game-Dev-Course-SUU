using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    public float VerticalSpeed;
    public Vector3 ObjectVelocity = Vector3.down;
    public List<Transform> brickList = new List<Transform>();
    public GameObject BrickListObject;

    [SerializeField]
    [Range(0f, 6f)]
    private float _maxHorizontalSpeed;
    
    void Start()
    {
            BrickListObject = GameObject.FindGameObjectWithTag("BrickList"); 
            foreach (Transform brick in BrickListObject.transform)
            {
                brickList.Add(brick);
            }   
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.GameRunning) return;
        transform.position += new Vector3(ObjectVelocity.x, ObjectVelocity.y * VerticalSpeed) * Time.deltaTime;

        foreach(Transform brick in brickList)
        {
            if(ObjectHit(brick.transform))
            {
                ObjectVelocity.x = Random.Range(-_maxHorizontalSpeed, _maxHorizontalSpeed);
                ObjectVelocity.y = -ObjectVelocity.y;
                brick.GetComponent<BrickController>().GetHit();
                brickList.Remove(brick);
                return;
            }
        }

        if(brickList.Count == 0)
        {
            GameManager.Instance.PlayerWon();
            ObjectVelocity = Vector3.zero;
            return;
        }

        if(transform.position.y + transform.localScale.y < CubeController.Instance.MinPosition.transform.position.y - CubeController.Instance.MinPosition.transform.position.y / 2f)
        {
            GameManager.Instance.BallOutOfBounds(gameObject);
        }

        if (transform.position.x + transform.localScale.x >= CubeController.Instance.MaxPosition.transform.position.x - CubeController.Instance.MaxPosition.transform.localScale.x / 2f
            || transform.position.x - transform.localScale.x <= CubeController.Instance.MinPosition.transform.position.x + CubeController.Instance.MinPosition.transform.localScale.x / 2f)
            {
                    //Hit the Side Walls
                    ObjectVelocity.x = Random.Range(-_maxHorizontalSpeed, _maxHorizontalSpeed);
            }       

        if (transform.position.y + transform.localScale.y >= CubeController.Instance.MaxPosition.transform.position.y - CubeController.Instance.MaxPosition.transform.localScale.x / 2f)
            {
                    //Hit the Top Wall
                    ObjectVelocity.x = Random.Range(-_maxHorizontalSpeed, _maxHorizontalSpeed);
                    ObjectVelocity.y = -ObjectVelocity.y;
            }     
        
        

        


        if (ObjectHit(CubeController.Instance.gameObject.transform))
                    {
                        //Hit the Paddle
                        ObjectVelocity.y = -ObjectVelocity.y;
                        Vector3 paddleToBall = transform.position - CubeController.Instance.gameObject.transform.position;
                        ObjectVelocity.x = paddleToBall.x * _maxHorizontalSpeed;

                    }       
        

    }

    public bool ObjectHit(Transform collusionTransform)
    {
        return transform.position.x + transform.localScale.x >= collusionTransform.transform.position.x - collusionTransform.transform.localScale.x / 2f
            && transform.position.x - transform.localScale.x <= collusionTransform.transform.position.x + collusionTransform.transform.localScale.x / 2f
                && transform.position.y - transform.localScale.y <= collusionTransform.transform.position.y + collusionTransform.transform.localScale.y / 2f
                    && transform.position.y + transform.localScale.y >= collusionTransform.transform.position.y - collusionTransform.transform.localScale.y / 2f;
    }

}
