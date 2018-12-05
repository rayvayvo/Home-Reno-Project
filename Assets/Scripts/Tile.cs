using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TileData
{ 
    public struct Tile
    {
        public string contents;
        public int[] faceS;
        public int[] faceE;
        public int[] faceN;
        public int[] faceW;
        public int[] faceT;
        public int[] faceB;
        public string attachedObject;
        public int[] objectTransform;
        public GameObject GridTile;
        public GameObject CanvasDb;
    };

    public class Tiler
    {
        public Tile[,] gridData;

        public void CreateGrid()
        {
           gridData = new Tile[50, 50];

            for (int iX = 0; iX < 50; iX++)
            {
                for (int iY = 0; iY < 50; iY++)
                {
                    gridData[iX, iY].faceS = new int[3];
                    gridData[iX, iY].faceN = new int[3];
                    gridData[iX, iY].faceE = new int[3];
                    gridData[iX, iY].faceW = new int[3];
                    gridData[iX, iY].faceT = new int[3];
                    gridData[iX, iY].faceB = new int[3];
                    gridData[iX, iY].objectTransform = new int[3];
                    gridData[iX, iY].contents = "Empty";
                    gridData[iX, iY].attachedObject = "Empty";

                    for (int iZ = 0; iZ < 3; iZ++)
                    {
                        gridData[iX, iY].faceS[iZ] = 0;
                        gridData[iX, iY].faceN[iZ] = 0;
                        gridData[iX, iY].faceE[iZ] = 0;
                        gridData[iX, iY].faceW[iZ] = 0;
                        gridData[iX, iY].faceT[iZ] = 0;
                        gridData[iX, iY].faceB[iZ] = 0;
                        gridData[iX, iY].objectTransform[iZ] = 0;
                    }
                }

            }
        }
    }
}

