using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;
public class WorkerActionsGray : MonoBehaviour
{
    public Grid grid;
    public GameObject workerPlayer;
    public GameObject actionMenu;
    public GameObject otherMenu;
    public GameObject buildMenu;
    public GameObject actionButton;
    //Move Elements
    public GameObject moveButton;
    public GameObject frontButton;
    public GameObject backButton;
    public GameObject upButton;
    public GameObject downButton;
    private Vector3Int position;
    //Recolect Elemets
    public GameObject recolectButton;
    //Build Barracks
    public GameObject barracksPrefab;
    public GameObject buildFront;
    public GameObject buildBack;
    public GameObject buildUp;
    public GameObject buildDown;
    public GameObject noResurces;
    public GameObject noMove;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            if (hit.collider != null)
            {
                workerPlayer = hit.collider.gameObject;
                Healt move = workerPlayer.GetComponent<Healt>();
                if (workerPlayer.CompareTag("WorkerGray"))
                {
                    if (move.move > 0)
                    {
                        position = grid.WorldToCell(workerPlayer.transform.position);
                        actionMenu.SetActive(true);
                        noMove.SetActive(false);
                        restartMenu();
                    } else
                    {
                        noMove.SetActive(true);
                        restartMenu();
                    }
                }
            } else
            {
                actionMenu.SetActive(false);
                noMove.SetActive(false);
                restartMenu();
            }
        }
    }
    public int getCurrentResurces()
    {
        GameObject baseGray = GameObject.FindGameObjectWithTag("BaseGray");
        BaseElements baseResurces = baseGray.GetComponent<BaseElements>();
        int CurrentResurces = baseResurces.resurces;
        return CurrentResurces;
    }
    public void finishMove()
    {
        Healt move = workerPlayer.GetComponent<Healt>();
        move.move = move.move - 1;
    }
    public void restartMenu()
    {
        actionButton.SetActive(true);
        moveButton.SetActive(true);
        otherMenu.SetActive(false);
        buildMenu.SetActive(false);
        frontButton.SetActive(false);
        backButton.SetActive(false);
        upButton.SetActive(false);
        downButton.SetActive(false);
        recolectButton.SetActive(false);
        buildFront.SetActive(false);
        buildBack.SetActive(false);
        buildUp.SetActive(false);
        buildDown.SetActive(false);
    }
    public void MoveButton()
    {
        position.x = position.x + 1;
        Vector3 frontMove = grid.GetCellCenterWorld(position);
        Collider2D objectOnTile = Physics2D.OverlapPoint(frontMove);
        if (objectOnTile == null && position.x < -4)
        {
            actionButton.SetActive(false);
            moveButton.SetActive(false);
            frontButton.SetActive(true);
        }
        position.x = position.x - 2;
        Vector3 backMove = grid.GetCellCenterWorld(position);
        objectOnTile = Physics2D.OverlapPoint(backMove);
        if (objectOnTile == null && position.x > -15)
        {
            actionButton.SetActive(false);
            moveButton.SetActive(false);
            backButton.SetActive(true);
        }
        position.x = position.x + 1;
        position.y = position.y + 1;
        Vector3 upMove = grid.GetCellCenterWorld(position);
        objectOnTile = Physics2D.OverlapPoint(upMove);
        if (objectOnTile == null && position.y < 11)
        {
            actionButton.SetActive(false);
            moveButton.SetActive(false);
            upButton.SetActive(true);
        }
        position.y = position.y - 2;
        Vector3 downMove = grid.GetCellCenterWorld(position);
        objectOnTile = Physics2D.OverlapPoint(downMove);
        if (objectOnTile == null && position.y > 0)
        {
            actionButton.SetActive(false);
            moveButton.SetActive(false);
            downButton.SetActive(true);
        }
        position.y = position.y + 1;
    }
    public void frontMove()
    {
        position.x = position.x + 1;
        Vector3 frontMove = grid.GetCellCenterWorld(position);
        workerPlayer.transform.position = frontMove;
        restartMoveMenu();
    }
    public void backMove()
    {
        position.x = position.x - 1;
        Vector3 backMove = grid.GetCellCenterWorld(position);
        workerPlayer.transform.position = backMove;
        restartMoveMenu();
    }
    public void upMove()
    {
        position.y = position.y + 1;
        Vector3 upMove = grid.GetCellCenterWorld(position);
        workerPlayer.transform.position = upMove;
        restartMoveMenu();
    }
    public void downMove()
    {
        position.y = position.y - 1;
        Vector3 downMove = grid.GetCellCenterWorld(position);
        workerPlayer.transform.position = downMove;
        restartMoveMenu();
    }
    public void restartMoveMenu()
    {
        actionMenu.SetActive(false);
        frontButton.SetActive(false);
        backButton.SetActive(false);
        upButton.SetActive(false);
        downButton.SetActive(false);
        actionButton.SetActive(true);
        moveButton.SetActive(true);
        finishMove();
    }
    public void ActionButton()
    {
        noResurces.SetActive(false);
        int CurrentResurces = getCurrentResurces();
        position.x = position.x + 1;
        Vector3 frontMove = grid.GetCellCenterWorld(position);
        Collider2D objectOnTile = Physics2D.OverlapPoint(frontMove);
        if (objectOnTile == null && CurrentResurces > 3 && position.x < -4)
        {
            actionButton.SetActive(false);
            moveButton.SetActive(false);
            buildFront.SetActive(true);
        } else if (objectOnTile != null && objectOnTile.CompareTag("Resurces"))
        {
            actionButton.SetActive(false);
            moveButton.SetActive(false);
            recolectButton.SetActive(true);
        }
        position.x = position.x - 2;
        Vector3 backMove = grid.GetCellCenterWorld(position);
        objectOnTile = Physics2D.OverlapPoint(backMove);
        if (objectOnTile == null && CurrentResurces > 3 && position.x > -15)
        {
            actionButton.SetActive(false);
            moveButton.SetActive(false);
            buildBack.SetActive(true);
        } else if (objectOnTile != null && objectOnTile.CompareTag("Resurces"))
        {
            actionButton.SetActive(false);
            moveButton.SetActive(false);
            recolectButton.SetActive(true);
        }
        position.x = position.x + 1;
        position.y = position.y + 1;
        Vector3 upMove = grid.GetCellCenterWorld(position);
        objectOnTile = Physics2D.OverlapPoint(upMove);
        if (objectOnTile == null && CurrentResurces > 3 && position.y < 11)
        {
            actionButton.SetActive(false);
            moveButton.SetActive(false);
            buildUp.SetActive(true);
        } else if (objectOnTile != null && objectOnTile.CompareTag("Resurces"))
        {
            actionButton.SetActive(false);
            moveButton.SetActive(false);
            recolectButton.SetActive(true);
        }
        position.y = position.y - 2;
        Vector3 downMove = grid.GetCellCenterWorld(position);
        objectOnTile = Physics2D.OverlapPoint(downMove);
        if (objectOnTile == null && CurrentResurces > 3 && position.y > 0)
        {
            actionButton.SetActive(false);
            moveButton.SetActive(false);
            buildDown.SetActive(true);
        } else if (objectOnTile != null && objectOnTile.CompareTag("Resurces"))
        {
            actionButton.SetActive(false);
            moveButton.SetActive(false);
            recolectButton.SetActive(true);
        }
        position.y = position.y + 1;
        if (CurrentResurces <= 3)
        {
            noResurces.SetActive(true);
        }
    }
    public void recolect()
    {
        GameObject baseGray = GameObject.FindGameObjectWithTag("BaseGray");
        BaseElements baseResurces = baseGray.GetComponent<BaseElements>();
        baseResurces.resurces = baseResurces.resurces + 2;
        restartActionMenu();
    }
    public void frontBuild()
    {
        position.x = position.x + 1;
        Vector3 precisePosition = grid.GetCellCenterWorld(position);
        Instantiate(barracksPrefab, precisePosition, Quaternion.identity);
        expend();
        restartActionMenu();
    }
    public void backBuild()
    {
        position.x = position.x - 1;
        Vector3 precisePosition = grid.GetCellCenterWorld(position);
        Instantiate(barracksPrefab, precisePosition, Quaternion.identity);
        expend();
        restartActionMenu();
    }
    public void upBuild()
    {
        position.y = position.y + 1;
        Vector3 precisePosition = grid.GetCellCenterWorld(position);
        Instantiate(barracksPrefab, precisePosition, Quaternion.identity);
        expend();
        restartActionMenu();
    }
    public void downBuild()
    {
        position.y = position.y - 1;
        Vector3 precisePosition = grid.GetCellCenterWorld(position);
        Instantiate(barracksPrefab, precisePosition, Quaternion.identity);
        expend();
        restartActionMenu();
    }
    public void expend()
    {
        GameObject baseGray = GameObject.FindGameObjectWithTag("BaseGray");
        BaseElements baseResurces = baseGray.GetComponent<BaseElements>();
        baseResurces.resurces = baseResurces.resurces - 4;
    }
    public void restartActionMenu()
    {
        actionMenu.SetActive(false);
        recolectButton.SetActive(false);
        buildFront.SetActive(false);
        buildBack.SetActive(false);
        buildUp.SetActive(false);
        buildDown.SetActive(false);
        actionButton.SetActive(true);
        moveButton.SetActive(true);
        finishMove();
    }
}
