using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TileData
{
    [System.Serializable]
    public struct Tile
    {
        public string contents;
        public int[] faceS;
        public int[] faceE;
        public int[] faceN;
        public int[] faceW;
        public int[] faceT;

        public int[] faceLS;
        public int[] faceLE;
        public int[] faceLN;
        public int[] faceLW;
        public int[] faceLB;
        public string attachedObject;
        public int[] objectTransform;
    };

    [System.Serializable]
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

                    gridData[iX, iY].faceLS = new int[3];
                    gridData[iX, iY].faceLN = new int[3];
                    gridData[iX, iY].faceLE = new int[3];
                    gridData[iX, iY].faceLW = new int[3];
                    gridData[iX, iY].faceLB = new int[3];
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

                        gridData[iX, iY].faceLS[iZ] = 0;
                        gridData[iX, iY].faceLN[iZ] = 0;
                        gridData[iX, iY].faceLE[iZ] = 0;
                        gridData[iX, iY].faceLW[iZ] = 0;
                        gridData[iX, iY].faceLB[iZ] = 0;
                        gridData[iX, iY].objectTransform[iZ] = 0;
                    }
                }

            }
        }
    }
}

