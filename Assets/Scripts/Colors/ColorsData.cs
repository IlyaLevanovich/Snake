using UnityEngine;

[CreateAssetMenu(fileName = "ColorStorage", menuName = "Colors Storage", order = 51)]
public class ColorsData : ScriptableObject
{
    [SerializeField] private Color32[] _data;
    public Color32[] Data => _data;
}
