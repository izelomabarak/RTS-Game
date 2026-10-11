using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;
public class SoldierActionsGray : MonoBehaviour
{
    public Grid grid;
    // Main menu variables
    public GameObject soldierPlayer;
    public GameObject actionMenu;
    public GameObject otherMenu;
    public GameObject buildMenu;
    // Move menu variables
    public GameObject moveButton;
    public GameObject frontButton;
    public GameObject backButton;
    public GameObject upButton;
    public GameObject downButton;
    // Attack menu variables
    public GameObject attackButton;
    public GameObject frontAttack;
    public GameObject backAttack;
    public GameObject upAttack;
    public GameObject downAttack;
    private Collider2D enemyFront;
    private Collider2D enemyBack;
    private Collider2D enemyUp;
    private Collider2D enemyDown;
    private Vector3Int position;
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
                soldierPlayer = hit.collider.gameObject;
                Healt move = soldierPlayer.GetComponent<Healt>();
                if (soldierPlayer.CompareTag("SoldierGray"))
                {
                    if (move.move > 0)
                    {
                        position = grid.WorldToCell(soldierPlayer.transform.position);
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
    public void finishMove()
    {
        Healt move = soldierPlayer.GetComponent<Healt>();
        move.move = move.move - 1;
    }
    public void restartMenu()
    {
        attackButton.SetActive(true);
        moveButton.SetActive(true);
        otherMenu.SetActive(false);
        buildMenu.SetActive(false);
        frontButton.SetActive(false);
        backButton.SetActive(false);
        upButton.SetActive(false);
        downButton.SetActive(false);
        frontAttack.SetActive(false);
        backAttack.SetActive(false);
        upAttack.SetActive(false);
        downAttack.SetActive(false);
    }
    public void MoveButton()
    {
        position.x = position.x + 1;
        Vector3 frontMove = grid.GetCellCenterWorld(position);
        Collider2D objectOnTile = Physics2D.OverlapPoint(frontMove);
        if (objectOnTile == null && position.x < -4)
        {
            attackButton.SetActive(false);
            moveButton.SetActive(false);
            frontButton.SetActive(true);
        }
        position.x = position.x - 2;
        Vector3 backMove = grid.GetCellCenterWorld(position);
        objectOnTile = Physics2D.OverlapPoint(backMove);
        if (objectOnTile == null && position.x > -15)
        {
            attackButton.SetActive(false);
            moveButton.SetActive(false);
            backButton.SetActive(true);
        }
        position.x = position.x + 1;
        position.y = position.y + 1;
        Vector3 upMove = grid.GetCellCenterWorld(position);
        objectOnTile = Physics2D.OverlapPoint(upMove);
        if (objectOnTile == null && position.y < 11)
        {
            attackButton.SetActive(false);
            moveButton.SetActive(false);
            upButton.SetActive(true);
        }
        position.y = position.y - 2;
        Vector3 downMove = grid.GetCellCenterWorld(position);
        objectOnTile = Physics2D.OverlapPoint(downMove);
        if (objectOnTile == null && position.y > 0)
        {
            attackButton.SetActive(false);
            moveButton.SetActive(false);
            downButton.SetActive(true);
        }
        position.y = position.y + 1;
    }
    public void frontMove()
    {
        position.x = position.x + 1;
        Vector3 frontMove = grid.GetCellCenterWorld(position);
        soldierPlayer.transform.position = frontMove;
        restartMoveMenu();
    }
    public void backMove()
    {
        position.x = position.x - 1;
        Vector3 backMove = grid.GetCellCenterWorld(position);
        soldierPlayer.transform.position = backMove;
        restartMoveMenu();
    }
    public void upMove()
    {
        position.y = position.y + 1;
        Vector3 upMove = grid.GetCellCenterWorld(position);
        soldierPlayer.transform.position = upMove;
        restartMoveMenu();
    }
    public void downMove()
    {
        position.y = position.y - 1;
        Vector3 downMove = grid.GetCellCenterWorld(position);
        soldierPlayer.transform.position = downMove;
        restartMoveMenu();
    }
    public void restartMoveMenu()
    {
        actionMenu.SetActive(false);
        frontButton.SetActive(false);
        backButton.SetActive(false);
        upButton.SetActive(false);
        downButton.SetActive(false);
        attackButton.SetActive(true);
        moveButton.SetActive(true);
        finishMove();
    }
    public void AttackButton()
    {
        position.x = position.x + 1;
        Vector3 frontMove = grid.GetCellCenterWorld(position);
        enemyFront = Physics2D.OverlapPoint(frontMove);
        if (enemyFront != null && (enemyFront.CompareTag("SoldierRed") || enemyFront.CompareTag("WorkerRed") || enemyFront.CompareTag("BaseRed") || enemyFront.CompareTag("BarracksRed")))
        {
            attackButton.SetActive(false);
            moveButton.SetActive(false);
            frontAttack.SetActive(true);
        }
        position.x = position.x - 2;
        Vector3 backMove = grid.GetCellCenterWorld(position);
        enemyBack = Physics2D.OverlapPoint(backMove);
        if (enemyBack != null && (enemyBack.CompareTag("SoldierRed") || enemyBack.CompareTag("WorkerRed") || enemyBack.CompareTag("BaseRed") || enemyBack.CompareTag("BarracksRed")))
        {
            attackButton.SetActive(false);
            moveButton.SetActive(false);
            backAttack.SetActive(true);
        }
        position.x = position.x + 1;
        position.y = position.y + 1;
        Vector3 upMove = grid.GetCellCenterWorld(position);
        enemyUp = Physics2D.OverlapPoint(upMove);
        if (enemyUp != null && (enemyUp.CompareTag("SoldierRed") || enemyUp.CompareTag("WorkerRed") || enemyUp.CompareTag("BaseRed") || enemyUp.CompareTag("BarracksRed")))
        {
            attackButton.SetActive(false);
            moveButton.SetActive(false);
            upAttack.SetActive(true);
        }
        position.y = position.y - 2;
        Vector3 downMove = grid.GetCellCenterWorld(position);
        enemyDown = Physics2D.OverlapPoint(downMove);
        if (enemyDown != null && (enemyDown.CompareTag("SoldierRed") || enemyDown.CompareTag("WorkerRed") || enemyDown.CompareTag("BaseRed") || enemyDown.CompareTag("BarracksRed")))
        {
            attackButton.SetActive(false);
            moveButton.SetActive(false);
            downAttack.SetActive(true);
        }
    }
    public void attackFront()
    {
        if (enemyFront.CompareTag("BaseRed"))
        {
            BaseElements baseHealt = enemyFront.GetComponent<BaseElements>();
            baseHealt.healt = baseHealt.healt - 1;
        } 
        Healt targetHealth = enemyFront.GetComponent<Healt>();
        if (targetHealth != null)
        {
            targetHealth.healt = targetHealth.healt - 1;
        }
        restartAttackMenu();
    }
    public void attackBack()
    {
        if (enemyBack.CompareTag("BaseRed"))
        {
            BaseElements baseHealt = enemyBack.GetComponent<BaseElements>();
            baseHealt.healt = baseHealt.healt - 1;
        }
        Healt targetHealth = enemyBack.GetComponent<Healt>();
        if (targetHealth != null)
        {
            targetHealth.healt = targetHealth.healt - 1;
        }
        restartAttackMenu();
    }
    public void attackUp()
    {
        if (enemyUp.CompareTag("BaseRed"))
        {
            BaseElements baseHealt = enemyUp.GetComponent<BaseElements>();
            baseHealt.healt = baseHealt.healt - 1;
        }
        Healt targetHealth = enemyUp.GetComponent<Healt>();
        if (targetHealth != null)
        {
            targetHealth.healt = targetHealth.healt - 1;
        }
        restartAttackMenu();
    }
    public void attackDown()
    {
        if (enemyDown.CompareTag("BaseRed"))
        {
            BaseElements baseHealt = enemyDown.GetComponent<BaseElements>();
            baseHealt.healt = baseHealt.healt - 1;
        }
        Healt targetHealth = enemyDown.GetComponent<Healt>();
        if (targetHealth != null)
        {
            targetHealth.healt = targetHealth.healt - 1;
        }
        restartAttackMenu();
    }
    public void restartAttackMenu()
    {
        actionMenu.SetActive(false);
        frontAttack.SetActive(false);
        backAttack.SetActive(false);
        upAttack.SetActive(false);
        downAttack.SetActive(false);
        attackButton.SetActive(true);
        moveButton.SetActive(true);
        finishMove();
    }
}
