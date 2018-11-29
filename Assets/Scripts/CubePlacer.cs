using UnityEngine;


public class CubePlacer : MonoBehaviour {

    public float range = 10f;
    public Ray shootRay = new Ray();
    public RaycastHit GridHit;
    public GameObject TileHighlighter;
    public GameObject WallHighlighter;
    public GameObject WallPanelHighlighter;
    public GameObject HalfWallPanelHighlighter;
    public GameObject HalfWallHighlighter;
    public GameObject LintelPanelHighlighter;
    public GameObject LintelHighlighter;
    public GameObject LintelBottomHighlighter;

    public static string HighlighterTarget;
    public static int count;
    public static float NearestX;
    public static float NearestY;
    public static float NearestParentX;
    public static float NearestParentY;
    public static bool DidShootHit;
    private static int WallPanelAngle;
    public static string HighlighterSurface;


    public void Awake()
    {
        WallPanelAngle = 0;
        DidShootHit = false;
        count = 0;
        TileHighlighter.SetActive(false);
        WallPanelHighlighter.SetActive(false);
        WallHighlighter.SetActive(false);
    }


    void Update()
    {
        Shoot();
    }

    public void Shoot()
    {
         
        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        if (Physics.Raycast(shootRay, out GridHit, range))
        {
            
            DidShootHit = true;
            HighlighterTarget = GridHit.collider.ToString().Substring(0, 1);

            if (HighlighterTarget == "W")
            {
                HighlighterSurface = GridHit.collider.ToString().Substring(8, 1);
            }
            if (HighlighterTarget == "H")
            {
                HighlighterSurface = GridHit.collider.ToString().Substring(12, 1);
            }
            if (HighlighterTarget == "L")
            {
                HighlighterSurface = GridHit.collider.ToString().Substring(10, 1);
            }
            if (HighlighterTarget == "C")
            {
                HighlighterSurface = GridHit.collider.ToString().Substring(15, 1);
            }
            //(debug text below. displays on screen raycast info)
            //UIGridLocator.UIEquipText = GridHit.collider.ToString() + ":(" + NearestX + " , " + NearestY + "): [" + NearestParentX + ", " + NearestParentY + "] " + "WPA:" + WallPanelAngle + ":::" + WallPanelHighlighter.transform.rotation.x;
            //DidShootHit.ToString() + ", "+ GridHit.point[0].ToString() + "[" + PointXRounder + ":" + PointYRounder + "] " + ": (" + NearestX + " : " + NearestY + ")" + GridHit.collider;
            //[nearest point info]GridHit.point.ToString() + " = (" + NearestX + " : " + NearestY + ")";
            //[raycast return info]count + ": " + GridHit.distance.ToString() + ": " + GridHit.collider.ToString().Substring(0, 6) + ": " + GridHit.point.ToString();
            //EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();
        }
        else
        {
            
            DidShootHit = false;
            //UIGridLocator.UIEquipText = DidShootHit.ToString();

        }
        NearestGridPoint(); //finds closest x,y position on grid
        MoveTileHighlight(); //moves the glowing cursor to show what tile your cursor is on
    }
    

    public void NearestGridPoint()
    {
        if (DidShootHit == true)
        {
            //var HighlighterTarget = GridHit.collider.ToString().Substring(0, 1); //get collider hit variable

            if (HighlighterTarget == "G" || HighlighterTarget == "R")
            {
                NearestX = GridHit.collider.transform.position.x;
                NearestY = GridHit.collider.transform.position.z;
                NearestParentX = GridHit.collider.transform.position.x;
                NearestParentY = GridHit.collider.transform.position.z;

            }
            else if (HighlighterTarget == "W" || HighlighterTarget == "H" || HighlighterTarget == "L" || HighlighterTarget == "C")
            {
                NearestX = GridHit.collider.transform.position.x;
                NearestY = GridHit.collider.transform.position.z;
                NearestParentX = GridHit.collider.transform.parent.position.x;
                NearestParentY = GridHit.collider.transform.parent.position.z;
            }
        }
    }

