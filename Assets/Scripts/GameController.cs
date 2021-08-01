using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject[] activeViruses;
    List<GameObject> currentViruses = new List<GameObject>();

    private void Start() {
        foreach (var item in activeViruses)
        {
            currentViruses.Add(item);
        }
    }
    public void AddAVirus(GameObject virus)
    {
        currentViruses.Add(virus);
        Debug.Log($"Virus Added, total viruses {currentViruses.Count}");
    }

    public void RemoveAVirus()
    {
        if (currentViruses.Count > 0)
        {
            currentViruses.RemoveAt(0);
            Debug.Log($"Virus removed, total viruses {currentViruses.Count}");
        }

    }

    public int GetVirusCount()
    {
        return currentViruses.Count;
    }



    


}
