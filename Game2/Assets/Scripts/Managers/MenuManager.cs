using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{


    public void Execute()
    {
        StartCoroutine(SceneryManager.Instance.AsyncLoad(1));

        
    }

    public void Ouit()
    {
        Debug.Log("Quit");
    }
}
