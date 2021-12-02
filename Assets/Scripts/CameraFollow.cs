using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform _target;

    private void Update()
    {
        var position = transform.position;
        transform.position = new Vector3(position.x, position.y, _target.position.z - 5);
    }
}
