using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridElementModel : ObjectModel
{
    public GridElementState CurrentGridState;
    [SerializeField] GameObject XTextGO;

    public override void Initialize()
    {
        ChangeState(GridElementState.Empty);
    }


    public void ChangeCurrentState()
    {
        switch (CurrentGridState)
        {
            case GridElementState.Empty:
                ChangeState(GridElementState.Filled);
                break;
            case GridElementState.Filled:
                ChangeState(GridElementState.Empty);
                break;
        }

        GridController.Instance.CheckGridsComplete();
    }

    public void ChangeState(GridElementState state)
    {
        CurrentGridState = state;
        switch (state)
        {
            case GridElementState.Empty:
                XTextGO.SetActive(false);
                break;
            case GridElementState.Filled:
                XTextGO.SetActive(true);
                break;
        }
    }
}
