using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : ControllerBaseModel
{
    [SerializeField] Camera MainCamera;
    [SerializeField] CinemachineVirtualCamera CMVirtualCamera;

    [Header("Grid Objects Ray Layer")]
    [SerializeField] LayerMask GridObjectsLayer;

    //Raycast Params
    Ray ray;
    RaycastHit hit;

    public override void ControllerUpdate()
    {
        if (InputController.IsTouchActive && Input.GetMouseButtonDown(0))
        {
            ray = MainCamera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out hit, 1000, GridObjectsLayer))
            {
                if (hit.transform.gameObject.GetComponent<GridElementModel>())
                {
                    hit.transform.gameObject.GetComponent<GridElementModel>().ChangeCurrentState();
                    Debug.Log("HIT !");
                }
            }

        }
        
    }

    public void CalculateCameraPos(int gridNCount, float gridOffset)
    {
        float calculatedPos = ((gridNCount * gridOffset) - gridOffset) / 2;
        CMVirtualCamera.transform.position = new Vector3(calculatedPos, CMVirtualCamera.transform.position.y, calculatedPos);
        CMVirtualCamera.m_Lens.OrthographicSize = gridNCount * 1.4f;
    }

}
