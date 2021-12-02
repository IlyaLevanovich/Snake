using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    [SerializeField] private Transform[] _bodyPart;
    [SerializeField] private int _maxSpeed;

    [Header("Чем ниже значение - тем плавнее движение по сторонам")]
    [SerializeField, Range(0, 1)] private float _lerpValue;

    private Fever _fever;
    private Rigidbody _rigidbody;
    private Camera _camera;
    

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _fever = GetComponent<Fever>();
        _camera = Camera.main;
    }

    private void FixedUpdate()
    {
        if (_fever.IsFever)
        {
            Fever();
            return;
        }
            
        AddForce(_maxSpeed);
        NormalizedRotation();
        if (Input.GetMouseButton(0))
        {
            Ray castPoint = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(castPoint, out RaycastHit hit))
            {
                _rigidbody.position = Vector3.Lerp(transform.position, new Vector3(hit.point.x / 1.3f, transform.position.y, transform.position.z), _lerpValue);

                transform.rotation = _rigidbody.velocity.x > 0 ? SetRotation(-15) : SetRotation(15);

                if (Mathf.Abs(transform.position.x) >= 3f)
                    NormalizedRotation();
            }
        }
    }
    private Quaternion SetRotation(int angle)
    {
        return Quaternion.Euler(new Vector3(0, angle * Mathf.Clamp(Mathf.Abs(_rigidbody.velocity.x), -3, 3) , 0));
    }
    private void NormalizedRotation()
    {
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }
    private void Fever()
    {
        _rigidbody.position = new Vector3(0, transform.position.y, transform.position.z);
        transform.rotation = Quaternion.Euler(Vector3.zero);
        AddForce(_maxSpeed * 3);
    }
    private void AddForce(int maxSpeed)
    {
        if(_rigidbody.velocity.z < maxSpeed)
            _rigidbody.AddForce(Vector3.forward * _rigidbody.mass * 2, ForceMode.Impulse);
    }
    
}
