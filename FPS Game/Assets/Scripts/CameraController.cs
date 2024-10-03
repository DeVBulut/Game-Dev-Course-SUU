using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject _playerCapsule;
    [SerializeField] private float _minVerticalRotation, _maxVerticalRotation;
    [SerializeField] private float _rotationSensitivity;
    private Vector3 _horizontalRotation, _verticalRotation;

    // Start is called before the first frame update
    void Start()
    {
        _playerCapsule = transform.parent.GameObject();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalRotation.y += Input.GetAxis("Mouse X") * Time.deltaTime * _rotationSensitivity * 10;
        _verticalRotation.x += -Input.GetAxis("Mouse Y") * Time.deltaTime * _rotationSensitivity * 10;
        _verticalRotation.x = Mathf.Clamp(_verticalRotation.x, _minVerticalRotation, _maxVerticalRotation);

        _playerCapsule.transform.eulerAngles = _horizontalRotation;
        transform.eulerAngles = new Vector3(_verticalRotation.x, transform.eulerAngles.y);
    }
}
