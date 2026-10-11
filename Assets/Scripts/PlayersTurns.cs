using System;
using UnityEngine;

public class PlayersTurns : MonoBehaviour
{
    public GameObject redTurn;
    public GameObject grayTurn;
    public GameObject passRed;
    public GameObject passGray;
    //Gray
    public GameObject grayWorker;
    public GameObject graySoldier;
    public GameObject grayBuilding;
    //Red
    public GameObject redWorker;
    public GameObject redSoldier;
    public GameObject redBuilding;
    //End
    public GameObject redWin;
    public GameObject grayWin;
    void Start()
    {
        grayTurn.SetActive(true);
        passRed.SetActive(true);
        //Gray Active
        grayWorker.SetActive(true);
        graySoldier.SetActive(true);
        grayBuilding.SetActive(true);
        //Red Disable
        redWorker.SetActive(false);
        redSoldier.SetActive(false);
        redBuilding.SetActive(false);
    }
    void Update()
    {
        GameObject baseRed = GameObject.FindGameObjectWithTag("BaseRed");
        GameObject baseGray = GameObject.FindGameObjectWithTag("BaseGray");
        if (baseRed == null)
        {
            grayWin.SetActive(true);
        }
        if (baseGray == null)
        {
            redWin.SetActive(true);
        }
    }
    public void PassRed()
    {
        redTurn.SetActive(false);
        passGray.SetActive(false);
        grayTurn.SetActive(true);
        passRed.SetActive(true);
        //Gray Active
        grayWorker.SetActive(true);
        graySoldier.SetActive(true);
        grayBuilding.SetActive(true);
        //Red Disable
        redWorker.SetActive(false);
        redSoldier.SetActive(false);
        redBuilding.SetActive(false);
        GameObject[] soldiers = GameObject.FindGameObjectsWithTag("SoldierGray");
        foreach (GameObject soldier in soldiers)
        {
            Healt move = soldier.GetComponent<Healt>();
            if (move != null)
            {
                move.move = move.move + 1;
            }
        }
        GameObject[] workers = GameObject.FindGameObjectsWithTag("WorkerGray");
        foreach (GameObject worker in workers)
        {
            Healt move = worker.GetComponent<Healt>();
            if (move != null)
            {
                move.move = move.move + 1;
            }
        }
        GameObject[] barracks = GameObject.FindGameObjectsWithTag("BarracksGray");
        foreach (GameObject barrack in barracks)
        {
            Healt move = barrack.GetComponent<Healt>();
            if (move != null)
            {
                move.move = move.move + 1;
            }
        }
        GameObject baseGray = GameObject.FindGameObjectWithTag("BaseGray");
        if (baseGray != null)
        {
            BaseElements baseElements = baseGray.GetComponent<BaseElements>();

            if (baseElements != null)
            {
                baseElements.move = baseElements.move + 1;
            }
        }
    }
    public void PassGray()
    {
        redTurn.SetActive(true);
        passGray.SetActive(true);
        grayTurn.SetActive(false);
        passRed.SetActive(false);
        //Gray Disable
        grayWorker.SetActive(false);
        graySoldier.SetActive(false);
        grayBuilding.SetActive(false);
        //Red Active
        redWorker.SetActive(true);
        redSoldier.SetActive(true);
        redBuilding.SetActive(true);
        GameObject[] soldiers = GameObject.FindGameObjectsWithTag("SoldierRed");
        foreach (GameObject soldier in soldiers)
        {
            Healt move = soldier.GetComponent<Healt>();
            if (move != null)
            {
                move.move = move.move + 1;
            }
        }
        GameObject[] workers = GameObject.FindGameObjectsWithTag("WorkerRed");
        foreach (GameObject worker in workers)
        {
            Healt move = worker.GetComponent<Healt>();
            if (move != null)
            {
                move.move = move.move + 1;
            }
        }
        GameObject[] barracks = GameObject.FindGameObjectsWithTag("BarracksRed");
        foreach (GameObject barrack in barracks)
        {
            Healt move = barrack.GetComponent<Healt>();
            if (move != null)
            {
                move.move = move.move + 1;
            }
        }
        GameObject baseGray = GameObject.FindGameObjectWithTag("BaseRed");
        if (baseGray != null)
        {
            BaseElements baseElements = baseGray.GetComponent<BaseElements>();

            if (baseElements != null)
            {
                baseElements.move = baseElements.move + 1;
            }
        }
    }
}
