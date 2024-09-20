using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    public float VerticalSpeed;
    private Vector3 _velocity;

    [SerializeField]
    [Range(0f, 6f)]
    private float _maxHorizontalSpeed;
    
    void Start()
    {
        _velocity = Vector3.down;
        _velocity = new Vector3(0, -1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(_velocity.x, _velocity.y * VerticalSpeed) * Time.deltaTime;

        if (transform.position.x + transform.localScale.x >= CubeController.Instance.MaxPosition.transform.position.x - CubeController.Instance.MaxPosition.transform.localScale.x / 2f
            || transform.position.x - transform.localScale.x <= CubeController.Instance.MinPosition.transform.position.x + CubeController.Instance.MinPosition.transform.localScale.x / 2f)
            {
                    Debug.Log("Bound");
                    _velocity.x = Random.Range(-_maxHorizontalSpeed, _maxHorizontalSpeed);
            }       

        if (transform.position.y + transform.localScale.y >= CubeController.Instance.MaxPosition.transform.position.y - CubeController.Instance.MaxPosition.transform.localScale.x / 2f)
            {
                    Debug.Log("Bound");
                    _velocity.x = Random.Range(-_maxHorizontalSpeed, _maxHorizontalSpeed);
                    _velocity.y = -_velocity.y;
            }     
        

        


        if (transform.position.x + transform.localScale.x >= CubeController.Instance.transform.position.x - CubeController.Instance.transform.localScale.x / 2f 
            && transform.position.x - transform.localScale.x <= CubeController.Instance.transform.position.x + CubeController.Instance.transform.localScale.x / 2f
                && transform.position.y - transform.localScale.y <= CubeController.Instance.transform.position.y + CubeController.Instance.transform.localScale.y / 2f
                    && transform.position.y + transform.localScale.y >= CubeController.Instance.transform.position.y - CubeController.Instance.transform.localScale.y / 2f)
                    {
                        Debug.Log("Circle in Rectangle");
                        _velocity.y = -_velocity.y;
                        _velocity.x = Random.Range(-_maxHorizontalSpeed, _maxHorizontalSpeed);

                    }       
        

    }

}
