using System.Collections.Generic;
using UnityEngine;

public class TubeController : MonoBehaviour
{

    public List<GameObject> balls = new List<GameObject>();
    public bool isComplate;
    private string currentBallColor;



    public void CheckTubeBalls()
    {
        if (balls.Count > 1)
        {
            currentBallColor = balls[0].tag;
            isComplate = true;

            for (int i = 0; i < balls.Count; i++)
            {
                if (balls[i].gameObject.tag != currentBallColor)
                {
                    isComplate = false;
                }
            }
        }

        else if (balls.Count is 1)
        {
            isComplate = false;
        }

        else
        {
            isComplate = true;
        }

    }
}