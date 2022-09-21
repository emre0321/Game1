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


    private GameObject GridParent;

    public override void Initialize()
    {
        GenerateGrid(GridNCount);
    }




    public void GenerateGrid(int nCount)
    {
        GridParent = new GameObject();
        GridParent.name = "GRIDS";

        for (int i = 0; i < nCount; i++)
        {
            for (int j = 0; j < nCount; j++)
            {
                GridElementModel tempElement = GridElementPool.GetDeactiveItem<GridElementModel>();
                tempElement.SetActive();
                tempElement.transform.position = new Vector3(j*GridHorizontalOffset,0,i*GridVerticalOffset);

            }
        }


    }


}
