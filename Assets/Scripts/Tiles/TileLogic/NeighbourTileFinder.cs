using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;

public class NeighbourTileFinder : MonoBehaviour
{
    public Vector2Int[] FindAdjacentTiles(Vector2Int currentTilePosition, Tilemap tilemap)
    {
        List<Vector2Int> neighbours = new List<Vector2Int>();

        if (math.abs(currentTilePosition.y) % 2 == 1) {
            neighbours.Add(new Vector2Int(currentTilePosition.x, currentTilePosition.y + 1));
            neighbours.Add(new Vector2Int(currentTilePosition.x + 1, currentTilePosition.y + 1));
            neighbours.Add(new Vector2Int(currentTilePosition.x - 1, currentTilePosition.y));
            neighbours.Add(new Vector2Int(currentTilePosition.x + 1, currentTilePosition.y));
            neighbours.Add(new Vector2Int(currentTilePosition.x, currentTilePosition.y - 1));
            neighbours.Add(new Vector2Int(currentTilePosition.x + 1, currentTilePosition.y - 1));
        } else {
            neighbours.Add(new Vector2Int(currentTilePosition.x, currentTilePosition.y + 1));
            neighbours.Add(new Vector2Int(currentTilePosition.x - 1, currentTilePosition.y + 1));
            neighbours.Add(new Vector2Int(currentTilePosition.x - 1, currentTilePosition.y));
            neighbours.Add(new Vector2Int(currentTilePosition.x + 1, currentTilePosition.y));
            neighbours.Add(new Vector2Int(currentTilePosition.x, currentTilePosition.y - 1));
            neighbours.Add(new Vector2Int(currentTilePosition.x - 1, currentTilePosition.y - 1));
        }

        // Collect the elements to be removed
        List<Vector2Int> toRemove = new List<Vector2Int>();
        foreach (Vector2Int neighbour in neighbours) {
            if (!tilemap.HasTile((Vector3Int)neighbour)) {
                toRemove.Add(neighbour);
            }
        }

        // Remove the collected elements
        foreach (Vector2Int neighbour in toRemove) {
            neighbours.Remove(neighbour);
        }

        return neighbours.ToArray();
    }
}
