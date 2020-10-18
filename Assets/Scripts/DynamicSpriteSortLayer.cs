using System.Linq;
using UnityEngine;

public class DynamicSpriteSortLayer : MonoBehaviour
{
    public int layerMin = 5;

    [SerializeField]
    SpriteRenderer[] dynamicSortSprites;

    private void Update()
    {
        int currentLayer = layerMin;
        foreach(SpriteRenderer sprite in dynamicSortSprites.ToList().OrderBy(s => s.transform.position.y).Reverse())
        {
            sprite.sortingOrder = currentLayer;
            currentLayer++;
        }
    }
}
