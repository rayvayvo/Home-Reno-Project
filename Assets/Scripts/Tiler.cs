using System.Collections;
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

}
