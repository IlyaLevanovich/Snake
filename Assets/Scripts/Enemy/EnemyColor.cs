using UnityEngine;

public class EnemyColor : MonoBehaviour
{
    [SerializeField] private MeshRenderer[] _meshRenderer;
    private ColorsStorage _storage;
    public UnityEngine.Color MeshColor => _meshRenderer[0].material.color;

    private void Start()
    {
        _storage = FindObjectOfType<ColorsStorage>();
        Color32 newColor = _storage.GetEnemyColor();

        foreach (var item in _meshRenderer)
        {
            item.material.color = newColor;
        }
    }

}
