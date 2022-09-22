using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : ControllerBaseModel
{
    [SerializeField] InputField GridInputField;
    [SerializeField] Button GridSetButton;
    [SerializeField] Text MatchCountText;




    public void OnInputFieldValueChange()
    {
        Debug.Log("VALUE CHANGED");
        int parsedInt = int.Parse(GridInputField.text);
        if (parsedInt < 3)
        {
            Debug.LogWarning("SHOULD BE MINIMUM 3");
            return;
        }
        GridSetButton.onClick.AddListener(() => GridController.Instance.GenerateGrid(parsedInt));

    }

    public void ScoreUpdate(int score)
    {
        MatchCountText.text = "MATCH COUNT = " + score.ToString();
    }


}
