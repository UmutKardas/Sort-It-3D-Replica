using System.Collections.Generic;
using UnityEngine;

public class TubeManager : MonoBehaviour
{
    [SerializeField] private int tubeCount;
    [SerializeField] private int isComplateCount;

    public List<GameObject> nextLevelGameObjects = new List<GameObject>();
    public List<TubeController> tubeControllers = new List<TubeController>();


    public void CheckLevelComplate()
    {
        isComplateCount = 0;
        for (int i = 0; i < tubeControllers.Count; i++)
        {
            tubeControllers[i].CheckTubeBalls();

            if (tubeControllers[i].isComplate is true)
            {
                isComplateCount++;
            }
        }

        if (isComplateCount == tubeCount)
        {
            for (int i = 0; i < nextLevelGameObjects.Count; i++)
            {
                nextLevelGameObjects[i].SetActive(true);
            }
        }
    }
}
