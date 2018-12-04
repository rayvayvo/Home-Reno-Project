/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiler : MonoBehaviour {

    public GameObject GridTile;
    public GameObject CanvasDb;
    public static int[,] GridData;

    public void Start()
    {
        GridData = new int[50, 50];

        for (int iX = 0; iX < 50; iX++)
        {
            for (int iY = 0; iY < 50; iY++)
            {
                GridData[iX, iY] = 0;
                Instantiate(GridTile, new Vector3(iX, 0, iY), Quaternion.identity);                
            }
        }
    }

}*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiler : MonoBehaviour
{

    public string contents;
    public int[] faceS = new int[3];
    public int[] faceE;
    public int[] faceN;
    public int[] faceW;
    public int[] faceT;
    public int[] faceB;
    public string attachedObject;
    public int[] objectTransform;

    public GameObject GridTile;
    public GameObject CanvasDb;
    public Tiler[,] gridData;

    public void Start()
    {
        gridData = new Tiler[50, 50];

        for (int iX = 0; iX < 50; iX++)
        {
            for (int iY = 0; iY < 50; iY++)
            {
                gridData[iX, iY] = new Tiler();
                gridData[iX, iY].contents = "Empty";
                gridData[iX, iY].attachedObject = "Empty";

                for (int iZ = 0; iZ <= 3; iZ++)
                {
                    gridData[iX, iY].faceS[iZ] = 0;
                    gridData[iX, iY].faceE[iZ] = 0;
                    gridData[iX, iY].faceW[iZ] = 0;
                    gridData[iX, iY].faceN[iZ] = 0;
                    gridData[iX, iY].faceT[iZ] = 0;
                    gridData[iX, iY].faceB[iZ] = 0;
                    gridData[iX, iY].objectTransform[iZ] = 0;
                }


                Instantiate(GridTile, new Vector3(iX, 0, iY), Quaternion.identity);
            }
        }
    }

}
