using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;
public class BuildingsActionsRed : MonoBehaviour
{
    public Grid grid;
    public GameObject buildingPlayer;
    public GameObject actionMenu;
    public GameObject baseMenu;
    public GameObject barracksMenu;
    public GameObject otherMenu;
    public GameObject otherMenu2;
    //Create Soldiers
    public GameObject soldiersPrefab;
    public GameObject soldiersFront;
    public GameObject soldiersBack;
    public GameObject soldiersUp;
    public GameObject soldiersDown;
    //Create Workers
    public GameObject workersPrefab;
    public GameObject workersFront;
    public GameObject workersBack;
    public GameObject workersUp;
    public GameObject workersDown;
    public GameObject noResurces;
    private Vector3Int position;
    public GameObject noMove;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            noResurces.SetActive(false);
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            if (hit.collider != null)
            {
                buildingPlayer = hit.collider.gameObject;
                if (buildingPlayer.CompareTag("BaseRed"))
                {
                    BaseElements move = buildingPlayer.GetComponent<BaseElements>();
                    if (move.move > 0) 
                    {
                        position = grid.WorldToCell(buildingPlayer.transform.position);
                        restartMenus();
                        baseMenu.SetActive(true);
                        barracksMenu.SetActive(false);
                        noMove.SetActive(false);
                    } else
                    {
                        noMove.SetActive(true);
                        restartMenus();
                    }
                } else if (buildingPlayer.CompareTag("BarracksRed"))
                {
                    Healt move = buildingPlayer.GetComponent<Healt>();
                    if (move.move > 0) 
                    {
                        position = grid.WorldToCell(buildingPlayer.transform.position);
                        restartMenus();
                        barracksMenu.SetActive(true);
                        baseMenu.SetActive(false);
                        noMove.SetActive(false);
                    } else
                    {
                        noMove.SetActive(true);
                        restartMenus();
                    }
                }
            } else
            {
                baseMenu.SetActive(false);
                barracksMenu.SetActive(false);
                noMove.SetActive(false);
                restartMenus();
            }
        }
    }
    public void finishMove()
    {
        if (buildingPlayer.CompareTag("BaseRed"))
        {
            BaseElements move = buildingPlayer.GetComponent<BaseElements>();
            move.move = move.move - 1;
        } else if (buildingPlayer.CompareTag("BarracksRed"))
        {
            Healt move = buildingPlayer.GetComponent<Healt>();
            move.move = move.move - 1;
        }
    }
    public int getCurrentResurces()
    {
        GameObject baseRed = GameObject.FindGameObjectWithTag("BaseRed");
        BaseElements baseResurces = baseRed.GetComponent<BaseElements>();
        int CurrentResurces = baseResurces.resurces;
        return CurrentResurces;
    }
    public void restartMenus()
    {
        actionMenu.SetActive(true);
        otherMenu.SetActive(false);
        otherMenu2.SetActive(false);
        workersFront.SetActive(false);
        workersBack.SetActive(false);
        workersUp.SetActive(false);
        workersDown.SetActive(false);
        soldiersFront.SetActive(false);
        soldiersBack.SetActive(false);
        soldiersUp.SetActive(false);
        soldiersDown.SetActive(false);
    }
    public void baseButton()
    {
        int CurrentResurces = getCurrentResurces();
        if (CurrentResurces > 0) 
        {
            position.x = position.x - 1;
            Vector3 frontMove = grid.GetCellCenterWorld(position);
            Collider2D objectOnTile = Physics2D.OverlapPoint(frontMove);
            if (objectOnTile == null && position.x > -15)
            {
                baseMenu.SetActive(false);
                workersFront.SetActive(true);
            } 
            position.x = position.x + 2;
            Vector3 backMove = grid.GetCellCenterWorld(position);
            objectOnTile = Physics2D.OverlapPoint(backMove);
            if (objectOnTile == null && position.x < -4)
            {
                baseMenu.SetActive(false);
                workersBack.SetActive(true);
            } 
            position.x = position.x - 1;
            position.y = position.y + 1;
            Vector3 upMove = grid.GetCellCenterWorld(position);
            objectOnTile = Physics2D.OverlapPoint(upMove);
            if (objectOnTile == null && position.y < 11)
            {
                baseMenu.SetActive(false);
                workersUp.SetActive(true);
            } 
            position.y = position.y - 2;
            Vector3 downMove = grid.GetCellCenterWorld(position);
            objectOnTile = Physics2D.OverlapPoint(downMove);
            if (objectOnTile == null && position.y > 0)
            {
                baseMenu.SetActive(false);
                workersDown.SetActive(true);
            } 
            position.y = position.y + 1;
        } else
        {
            baseMenu.SetActive(false);
            noResurces.SetActive(true);
        }
    }
    public void frontWorker()
    {
        position.x = position.x - 1;
        Vector3 precisePosition = grid.GetCellCenterWorld(position);
        Instantiate(workersPrefab, precisePosition, Quaternion.identity);
        expendWorker();
        restartBaseMenu();
    }
    public void backWorker()
    {
        position.x = position.x + 1;
        Vector3 precisePosition = grid.GetCellCenterWorld(position);
        Instantiate(workersPrefab, precisePosition, Quaternion.identity);
        expendWorker();
        restartBaseMenu();
    }
    public void upWorker()
    {
        position.y = position.y + 1;
        Vector3 precisePosition = grid.GetCellCenterWorld(position);
        Instantiate(workersPrefab, precisePosition, Quaternion.identity);
        expendWorker();
        restartBaseMenu();
    }
    public void downWorker()
    {
        position.y = position.y - 1;
        Vector3 precisePosition = grid.GetCellCenterWorld(position);
        Instantiate(workersPrefab, precisePosition, Quaternion.identity);
        expendWorker();
        restartBaseMenu();
    }
    public void expendWorker()
    {
        GameObject baseRed = GameObject.FindGameObjectWithTag("BaseRed");
        BaseElements baseResurces = baseRed.GetComponent<BaseElements>();
        baseResurces.resurces = baseResurces.resurces - 1;
    }
    public void restartBaseMenu()
    {
        actionMenu.SetActive(false);
        baseMenu.SetActive(false);
        workersFront.SetActive(false);
        workersBack.SetActive(false);
        workersUp.SetActive(false);
        workersDown.SetActive(false);
        finishMove();
    }
    public void barracksButton()
    {
        int CurrentResurces = getCurrentResurces();
        if (CurrentResurces > 1) 
        {
            position.x = position.x - 1;
            Vector3 frontMove = grid.GetCellCenterWorld(position);
            Collider2D objectOnTile = Physics2D.OverlapPoint(frontMove);
            if (objectOnTile == null && position.x > -15)
            {
                barracksMenu.SetActive(false);
                soldiersFront.SetActive(true);
            } 
            position.x = position.x + 2;
            Vector3 backMove = grid.GetCellCenterWorld(position);
            objectOnTile = Physics2D.OverlapPoint(backMove);
            if (objectOnTile == null && position.x < -4)
            {
                barracksMenu.SetActive(false);
                soldiersBack.SetActive(true);
            } 
            position.x = position.x - 1;
            position.y = position.y + 1;
            Vector3 upMove = grid.GetCellCenterWorld(position);
            objectOnTile = Physics2D.OverlapPoint(upMove);
            if (objectOnTile == null && position.y < 11)
            {
                barracksMenu.SetActive(false);
                soldiersUp.SetActive(true);
            } 
            position.y = position.y - 2;
            Vector3 downMove = grid.GetCellCenterWorld(position);
            objectOnTile = Physics2D.OverlapPoint(downMove);
            if (objectOnTile == null && position.y > 0)
            {
                barracksMenu.SetActive(false);
                soldiersDown.SetActive(true);
            } 
            position.y = position.y + 1;
        } else
        {
            barracksMenu.SetActive(false);
            noResurces.SetActive(true);
        }
    }
    public void frontSoldier()
    {
        position.x = position.x - 1;
        Vector3 precisePosition = grid.GetCellCenterWorld(position);
        Instantiate(soldiersPrefab, precisePosition, Quaternion.identity);
        expendSoldier();
        restartBarracksMenu();
    }
    public void backSoldier()
    {
        position.x = position.x + 1;
        Vector3 precisePosition = grid.GetCellCenterWorld(position);
        Instantiate(soldiersPrefab, precisePosition, Quaternion.identity);
        expendSoldier();
        restartBarracksMenu();
    }
    public void upSoldier()
    {
        position.y = position.y + 1;
        Vector3 precisePosition = grid.GetCellCenterWorld(position);
        Instantiate(soldiersPrefab, precisePosition, Quaternion.identity);
        expendSoldier();
        restartBarracksMenu();
    }
    public void downSoldier()
    {
        position.y = position.y - 1;
        Vector3 precisePosition = grid.GetCellCenterWorld(position);
        Instantiate(soldiersPrefab, precisePosition, Quaternion.identity);
        expendSoldier();
        restartBarracksMenu();
    }
    public void expendSoldier()
    {
        GameObject baseRed = GameObject.FindGameObjectWithTag("BaseRed");
        BaseElements baseResurces = baseRed.GetComponent<BaseElements>();
        baseResurces.resurces = baseResurces.resurces - 2;
    }
    public void restartBarracksMenu()
    {
        actionMenu.SetActive(false);
        barracksMenu.SetActive(false);
        soldiersFront.SetActive(false);
        soldiersBack.SetActive(false);
        soldiersUp.SetActive(false);
        soldiersDown.SetActive(false);
        finishMove();
    }
}
