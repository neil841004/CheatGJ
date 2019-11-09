using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boardManager : MonoBehaviour
{
    // Start is called before the first frame update
    private const float TILE_SIZE = 1.0f;
    private const float TILE_OFFSET = 0.5f;

    public List<GameObject> studentPrefabs;
    private List<GameObject> player;
    private int selectionX = -1;
    private int selectionY = -1;

    private void Update()
    {
        
        DrawChessboard();
    }
    private void DrawChessboard()
    {
        Vector3 widthLine = Vector2.right * 11;
        Vector3 heightLine = Vector2.up * 7;

        for (int i = 0; i <= 7; i++)
        {
            Vector3 start = Vector2.up * i;
            Debug.DrawLine(start, start + widthLine);
            for (int j = 0; j <= 11; j++)
            {
                start = Vector2.right * j;
                Debug.DrawLine(start, start + heightLine);
            }
        }

        //Draw the selection
        if (selectionX >= 0 && selectionY >= 0)
        {
            Debug.DrawLine(
                Vector2.up * selectionY + Vector2.right * selectionX,
                Vector2.up * (selectionY + 1) + Vector2.right * (selectionX + 1));
            Debug.DrawLine(
            Vector2.up * (selectionY + 1) + Vector2.right * selectionX,
            Vector2.up * selectionY + Vector2.right * (selectionX + 1));

        }
    }
    
}
