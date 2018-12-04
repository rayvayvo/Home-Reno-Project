using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabMenu : MonoBehaviour {

    public GameObject TabMenuDisplay;
    public GameObject FPSController;
    public GameObject PaintMenu;
    public GameObject BuildMenu;
    public GameObject BuyMenu;
    public Button PaintButton;
    public Button BuildButton;
    public Button BuyButton;
    public Button RoofButton;
    public Text reticle;
    public GameObject CeilingTile;
    public GameObject tilerscript;
    public static int CeilingLowestX;
    public static int CeilingLowestY;
    public static int CeilingHighestX;
    public static int CeilingHighestY;
    public static bool DidCeiling;


    // Use this for initialization
    void Start () {
        PaintButton.onClick.AddListener(PaintButtonClick);
        BuildButton.onClick.AddListener(BuildButtonClick);
        BuyButton.onClick.AddListener(BuyButtonClick);
        RoofButton.onClick.AddListener(RoofButtonClick);
        var GD = tilerscript.GetComponent<Tiler>();
   
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
        for (int iX = 0; iX < 50; iX++)
        {
            for (int iY = 0; iY < 50; iY++)
            {
                if (Tiler.GridData[iX,iY] == 1)
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
                if (Tiler.GridData[iX, iY] == 1)
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
                if (Tiler.GridData[iX, iY] == 1)
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
                if (Tiler.GridData[iX, iY] == 1)
                {
                    CeilingLowestY = iY;
                    break;
                }
            }
        }
        DidCeiling = true;

        if (CeilingHighestX >= 0 && CeilingHighestY >= 0 && CeilingLowestX >= 0 && CeilingLowestY >= 0)
        {
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