    private void MoveTileHighlight()
    {
        var CurrentEquip = PlayerEquipmentChange.CurrentEquip; //get current player equip variable

        if (DidShootHit == true)
        {
            if (CurrentEquip == "Painter") //select only wall tiles
            {
                    if (HighlighterTarget == "W")
                    {
                    TileHighlighter.SetActive(false);
                    WallHighlighter.SetActive(false);
                    HalfWallHighlighter.SetActive(false);
                    HalfWallPanelHighlighter.SetActive(false);
                    LintelHighlighter.SetActive(false);
                    LintelPanelHighlighter.SetActive(false);
                    LintelBottomHighlighter.SetActive(false);
                    WallPanelHighlighter.SetActive(true);
                    HighlighterSurface = GridHit.collider.ToString().Substring(8, 1);

                    if (HighlighterSurface == "S")
                        {
                            WallPanelAngle = 270;
                        }

                        if (HighlighterSurface == "N")
                        {
                            WallPanelAngle = 90;
                        }

                        if (HighlighterSurface == "E")
                        {
                            WallPanelAngle = 0;
                        }
                        if (HighlighterSurface == "W")
                        {
                            WallPanelAngle = 180;
                        }

                        WallPanelHighlighter.transform.eulerAngles = new Vector3(0, WallPanelAngle, 0);
                        WallPanelHighlighter.transform.position = new Vector3(NearestX, 4, NearestY);
                    }
                    else if (HighlighterTarget == "H")
                    {

                    HighlighterSurface = GridHit.collider.ToString().Substring(12, 1);
                    HalfWallPanelHighlighter.SetActive(true);
                    TileHighlighter.SetActive(false);
                    WallHighlighter.SetActive(false);
                    HalfWallHighlighter.SetActive(false);
                    WallPanelHighlighter.SetActive(false);
                    LintelHighlighter.SetActive(false);
                    LintelPanelHighlighter.SetActive(false);
                    LintelBottomHighlighter.SetActive(false);

                    if (HighlighterSurface == "S")
                        {
                            WallPanelAngle = 270;
                        }
                        if (HighlighterSurface == "N")
                        {
                            WallPanelAngle = 90;
                        }
                        if (HighlighterSurface == "E")
                        {
                            WallPanelAngle = 0;
                        }
                        if (HighlighterSurface == "W")
                        {
                            WallPanelAngle = 180;
                        }
                        if (HighlighterSurface == "T")
                        {
                            HalfWallPanelHighlighter.SetActive(false);
                            TileHighlighter.SetActive(true);
                            TileHighlighter.transform.position = new Vector3(NearestX, 3.5005f, NearestY);
                        }

                        HalfWallPanelHighlighter.transform.eulerAngles = new Vector3(0, WallPanelAngle, 0);
                        HalfWallPanelHighlighter.transform.position = new Vector3(NearestX, 1.75f, NearestY);
                    }
                    else if (HighlighterTarget == "L")
                    {

                    HighlighterSurface = GridHit.collider.ToString().Substring(10, 1);
                    HalfWallPanelHighlighter.SetActive(false);
                    TileHighlighter.SetActive(false);
                    WallHighlighter.SetActive(false);
                    HalfWallHighlighter.SetActive(false);
                    WallPanelHighlighter.SetActive(false);
                    LintelHighlighter.SetActive(false);
                    LintelPanelHighlighter.SetActive(true);
                    LintelBottomHighlighter.SetActive(false);

                    if (HighlighterSurface == "S")
                    {
                        WallPanelAngle = 0;
                    }
                    if (HighlighterSurface == "N")
                    {
                        WallPanelAngle = 180;
                    }
                    if (HighlighterSurface == "E")
                    {
                        WallPanelAngle = 90;
                    }
                    if (HighlighterSurface == "W")
                    {
                        WallPanelAngle = 270;
                    }
                    if (HighlighterSurface == "B")
                    {
                        LintelPanelHighlighter.SetActive(false);
                        LintelBottomHighlighter.SetActive(true);
                        LintelBottomHighlighter.transform.position = new Vector3(NearestX, 5.9999f, NearestY); 
                    }

                    LintelPanelHighlighter.transform.eulerAngles = new Vector3(0, WallPanelAngle, 0);
                    LintelPanelHighlighter.transform.position = new Vector3(NearestX, 7, NearestY);
                }
                    else if(HighlighterTarget == "C")
                    {
                    HighlighterSurface = GridHit.collider.ToString().Substring(15, 1);

                        if (GridHit.collider.ToString().Substring(5, 1) == "H")
                        {
                            HalfWallPanelHighlighter.SetActive(true);
                            TileHighlighter.SetActive(false);
                            WallHighlighter.SetActive(false);
                            HalfWallHighlighter.SetActive(false);
                            WallPanelHighlighter.SetActive(false);
                            LintelHighlighter.SetActive(false);
                            LintelPanelHighlighter.SetActive(false);
                            LintelBottomHighlighter.SetActive(false);

                            if (HighlighterSurface == "S")
                            {
                                WallPanelAngle = 270;
                            }
                            if (HighlighterSurface == "N")
                            {
                                WallPanelAngle = 90;
                            }
                            if (HighlighterSurface == "E")
                            {
                                WallPanelAngle = 0;
                            }
                            if (HighlighterSurface == "W")
                            {
                                WallPanelAngle = 180;
                            }
                            if (HighlighterSurface == "T")
                            {
                                HalfWallPanelHighlighter.SetActive(false);
                                TileHighlighter.SetActive(true);
                                TileHighlighter.transform.position = new Vector3(NearestX, 3.5005f, NearestY);
                            }

                            HalfWallPanelHighlighter.transform.eulerAngles = new Vector3(0, WallPanelAngle, 0);
                            HalfWallPanelHighlighter.transform.position = new Vector3(NearestX, 1.75f, NearestY);
                        }
                        if (GridHit.collider.ToString().Substring(5, 1) == "L")
                        {
                            HalfWallPanelHighlighter.SetActive(false);
                            TileHighlighter.SetActive(false);
                            WallHighlighter.SetActive(false);
                            HalfWallHighlighter.SetActive(false);
                            WallPanelHighlighter.SetActive(false);
                            LintelHighlighter.SetActive(false);
                            LintelPanelHighlighter.SetActive(true);
                            LintelBottomHighlighter.SetActive(false);

                            if (HighlighterSurface == "S")
                            {
                                WallPanelAngle = 0;
                            }
                            if (HighlighterSurface == "N")
                            {
                                WallPanelAngle = 180;
                            }
                            if (HighlighterSurface == "E")
                            {
                                WallPanelAngle = 90;
                            }
                            if (HighlighterSurface == "W")
                            {
                                WallPanelAngle = 270;
                            }
                            if (HighlighterSurface == "B")
                            {
                                LintelPanelHighlighter.SetActive(false);
                                LintelBottomHighlighter.SetActive(true);
                                LintelBottomHighlighter.transform.position = new Vector3(NearestX, 5.9999f, NearestY);
                            }

                            LintelPanelHighlighter.transform.eulerAngles = new Vector3(0, WallPanelAngle, 0);
                            LintelPanelHighlighter.transform.position = new Vector3(NearestX, 7, NearestY);
                        }

                    }
                    else if(HighlighterTarget == "G")
                    {
                        LintelHighlighter.SetActive(false);
                        LintelPanelHighlighter.SetActive(false);
                        LintelBottomHighlighter.SetActive(false);
                        WallHighlighter.SetActive(false);
                        HalfWallHighlighter.SetActive(false);
                        HalfWallPanelHighlighter.SetActive(false);
                        WallPanelHighlighter.SetActive(false);
                        WallHighlighter.SetActive(false);
                        TileHighlighter.SetActive(true);
                        TileHighlighter.transform.position = new Vector3(NearestX, 0.001f, NearestY);
                    }
                    else if (HighlighterTarget == "R")
                    {
                        LintelHighlighter.SetActive(false);
                        LintelPanelHighlighter.SetActive(false);
                        LintelBottomHighlighter.SetActive(true);
                        WallHighlighter.SetActive(false);
                        HalfWallHighlighter.SetActive(false);
                        HalfWallPanelHighlighter.SetActive(false);
                        WallPanelHighlighter.SetActive(false);
                        WallHighlighter.SetActive(false);
                        TileHighlighter.SetActive(false);
                        LintelBottomHighlighter.transform.position = new Vector3(NearestX,7.999f, NearestY);
                    }
                else
                    {
                        TileHighlighter.SetActive(false);
                        WallHighlighter.SetActive(false);
                        HalfWallHighlighter.SetActive(false);
                        HalfWallPanelHighlighter.SetActive(false);
                        WallPanelHighlighter.SetActive(false);
                        WallHighlighter.SetActive(false);
                        LintelHighlighter.SetActive(false);
                        LintelPanelHighlighter.SetActive(false);
                        LintelBottomHighlighter.SetActive(false);
                }
            }

            if (CurrentEquip == "WallDestroyer") //select only wall tiles
            {
                if (HighlighterTarget == "W" || HighlighterTarget == "C")
                {
                    TileHighlighter.SetActive(false);
                    WallHighlighter.SetActive(false);
                    HalfWallHighlighter.SetActive(false);
                    HalfWallPanelHighlighter.SetActive(false);
                    WallPanelHighlighter.SetActive(false);
                    LintelHighlighter.SetActive(false);
                    LintelPanelHighlighter.SetActive(false);
                    LintelBottomHighlighter.SetActive(false);
                    WallHighlighter.SetActive(true);
                    WallHighlighter.transform.position = new Vector3(NearestParentX, 4, NearestParentY);
                }
                else if (HighlighterTarget == "H")
                {
                    TileHighlighter.SetActive(false);
                    WallHighlighter.SetActive(false);
                    HalfWallPanelHighlighter.SetActive(false);
                    WallPanelHighlighter.SetActive(false);
                    LintelHighlighter.SetActive(false);
                    LintelPanelHighlighter.SetActive(false);
                    LintelBottomHighlighter.SetActive(false);
                    HalfWallHighlighter.SetActive(true);
                    HalfWallHighlighter.transform.position = new Vector3(NearestParentX, 1.75f, NearestParentY);
                }
                else if (HighlighterTarget == "L")//needs special lintel highlighter block + code
                {
                    TileHighlighter.SetActive(false);
                    WallHighlighter.SetActive(false);
                    HalfWallPanelHighlighter.SetActive(false);
                    WallPanelHighlighter.SetActive(false);
                    LintelHighlighter.SetActive(true);
                    LintelPanelHighlighter.SetActive(false);
                    LintelBottomHighlighter.SetActive(false);
                    HalfWallHighlighter.SetActive(false);
                    LintelHighlighter.transform.position = new Vector3(NearestParentX, 7f, NearestParentY);
                }
                else
                {
                    TileHighlighter.SetActive(false);
                    WallHighlighter.SetActive(false);
                    HalfWallHighlighter.SetActive(false);
                    HalfWallPanelHighlighter.SetActive(false);
                    WallPanelHighlighter.SetActive(false);
                    WallHighlighter.SetActive(false);
                    LintelHighlighter.SetActive(false);
                    LintelPanelHighlighter.SetActive(false);
                    LintelBottomHighlighter.SetActive(false);
                }
            }

            if (CurrentEquip == "WallBuilder") //select only floor tiles
            {
                if (HighlighterTarget == "G")
                {
                    if (UIGridLocator.UIEquipText == "Wall" || UIGridLocator.UIEquipText == "Lintel" || UIGridLocator.UIEquipText == "Combo Wall")
                    {
                        TileHighlighter.SetActive(false);
                        HalfWallHighlighter.SetActive(false);
                        HalfWallPanelHighlighter.SetActive(false);
                        WallPanelHighlighter.SetActive(false);
                        LintelHighlighter.SetActive(false);
                        LintelPanelHighlighter.SetActive(false);
                        LintelBottomHighlighter.SetActive(false);
                        WallHighlighter.SetActive(true);
                        WallHighlighter.transform.position = new Vector3(NearestX, 4f, NearestY);
                    }
                    else if (UIGridLocator.UIEquipText == "Half Wall")
                    {
                        TileHighlighter.SetActive(false);
                        WallHighlighter.SetActive(false);
                        HalfWallPanelHighlighter.SetActive(false);
                        WallPanelHighlighter.SetActive(false);
                        WallHighlighter.SetActive(false);
                        LintelHighlighter.SetActive(false);
                        LintelPanelHighlighter.SetActive(false);
                        LintelBottomHighlighter.SetActive(false);
                        HalfWallHighlighter.SetActive(true);
                        HalfWallHighlighter.transform.position = new Vector3(NearestX, 1.75f, NearestY);
                    }
                }
                else
                {
                    TileHighlighter.SetActive(false);
                    WallHighlighter.SetActive(false);
                    HalfWallHighlighter.SetActive(false);
                    HalfWallPanelHighlighter.SetActive(false);
                    WallPanelHighlighter.SetActive(false);
                    WallHighlighter.SetActive(false);
                    LintelHighlighter.SetActive(false);
                    LintelPanelHighlighter.SetActive(false);
                    LintelBottomHighlighter.SetActive(false);
                }
            }

            if (CurrentEquip == "HeldObject") //select both floor and wall.
            {
                if (HighlighterTarget == "G")
                {
                    WallHighlighter.SetActive(false);
                    WallPanelHighlighter.SetActive(false);
                    TileHighlighter.SetActive(true);
                    TileHighlighter.transform.position = new Vector3(NearestX, 0.02f, NearestY);
                }

                if (HighlighterTarget == "W")
                {
                    WallPanelHighlighter.SetActive(true);
                    WallHighlighter.SetActive(false);
                    TileHighlighter.SetActive(false);
                    WallPanelHighlighter.transform.position = new Vector3(NearestX, 4, NearestY);
                }
            }
        }
        else
        {
            TileHighlighter.SetActive(false);
            WallHighlighter.SetActive(false);
            HalfWallHighlighter.SetActive(false);
            HalfWallPanelHighlighter.SetActive(false);
            WallPanelHighlighter.SetActive(false);
            WallHighlighter.SetActive(false);
            LintelHighlighter.SetActive(false);
            LintelPanelHighlighter.SetActive(false);
            LintelBottomHighlighter.SetActive(false);
        }
    }
}