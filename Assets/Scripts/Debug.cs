using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TileData;


public class Debug : MonoBehaviour {

    public GameObject debugcoords;
    public GameObject debugcontents;
    public GameObject debugattached;
    public GameObject debugattachedxyz;
    public GameObject debugWallN;
    public GameObject debugWallS;
    public GameObject debugWallE;
    public GameObject debugWallW;
    public GameObject debugWallT;
    public GameObject debugWallB;

    Text debugcoordstext;
    Text debugcontentstext;
    Text debugattachedtext;
    Text debugattachedxyztext;

    Image debugWallNimage;
    Image debugWallSimage;
    Image debugWallEimage;
    Image debugWallWimage;
    Image debugWallTimage;
    Image debugWallBimage;

    void Awake()
    {
        debugcoordstext = debugcoords.GetComponent<Text>();
        debugcontentstext = debugcontents.GetComponent<Text>();
        debugattachedtext = debugattached.GetComponent<Text>();
        debugattachedxyztext = debugattachedxyz.GetComponent<Text>();

        debugWallNimage = debugWallN.GetComponent<Image>();
        debugWallSimage = debugWallS.GetComponent<Image>();
        debugWallEimage = debugWallE.GetComponent<Image>();
        debugWallWimage = debugWallW.GetComponent<Image>();
        debugWallTimage = debugWallT.GetComponent<Image>();
        debugWallBimage = debugWallB.GetComponent<Image>();
    }

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update() {

        if (CubePlacer.DidShootHit == true)
        {
            TabMenu theData = GameObject.FindWithTag("TileData").GetComponent<TabMenu>();
            var squareInfo = theData.TileData.gridData[(int)CubePlacer.NearestParentX, (int)CubePlacer.NearestParentY];

            debugcoordstext.text = "Co-ords: [" + CubePlacer.NearestParentX + ":" + CubePlacer.NearestParentY + "]";
            debugcontentstext.text = "Contents: " + squareInfo.contents;
            debugattachedtext.text = "Attached: " + squareInfo.attachedObject + "(" + (byte)squareInfo.faceN[0] + "," + (byte)squareInfo.faceN[1] + "," + (byte)squareInfo.faceN[2] + ")";
            debugattachedxyztext.text = "AttachedXY: " + squareInfo.objectTransform;

            debugWallNimage.color = new Color32(
                (byte)squareInfo.faceN[0], (byte)squareInfo.faceN[1], (byte)squareInfo.faceN[2], 255); 

            debugWallSimage.color = new Color32(
                (byte)squareInfo.faceS[0], (byte)squareInfo.faceS[1], (byte)squareInfo.faceS[2], 255);

            debugWallEimage.color = new Color32(
                (byte)squareInfo.faceE[0], (byte)squareInfo.faceE[1], (byte)squareInfo.faceE[2], 255);

            debugWallWimage.color = new Color32(
                (byte)squareInfo.faceW[0], (byte)squareInfo.faceW[1], (byte)squareInfo.faceW[2], 255);

            debugWallTimage.color = new Color32(
                (byte)squareInfo.faceT[0], (byte)squareInfo.faceT[1], (byte)squareInfo.faceT[2], 255);

            debugWallBimage.color = new Color32(
                (byte)squareInfo.faceB[0], (byte)squareInfo.faceB[1], (byte)squareInfo.faceB[2], 255);

        }


    }
}
