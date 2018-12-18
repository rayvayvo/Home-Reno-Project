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

    public GameObject debugWallLN;
    public GameObject debugWallLS;
    public GameObject debugWallLE;
    public GameObject debugWallLW;
    public GameObject debugWallLB;

    Text debugcoordstext;
    Text debugcontentstext;
    Text debugattachedtext;
    Text debugattachedxyztext;

    Image debugWallNimage;
    Image debugWallSimage;
    Image debugWallEimage;
    Image debugWallWimage;
    Image debugWallTimage;

    Image debugWallLNimage;
    Image debugWallLSimage;
    Image debugWallLEimage;
    Image debugWallLWimage;
    Image debugWallLBimage;

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

        debugWallLNimage = debugWallLN.GetComponent<Image>();
        debugWallLSimage = debugWallLS.GetComponent<Image>();
        debugWallLEimage = debugWallLE.GetComponent<Image>();
        debugWallLWimage = debugWallLW.GetComponent<Image>();
        debugWallLBimage = debugWallLB.GetComponent<Image>();
    }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

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

            debugWallLNimage.color = new Color32(
                (byte)squareInfo.faceLN[0], (byte)squareInfo.faceLN[1], (byte)squareInfo.faceLN[2], 255);

            debugWallLSimage.color = new Color32(
                (byte)squareInfo.faceLS[0], (byte)squareInfo.faceLS[1], (byte)squareInfo.faceLS[2], 255);

            debugWallLEimage.color = new Color32(
                (byte)squareInfo.faceLE[0], (byte)squareInfo.faceLE[1], (byte)squareInfo.faceLE[2], 255);

            debugWallLWimage.color = new Color32(
                (byte)squareInfo.faceLW[0], (byte)squareInfo.faceLW[1], (byte)squareInfo.faceLW[2], 255);

            debugWallLBimage.color = new Color32(
                (byte)squareInfo.faceLB[0], (byte)squareInfo.faceLB[1], (byte)squareInfo.faceLB[2], 255);

        }
        else
        {
            debugWallNimage.color = Color.black;
            debugWallSimage.color = Color.black;
            debugWallEimage.color = Color.black;
            debugWallWimage.color = Color.black;
            debugWallTimage.color = Color.black;
            debugWallLNimage.color = Color.black;
            debugWallLSimage.color = Color.black;
            debugWallLEimage.color = Color.black;
            debugWallLWimage.color = Color.black;
            debugWallLBimage.color = Color.black;
        }
    }
}
