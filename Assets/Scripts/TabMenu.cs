using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TileData;

public class TabMenu : MonoBehaviour {

    public GameObject TabMenuDisplay;
    public GameObject FPSController;
    public GameObject PaintMenu;
    public GameObject BuildMenu;
    public GameObject BuyMenu;
    public GameObject TilerScript;
    public Button PaintButton;
    public Button BuildButton;
    public Button BuyButton;
    public Button RoofButton;
    public Text reticle;
    public GameObject CeilingTile;
    public static int CeilingLowestX;
    public static int CeilingLowestY;
    public static int CeilingHighestX;
    public static int CeilingHighestY;
    public static bool DidCeiling;
    public GameObject GridTile;
    public Tiler TileData;


    // Use this for initialization
    void Start () {

       TileData = new Tiler();
        Tiler.CreateGrid();
        
        for (int iX = 0; iX < 50; iX++)
        {
            for (int iY = 0; iY < 50; iY++)
            {
                Instantiate(GridTile, new Vector3(iX, 0, iY), Quaternion.identity);
            }
        }



        PaintButton.onClick.AddListener(PaintButtonClick);
        BuildButton.onClick.AddListener(BuildButtonClick);
        BuyButton.onClick.AddListener(BuyButtonClick);
        RoofButton.onClick.AddListener(RoofButtonClick);

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (TabMenuDisplay.activeSelf == false)
            { 
                TabMenuDisplay.SetActive(true);
                FPSController.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_MouseLook.m_cursorIsLocked = false;
                reticle.text = "";

                if (PlayerEquipmentChange.CurrentEquip == "Painter")
                {
                    PaintMenu.SetActive(true);
                    BuildMenu.SetActive(false);
                    BuyMenu.SetActive(false);
                }
                if (PlayerEquipmentChange.CurrentEquip == "WallBuilder" || PlayerEquipmentChange.CurrentEquip == "WallDestroyer")
                {
                    PaintMenu.SetActive(false);
                    BuildMenu.SetActive(true);
                    BuyMenu.SetActive(false);
                }
                if (PlayerEquipmentChange.CurrentEquip == "HeldObject")
                {
                    PaintMenu.SetActive(false);
                    BuildMenu.SetActive(false);
                    BuyMenu.SetActive(true);
                }
            }
            else
            {
                TabMenuDisplay.SetActive(false);
                FPSController.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_MouseLook.m_cursorIsLocked = true;
                PaintMenu.SetActive(false);
                BuildMenu.SetActive(false);
                BuyMenu.SetActive(false);
                reticle.text = "+";
            } 

        }
    }

    void PaintButtonClick()
    {
        PaintMenu.SetActive(true);
        BuildMenu.SetActive(false);
        BuyMenu.SetActive(false);
    }

    void BuildButtonClick()
    {
        PaintMenu.SetActive(false);
        BuildMenu.SetActive(true);
        BuyMenu.SetActive(false);
    }

    void BuyButtonClick()
    {
        PaintMenu.SetActive(false);
        BuildMenu.SetActive(false);
        BuyMenu.SetActive(true);
    }

    void RoofButtonClick()
    {
        var theData = GameObject.FindWithTag("TileData").GetComponent<TabMenu>(); 

        for (int iX = 0; iX < 50; iX++)
        {
            for (int iY = 0; iY < 50; iY++)
            {
                if (theData.TileData.gridData[iX,iY].contents != "empty")
                {
                    CeilingHighestX = iX;
                    break;
                }
            }
        }
        for (int iX = 49; iX >= 0; iX--)
        {
            for (int iY = 0; iY < 50; iY++)
            {
                if (theData.TileData.gridData[iX, iY].contents != "empty")
                {
                    CeilingLowestX = iX;
                    break;
                }
            }
        }
        for (int iY = 0; iY < 50; iY++)
        {
            for (int iX = 0; iX < 50; iX++)
            {
                if (theData.TileData.gridData[iX, iY].contents != "empty")
                {
                    CeilingHighestY = iY;
                    break;
                }
            }
        }
        for (int iY = 49; iY >= 0; iY--)
        {
            for (int iX = 0; iX < 50; iX++)
            {
                if (theData.TileData.gridData[iX, iY].contents != "empty")
                {
                    CeilingLowestY = iY;
                    break;
                }
            }
        }
 
        if (CeilingHighestX >= 0 && CeilingHighestY >= 0 && CeilingLowestX >= 0 && CeilingLowestY >= 0)
        {
            GameObject[] Ceilingtiles = GameObject.FindGameObjectsWithTag("CeilingTile");

            for (var i = 0; i < Ceilingtiles.Length; i++)
                Destroy(Ceilingtiles[i]);

            for (int iX = CeilingLowestX; iX <= CeilingHighestX; iX++)
            {
                for(int iY = CeilingLowestY; iY <= CeilingHighestY; iY++)
                {
                    Instantiate(CeilingTile, new Vector3(iX, 8.5f, iY), Quaternion.identity);
                    DidCeiling = true;
                }
            }
        }
        else
        {
            //insert error message about needing to build more to create a roof
        }
    }

}
