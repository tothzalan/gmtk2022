using UnityEngine;
using UnityEngine.Tilemaps;

namespace Util
{
    public static class TilemapFunctions
    {
        public static bool HasTileAtPosition(this Tilemap tilemap, Vector2 position)
        {
            Vector3Int vec = tilemap.WorldToCell(position);
            
            return tilemap.HasTile(vec);
        }
    }
}