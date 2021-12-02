using UnityEngine;

public class Diamond : MonoBehaviour
{
    private float _rotationSpeed;

    private void Start()
    {
        _rotationSpeed = Random.Range(2f, 5f);
    }

    private void Update()
    {
        transform.rotation *= Quaternion.AngleAxis(_rotationSpeed, Vector3.up);
    }
}
