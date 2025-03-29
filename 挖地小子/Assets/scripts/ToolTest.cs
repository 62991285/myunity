//using UnityEditor;
//using UnityEngine;
//using UnityEngine.Tilemaps;

//public class TilemapToSpritesConverter2 : EditorWindow
//{
//    [MenuItem("Foretest/debug")]
//    static void Init() => GetWindow<TilemapToSpritesConverter2>().Show();

//    void OnGUI()
//    {
//        if (GUILayout.Button("debug")) ConvertTilemap2();
//    }

//    void ConvertTilemap2()
//    {
//        Tilemap tilemap = Selection.activeGameObject?.GetComponent<Tilemap>();
//        if (!tilemap) { Debug.LogError("请先选中Tilemap"); return; }

//        GameObject parent = new GameObject("Terrain");
//        parent.transform.position = tilemap.transform.position;

//        foreach (Vector3Int pos in tilemap.cellBounds.allPositionsWithin)
//        {
//            TileBase tile = tilemap.GetTile(pos);





//            if (tile is Tile concreteTile)
//            {   
//                Debug.Log($"{concreteTile.sprite.name}");
//               //GameObject tileObj = new GameObject($"Tile_{pos.x}_{pos.y}");

                


//                //    tileObj.transform.position = tilemap.CellToWorld(pos) + tilemap.tileAnchor;
//                //    tileObj.transform.SetParent(parent.transform);
//                //    tileObj.tag = "Block";
//                //    // 添加Sprite渲染器
//                //    SpriteRenderer sr = tileObj.AddComponent<SpriteRenderer>();
//                //    sr.sprite = concreteTile.sprite;
//                //    sr.sortingOrder = tilemap.GetComponent<TilemapRenderer>().sortingOrder;

//                //    // 添加碰撞体
//                //    BoxCollider2D collider = tileObj.AddComponent<BoxCollider2D>();
//                //    if (sr.sprite)
//                //    {
//                //        collider.size = sr.sprite.bounds.size;
//                //        collider.offset = sr.sprite.bounds.center;
//                //    }

//                //    BoxCollider2D collidertrigger = tileObj.AddComponent<BoxCollider2D>();
//                //    collidertrigger.isTrigger = true;
//                //    collidertrigger.offset = new Vector2(0, 0.05f);












//            }
//        }

//        Debug.Log("转换完成，共生成" + parent.transform.childCount + "个Tile");
//    }
//}
