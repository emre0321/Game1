using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : ControllerBaseModel
{
    [Header("GRID OLUSTURULACAK ELEMENTIN POOLU")]
    [SerializeField] PoolModel GridElementPool;

    [Header("GRID SISTEMI KACA KAC OLACAK")]
    [SerializeField] int GridNCount;

    [Header("GRID ELEMENTS OFFSET")]
    [SerializeField] float GridVerticalOffset;
    [SerializeField] float GridHorizontalOffset;

    [Header("CURRENT GRID")]
    [SerializeField] List<GridElementModel> CurrentGridElements;


    public List<GridColoumnData> GridColoumnDatas;

    private GameObject GridParent;


    public override void Initialize()
    {
        GenerateGrid(GridNCount);
    }




    public void GenerateGrid(int nCount)
    {
        if (GridParent == null)
        {
            GridParent = new GameObject();
            GridParent.name = "GRIDS";
        }

        ClearGrid();

        for (int i = 0; i < nCount; i++)
        {
            List<GridElementModel> tempHorizontalList = new List<GridElementModel>();

            for (int j = 0; j < nCount; j++)
            {

                GridElementModel tempElement = GridElementPool.GetDeactiveItem<GridElementModel>();
                CurrentGridElements.Add(tempElement);
                tempElement.transform.SetParent(GridParent.transform);
                tempElement.SetActive();
                tempElement.transform.position = new Vector3(j * GridHorizontalOffset, 0, i * GridVerticalOffset);
                tempHorizontalList.Add(tempElement);
            }

            //Horizontal Kolonlarin Datalari setleme
            GridColoumnData tempGridColoumnData = new GridColoumnData();
            tempGridColoumnData.ColoumnType = GridColoumnType.Horizontal;
            tempGridColoumnData.GridElements = tempHorizontalList;

            GridColoumnDatas.Add(tempGridColoumnData);
        }

        // Vertical Kolonlar

        int tempColoumnCount = GridColoumnDatas.Count;

        for (int i = 0; i < tempColoumnCount; i++)
        {
            List<GridElementModel> tempVerticalList = new List<GridElementModel>();

            for (int j = 0; j < tempColoumnCount; j++)
            {
                tempVerticalList.Add(GridColoumnDatas[j].GridElements[i]);
            }

            GridColoumnData tempGridColoumnData = new GridColoumnData();
            tempGridColoumnData.ColoumnType = GridColoumnType.Vertical;
            tempGridColoumnData.GridElements = tempVerticalList;

            GridColoumnDatas.Add(tempGridColoumnData);

        }


    }

    void ClearGrid()
    {
        for (int i = 0; i < CurrentGridElements.Count; i++)
        {
            CurrentGridElements[i].SetDeactive();
            CurrentGridElements[i].transform.SetParent(GridElementPool.transform);
        }
    }


}
