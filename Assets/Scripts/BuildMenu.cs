using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildMenu : MonoBehaviour {

    public Button WallButton;
    public Button LintelButton;
    public Button HalfWallButton;
    public Button ComboWallButton;

	// Use this for initialization
	void Start () {
        WallButton.onClick.AddListener(WallButtonClick);
        LintelButton.onClick.AddListener(LintelButtonClick);
        HalfWallButton.onClick.AddListener(HalfWallButtonClick);
        ComboWallButton.onClick.AddListener(ComboWallButtonClick);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void WallButtonClick()
    {
        UIGridLocator.UIEquipText = "Wall";
    }
    void LintelButtonClick()
    {
        UIGridLocator.UIEquipText = "Lintel";
    }

    void HalfWallButtonClick()
    {
        UIGridLocator.UIEquipText = "Half Wall";
    }

    void ComboWallButtonClick()
    {
        UIGridLocator.UIEquipText = "Combo Wall";
    }
}
