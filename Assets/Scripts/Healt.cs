using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;
public class Healt : MonoBehaviour
{
    public int healt;
    public int move;
    void Start()
    {
        if (gameObject.CompareTag("SoldierGray") || gameObject.CompareTag("SoldierRed"))
        {
            healt = 4;
        }
        if (gameObject.CompareTag("WorkerGray") || gameObject.CompareTag("WorkerRed"))
        {
            healt = 1;
        }
        if (gameObject.CompareTag("BarracksGray") || gameObject.CompareTag("BarracksRed"))
        {
            healt = 6;
        }
        move = 1;
    }
    void Update()
    {
        if (healt == 0)
        {
            Destroy(gameObject);
        }
    }
}