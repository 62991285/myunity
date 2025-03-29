using ConstList;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapToSpritesConverter : EditorWindow
{
    [MenuItem("Tools/Convert Tilemap to Sprites")]
    static void Init() => GetWindow<TilemapToSpritesConverter>().Show();

    void OnGUI()
    {
        if (GUILayout.Button("转换选中的Tilemap")) ConvertTilemap();
    }

    void ConvertTilemap()
    {
        Tilemap tilemap = Selection.activeGameObject?.GetComponent<Tilemap>();
        if (!tilemap) { Debug.LogError("请先选中Tilemap"); return; }

        GameObject parent = new GameObject("Terrain");
        parent.transform.position = tilemap.transform.position;

        foreach (Vector3Int pos in tilemap.cellBounds.allPositionsWithin)
        {
            TileBase tile = tilemap.GetTile(pos);
            if (tile is Tile concreteTile)
            {
                GameObject tileObj = new GameObject($"Tile_{pos.x}_{pos.y}");




                tileObj.transform.position = tilemap.CellToWorld(pos) + tilemap.tileAnchor;
                tileObj.transform.SetParent(parent.transform);




                Debug.Log($"{concreteTile.sprite.name}");
                tileObj.tag = (concreteTile.sprite.name) switch
                {
                    "42_tilemap_54" => TAG.BLOCK,
                    "42_tilemap_55" => TAG.BLOCK,
                    "42_tilemap_56" => TAG.BLOCK,
                    "42_tilemap_57" => TAG.BLOCK,

                    "42_tilemap_14"=>TAG.STONE,
                    "42_tilemap_39" => TAG.HOLLOW,

                    "42_tilemap_77" => TAG.COAL,
                    "42_tilemap_78" => TAG.COPPER,
                    "42_tilemap_79" => TAG.IRON,
                    "42_tilemap_80" => TAG.GOLD,
                    "42_tilemap_81" => TAG.CRYSTAL,
                    "42_tilemap_82" => TAG.PURPLE_GEM,
                    "42_tilemap_83" => TAG.ORENGE_GEM,
                    "42_tilemap_84" => TAG.GREEN_GEM,
                    "42_tilemap_85" => TAG.DIAMOND,
                    _ => TAG.BLOCK,


                };




                // 添加Sprite渲染器
                SpriteRenderer sr = tileObj.AddComponent<SpriteRenderer>();
                sr.sprite = concreteTile.sprite;
                sr.sortingOrder = tilemap.GetComponent<TilemapRenderer>().sortingOrder;

                // 添加碰撞体
                if (tileObj.tag != TAG.HOLLOW)
                {
                    BoxCollider2D collider = tileObj.AddComponent<BoxCollider2D>();

                    if (sr.sprite)
                    {
                        collider.size = sr.sprite.bounds.size;
                        collider.offset = sr.sprite.bounds.center;
                        
                    }

                    
                }
                //添加触发器
                //BoxCollider2D collidertrigger = tileObj.AddComponent<BoxCollider2D>();
                //    collidertrigger.isTrigger = true;
                //    collidertrigger.offset = new Vector2(0, 0.05f);










            }
        }

        Debug.Log("转换完成，共生成" + parent.transform.childCount + "个Tile");
    }
}
