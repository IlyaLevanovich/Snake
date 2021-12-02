using UnityEngine;

public class ColorTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _nextTrigger;
    [SerializeField] private GameObject _nextGroup;
    [SerializeField] private ParticleSystem[] _fire;

    private ColorsStorage _storage;
    private MeshRenderer _meshRenderer;
    public Color32 CurrentColor { get; private set; }

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _storage = FindObjectOfType<ColorsStorage>();
    }
    private void Start()
    {
        CurrentColor = _storage.GetRandomColor();
        _meshRenderer.material.color = CurrentColor;
        foreach (var item in _fire)
            item.startColor = CurrentColor;
            
    }

    public void CreateNextTrigger()
    {
        var position = transform.position;
        Instantiate(_nextTrigger, new Vector3(position.x, position.y, position.z + 60), Quaternion.identity);
        _storage.SnakeColor = CurrentColor;
    }

    public void CreateNextGroup()
    {
        var position = transform.position;
        Instantiate(_nextGroup, new Vector3(position.x + Random.Range(-3, 3), position.y, position.z + Random.Range(10, 28)), Quaternion.identity);
        if (Random.value > 0.5f)
            CreateNextGroup();
    }

}
