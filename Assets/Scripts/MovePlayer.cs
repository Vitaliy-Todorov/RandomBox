using UnityEngine;

public class MovePlayer : MonoBehaviour
{ 
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _sensivity = 6;

    private Rigidbody _rigidbody;
    private Transform _camera;
    private float _xRotate;
    private float _yRotate;

    public void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _camera = GetComponentInChildren<Camera>().transform;
    }

    void LateUpdate()
    {
        Rotation();
        Move();
    }

    private void Rotation()
    {
        _xRotate += Input.GetAxis("Mouse X") * _sensivity;
        _yRotate += Input.GetAxis("Mouse Y") * _sensivity;
        _yRotate = Mathf.Clamp(_yRotate, -90, 90);

        _camera.rotation = Quaternion.Euler(-_yRotate, _xRotate, 0f);
        transform.rotation = Quaternion.Euler(0, _xRotate, 0f);
    }
        
    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 moveTo = new Vector3(x, 0, y);

        if (moveTo.magnitude > .01f)
        {
            Quaternion rotation = transform.rotation;
            _rigidbody.velocity = rotation * moveTo * _speed;
        }
    }
}
