using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using System.Runtime.CompilerServices;

public class GridCM
{
    private int width;
    private int height;
    private int[,] gridArray; 
    private float cellSize;
    private TextMesh[,] debugTextArray;
    private Vector3 originPostion;
    public GridCM(int width,int height, float cellSize, Vector3 originPostion)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPostion = originPostion;
        gridArray = new int[width,height];
        debugTextArray = new TextMesh[width,height];


        for (int x=0; x < gridArray.GetLength(0); x++)
        {
            for (int y =0;y< gridArray.GetLength(1); y++)
            {
                debugTextArray[x,y] = UtilsClass.CreateWorldText(gridArray[x, y].ToString(), null, GetWorldPosition(x, y) + new Vector3(cellSize,cellSize) * 0.5f,8, Color.white, TextAnchor.MiddleCenter);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x+1, y), Color.white, 100f);
            }
        }
        Debug.DrawLine(GetWorldPosition(0,height), GetWorldPosition(width, height), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);

        SetValue(2, 1, 56);
    }

    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x,y) * cellSize + originPostion;
    }
    private void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPosition - originPostion).x / cellSize);
        y = Mathf.FloorToInt((worldPosition - originPostion).y / cellSize);
    }
    public void SetValue(int x, int y, int value)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            gridArray[x, y] = value;
            debugTextArray[x, y].text = gridArray[x, y].ToString();
        }
    }
    public void SetValue(Vector3 worldPosition, int Value)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        SetValue(x, y, Value);
    }
    public int GetValue(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            return gridArray[x, y];
            
        }
        else
        {
            return 0;
        }
    }
    public int GetValue(Vector3 worldPosition)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        return GetValue(x, y);
    }
}
