using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    public float VerticalSpeed;
    public Vector3 ObjectVelocity = Vector3.down;

    [SerializeField]
    [Range(0f, 6f)]
    private float _maxHorizontalSpeed;
    
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(ObjectVelocity.x, ObjectVelocity.y * VerticalSpeed) * Time.deltaTime;

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
        
        

        


        if (transform.position.x + transform.localScale.x >= CubeController.Instance.transform.position.x - CubeController.Instance.transform.localScale.x / 2f 
            && transform.position.x - transform.localScale.x <= CubeController.Instance.transform.position.x + CubeController.Instance.transform.localScale.x / 2f
                && transform.position.y - transform.localScale.y <= CubeController.Instance.transform.position.y + CubeController.Instance.transform.localScale.y / 2f
                    && transform.position.y + transform.localScale.y >= CubeController.Instance.transform.position.y - CubeController.Instance.transform.localScale.y / 2f)
                    {

                        //Hit the Paddle
                        ObjectVelocity.y = -ObjectVelocity.y;
                        ObjectVelocity.x = Random.Range(-_maxHorizontalSpeed, _maxHorizontalSpeed);

                    }       
        

    }

}
