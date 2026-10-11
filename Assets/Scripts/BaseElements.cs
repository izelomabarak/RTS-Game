using UnityEngine;

public class BaseElements : MonoBehaviour
{
    public int healt;
    public int resurces;
    public int move;
    void Start()
    {
        healt = 8;
        resurces = 10;
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