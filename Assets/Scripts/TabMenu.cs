﻿using System.Collections;
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

    public GameObject DWall;
    public GameObject DHalfWall;
    public GameObject DComboWall;
    public GameObject DLintelWall;
    
    public Button PaintButton;
    public Button BuildButton;
    public Button BuyButton;
    public Button RoofButton;
    public Button DuplicateButton;
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
        TileData.CreateGrid();
        
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
        DuplicateButton.onClick.AddListener(DuplicateButtonClick);

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
        TabMenu theData = GameObject.FindWithTag("TileData").GetComponent<TabMenu>();
        CeilingHighestX = -1;
        CeilingLowestX = -1;
        CeilingHighestY = -1;
        CeilingLowestY = -1;



        for (int iX = 0; iX < 50; iX++)
        {
            for (int iY = 0; iY < 50; iY++)
            {
                if (theData.TileData.gridData[iX,iY].contents != "Empty")
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
                if (theData.TileData.gridData[iX, iY].contents != "Empty")
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
                if (theData.TileData.gridData[iX, iY].contents != "Empty")
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
                if (theData.TileData.gridData[iX, iY].contents != "Empty")
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

            for (int iX = CeilingLowestX - 1; iX <= CeilingHighestX + 1; iX++)
            {
                for(int iY = CeilingLowestY - 1; iY <= CeilingHighestY + 1; iY++)
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

    void DuplicateButtonClick()
    {
        TabMenu theData = GameObject.FindWithTag("TileData").GetComponent<TabMenu>();

        for (int iX = 0; iX < 50; iX++)
        {
            for (int iY = 0; iY < 50; iY++)
            {
                Instantiate(GridTile, new Vector3(iX + 51, 0, iY), Quaternion.identity);
                var SquareInfo = theData.TileData.gridData[iX, iY];

                if (SquareInfo.contents == "Wall")
                {
                    var NewObject = Instantiate(DWall, new Vector3(iX + 51, 4, iY), Quaternion.identity);
                    NewObject.transform.Find("WallSideN").GetComponent<MeshRenderer>().material.color = new Color32((byte)SquareInfo.faceN[0], (byte)SquareInfo.faceN[1], (byte)SquareInfo.faceN[2], 255);
                    NewObject.transform.Find("WallSideS").GetComponent<MeshRenderer>().material.color = new Color32((byte)SquareInfo.faceS[0], (byte)SquareInfo.faceS[1], (byte)SquareInfo.faceS[2], 255);
                    NewObject.transform.Find("WallSideE").GetComponent<MeshRenderer>().material.color = new Color32((byte)SquareInfo.faceE[0], (byte)SquareInfo.faceE[1], (byte)SquareInfo.faceE[2], 255);
                    NewObject.transform.Find("WallSideW").GetComponent<MeshRenderer>().material.color = new Color32((byte)SquareInfo.faceW[0], (byte)SquareInfo.faceW[1], (byte)SquareInfo.faceW[2], 255);
                }
                else if (SquareInfo.contents == "Combo Wall")
                {
                    var NewObject = Instantiate(DComboWall, new Vector3(iX + 51, 0, iY), Quaternion.identity);
                    NewObject.transform.Find("ComboHfWallSideN").GetComponent<MeshRenderer>().material.color = new Color32((byte)SquareInfo.faceN[0], (byte)SquareInfo.faceN[1], (byte)SquareInfo.faceN[2], 255);
                    NewObject.transform.Find("ComboHfWallSideS").GetComponent<MeshRenderer>().material.color = new Color32((byte)SquareInfo.faceS[0], (byte)SquareInfo.faceS[1], (byte)SquareInfo.faceS[2], 255);
                    NewObject.transform.Find("ComboHfWallSideE").GetComponent<MeshRenderer>().material.color = new Color32((byte)SquareInfo.faceE[0], (byte)SquareInfo.faceE[1], (byte)SquareInfo.faceE[2], 255);
                    NewObject.transform.Find("ComboHfWallSideW").GetComponent<MeshRenderer>().material.color = new Color32((byte)SquareInfo.faceW[0], (byte)SquareInfo.faceW[1], (byte)SquareInfo.faceW[2], 255);
                    NewObject.transform.Find("ComboHfWallSideT").GetComponent<MeshRenderer>().material.color = new Color32((byte)SquareInfo.faceT[0], (byte)SquareInfo.faceT[1], (byte)SquareInfo.faceT[2], 255);

                    NewObject.transform.Find("ComboLintelSideN").GetComponent<MeshRenderer>().material.color = new Color32((byte)SquareInfo.faceLN[0], (byte)SquareInfo.faceLN[1], (byte)SquareInfo.faceLN[2], 255);
                    NewObject.transform.Find("ComboLintelSideS").GetComponent<MeshRenderer>().material.color = new Color32((byte)SquareInfo.faceLS[0], (byte)SquareInfo.faceLS[1], (byte)SquareInfo.faceLS[2], 255);
                    NewObject.transform.Find("ComboLintelSideE").GetComponent<MeshRenderer>().material.color = new Color32((byte)SquareInfo.faceLE[0], (byte)SquareInfo.faceLE[1], (byte)SquareInfo.faceLE[2], 255);
                    NewObject.transform.Find("ComboLintelSideW").GetComponent<MeshRenderer>().material.color = new Color32((byte)SquareInfo.faceLW[0], (byte)SquareInfo.faceLW[1], (byte)SquareInfo.faceLW[2], 255);
                    NewObject.transform.Find("ComboLintelSideB").GetComponent<MeshRenderer>().material.color = new Color32((byte)SquareInfo.faceLB[0], (byte)SquareInfo.faceLB[1], (byte)SquareInfo.faceLB[2], 255);
                }
                else if (SquareInfo.contents == "Half Wall")
                {
                    var NewObject = Instantiate(DHalfWall, new Vector3(iX + 51, 4, iY), Quaternion.identity);
                    NewObject.transform.Find("HalfWallSideN").GetComponent<MeshRenderer>().material.color = new Color32((byte)SquareInfo.faceN[0], (byte)SquareInfo.faceN[1], (byte)SquareInfo.faceN[2], 255);
                    NewObject.transform.Find("HalfWallSideS").GetComponent<MeshRenderer>().material.color = new Color32((byte)SquareInfo.faceS[0], (byte)SquareInfo.faceS[1], (byte)SquareInfo.faceS[2], 255);
                    NewObject.transform.Find("HalfWallSideE").GetComponent<MeshRenderer>().material.color = new Color32((byte)SquareInfo.faceE[0], (byte)SquareInfo.faceE[1], (byte)SquareInfo.faceE[2], 255);
                    NewObject.transform.Find("HalfWallSideW").GetComponent<MeshRenderer>().material.color = new Color32((byte)SquareInfo.faceW[0], (byte)SquareInfo.faceW[1], (byte)SquareInfo.faceW[2], 255);
                    NewObject.transform.Find("HalfWallSideT").GetComponent<MeshRenderer>().material.color = new Color32((byte)SquareInfo.faceT[0], (byte)SquareInfo.faceT[1], (byte)SquareInfo.faceT[2], 255);
                }
                else if (SquareInfo.contents == "Lintel")
                {
                    var NewObject = Instantiate(DLintelWall, new Vector3(iX + 51, 8, iY), Quaternion.identity);
                    NewObject.transform.Find("LintelSideN").GetComponent<MeshRenderer>().material.color = new Color32((byte)SquareInfo.faceLN[0], (byte)SquareInfo.faceLN[1], (byte)SquareInfo.faceLN[2], 255);
                    NewObject.transform.Find("LintelSideS").GetComponent<MeshRenderer>().material.color = new Color32((byte)SquareInfo.faceLS[0], (byte)SquareInfo.faceLS[1], (byte)SquareInfo.faceLS[2], 255);
                    NewObject.transform.Find("LintelSideE").GetComponent<MeshRenderer>().material.color = new Color32((byte)SquareInfo.faceLE[0], (byte)SquareInfo.faceLE[1], (byte)SquareInfo.faceLE[2], 255);
                    NewObject.transform.Find("LintelSideW").GetComponent<MeshRenderer>().material.color = new Color32((byte)SquareInfo.faceLW[0], (byte)SquareInfo.faceLW[1], (byte)SquareInfo.faceLW[2], 255);
                    NewObject.transform.Find("LintelSideB").GetComponent<MeshRenderer>().material.color = new Color32((byte)SquareInfo.faceLB[0], (byte)SquareInfo.faceLB[1], (byte)SquareInfo.faceLB[2], 255);
                }

            }
        }

        if (DidCeiling == true)
        {
            for (int cX = CeilingLowestX + 49; cX <= CeilingHighestX + 51; cX++)
            {
                for (int cY = CeilingLowestY - 1; cY <= CeilingHighestY + 1; cY++)
                {
                    Instantiate(CeilingTile, new Vector3(cX, 8.5f, cY), Quaternion.identity);
                }
            }
        }

    }
}
