using UnityEngine;

public class ColorsStorage : MonoBehaviour
{
    [SerializeField] private ColorsData _colorsData;
    public Color32 SnakeColor { get; set; }

    public Color32 GetRandomColor()
    {
        var returnedColor = _colorsData.Data[Random.Range(0, _colorsData.Data.Length - 1)];
        return returnedColor.ToString() == SnakeColor.ToString() ? GetRandomColor() : returnedColor;
    }
    public Color32 GetEnemyColor()
    {
        return Random.value > 0.5f ? SnakeColor : _colorsData.Data[Random.Range(0, _colorsData.Data.Length - 1)];
    }
}
