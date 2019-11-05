using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempSwap : MonoBehaviour
{
    public string First;
    public string Second;
    public float Duration = 1;

    public void Swap()
    {
        World.CURRENT.ActivePlayer.transform.Find(First).gameObject.SetActive(false);
        World.CURRENT.ActivePlayer.transform.Find(Second).gameObject.SetActive(true);
        Invoke("Unswap", Duration);
    }

    public void Unswap()
    {
        World.CURRENT.ActivePlayer.transform.Find(First).gameObject.SetActive(true);
        World.CURRENT.ActivePlayer.transform.Find(Second).gameObject.SetActive(false);
    }
}
