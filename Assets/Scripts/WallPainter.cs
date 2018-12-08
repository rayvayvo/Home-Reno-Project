using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TileData;


public class WallPainter : MonoBehaviour {


    public GameObject FirstPersonCharacter;
    public GameObject TabMenuDisplay;
    private float ClickDelay = 0;

    void Start()
    {
    }

    
    void Update()
    {
        ClickDelay += Time.deltaTime;

        if (Input.GetButton("Fire1") && ClickDelay > 0.1 && TabMenuDisplay.activeSelf == false)
        {
            var ShootScript = FirstPersonCharacter.GetComponent<CubePlacer>(); // set ShootScript to equal the CubePlacer script
         
            if (CubePlacer.DidShootHit == true) //check to see if raycast hits
            {
                TabMenu theData = GameObject.FindWithTag("TileData").GetComponent<TabMenu>();

                if (ShootScript.GridHit.collider.ToString().Substring(0, 8) == "WallSide" || ShootScript.GridHit.collider.ToString().Substring(0, 8) == "HalfWall" || ShootScript.GridHit.collider.ToString().Substring(0, 6) == "Lintel" || ShootScript.GridHit.collider.ToString().Substring(0, 5) == "Combo" || ShootScript.GridHit.collider.ToString().Substring(0, 4) == "Grid" || ShootScript.GridHit.collider.ToString().Substring(0, 4) == "Room") 
                {
                    if (CubePlacer.HighlighterSurface == "N")
                    {
                        theData.TileData.gridData[(int)CubePlacer.NearestParentX, (int)CubePlacer.NearestParentY].faceN[0] = PaintMenu.LastRed;
                        theData.TileData.gridData[(int)CubePlacer.NearestParentX, (int)CubePlacer.NearestParentY].faceN[1] = PaintMenu.LastGreen;
                        theData.TileData.gridData[(int)CubePlacer.NearestParentX, (int)CubePlacer.NearestParentY].faceN[2] = PaintMenu.LastBlue;
                    }
                    if (CubePlacer.HighlighterSurface == "S")
                    {
                        theData.TileData.gridData[(int)CubePlacer.NearestParentX, (int)CubePlacer.NearestParentY].faceS[0] = PaintMenu.LastRed;
                        theData.TileData.gridData[(int)CubePlacer.NearestParentX, (int)CubePlacer.NearestParentY].faceS[1] = PaintMenu.LastGreen;
                        theData.TileData.gridData[(int)CubePlacer.NearestParentX, (int)CubePlacer.NearestParentY].faceS[2] = PaintMenu.LastBlue;
                    }
                    if (CubePlacer.HighlighterSurface == "E")
                    {
                        theData.TileData.gridData[(int)CubePlacer.NearestParentX, (int)CubePlacer.NearestParentY].faceE[0] = PaintMenu.LastRed;
                        theData.TileData.gridData[(int)CubePlacer.NearestParentX, (int)CubePlacer.NearestParentY].faceE[1] = PaintMenu.LastGreen;
                        theData.TileData.gridData[(int)CubePlacer.NearestParentX, (int)CubePlacer.NearestParentY].faceE[2] = PaintMenu.LastBlue;
                    }
                    if (CubePlacer.HighlighterSurface == "W")
                    {
                        theData.TileData.gridData[(int)CubePlacer.NearestParentX, (int)CubePlacer.NearestParentY].faceW[0] = PaintMenu.LastRed;
                        theData.TileData.gridData[(int)CubePlacer.NearestParentX, (int)CubePlacer.NearestParentY].faceW[1] = PaintMenu.LastGreen;
                        theData.TileData.gridData[(int)CubePlacer.NearestParentX, (int)CubePlacer.NearestParentY].faceW[2] = PaintMenu.LastBlue;
                    }
                    if (CubePlacer.HighlighterSurface == "T")
                    {
                        theData.TileData.gridData[(int)CubePlacer.NearestParentX, (int)CubePlacer.NearestParentY].faceT[0] = PaintMenu.LastRed;
                        theData.TileData.gridData[(int)CubePlacer.NearestParentX, (int)CubePlacer.NearestParentY].faceT[1] = PaintMenu.LastGreen;
                        theData.TileData.gridData[(int)CubePlacer.NearestParentX, (int)CubePlacer.NearestParentY].faceT[2] = PaintMenu.LastBlue;
                    }
                    if (CubePlacer.HighlighterSurface == "B")
                    {
                        theData.TileData.gridData[(int)CubePlacer.NearestParentX, (int)CubePlacer.NearestParentY].faceB[0] = PaintMenu.LastRed;
                        theData.TileData.gridData[(int)CubePlacer.NearestParentX, (int)CubePlacer.NearestParentY].faceB[1] = PaintMenu.LastGreen;
                        theData.TileData.gridData[(int)CubePlacer.NearestParentX, (int)CubePlacer.NearestParentY].faceB[2] = PaintMenu.LastBlue;
                    }

                    ShootScript.GridHit.transform.gameObject.GetComponent<MeshRenderer>().material.color = new Color32(PaintMenu.LastRed,PaintMenu.LastGreen,PaintMenu.LastBlue, 255);
                }
            }
            ClickDelay = 0;
        }
    }
}
