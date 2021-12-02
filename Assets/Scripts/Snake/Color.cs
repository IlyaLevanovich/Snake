using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Color : MonoBehaviour
{
    [SerializeField] private MeshRenderer[] _meshRenderer;
    public Color32 CurrentColor { get; private set; }

    public void ChangeColor(Color32 color)
    {
        foreach (var item in _meshRenderer)
        {
            CurrentColor = color;
            item.material.color = CurrentColor;
        }
    }

}
