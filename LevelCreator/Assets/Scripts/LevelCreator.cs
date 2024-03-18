using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    public Texture2D map;
    public ColorToTile[] colorTiles;

    void Start()
    {
        GenerateLevel();
    }

    private void GenerateLevel()
    {
        for (int x = 0; x < map.width; x++)
        {
            for (int y = 0; y < map.height; y++)
            {
                //check color
                GenTile(x, y);
            }
        } 

    }

    private void GenTile(int x, int y)
    {
        Color pixelColor = map.GetPixel(x, y);

        if(pixelColor.a == 0)
        {
            return; //transparent
        }

        Debug.Log(pixelColor);
        foreach (ColorToTile tile in colorTiles)
        {
            if (tile.color.Equals(pixelColor))
            {
                Vector2 pos = new Vector2(x, y);
                Instantiate(tile.prefab, pos, tile.prefab.transform.rotation, transform);
            }
        }
    }
}
