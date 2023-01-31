using UnityEngine;

public class PlayerInputController : MonoBehaviour
{

    [Header("Raycast")]
    [SerializeField] private LayerMask layerMask;
    private Ray mousePosition;
    RaycastHit hit;


    [Header("Other")]
    [SerializeField] private GameObject lastBall;
    [SerializeField] private BallMovementController ballMovementController;
    [SerializeField] private TubeManager tubeManager;
    [SerializeField] private bool select;



    void Update()
    {
        SelectTube();
    }



    private void SelectTube()
    {
        mousePosition = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(mousePosition, out hit, Mathf.Infinity, layerMask) && Input.GetMouseButtonDown(0))
        {
            TubeController _tubeController = hit.collider.gameObject.GetComponent<TubeController>();
            if (GetTubeLastChild(_tubeController))
            {
                if (!select)
                {
                    lastBall = _tubeController.balls[_tubeController.balls.Count - 1];
                    _tubeController.balls.Remove(lastBall);
                    lastBall.GetComponent<Rigidbody>().useGravity = false;
                    ballMovementController.SetBallUpMovement(lastBall);
                    select = true;
                }

                else
                {
                    SetBallinNewTube(_tubeController);
                }
            }

            else
            {
                if (select)
                {
                    SetBallinNewTube(_tubeController);
                }
            }
        }
    }



    private void SetBallinNewTube(TubeController _tubeController)
    {
        _tubeController.balls.Add(lastBall);
        ballMovementController.SetBallMoveNewTube(lastBall, hit.collider.gameObject.transform.position);
        select = false;
        tubeManager.CheckLevelComplate();
    }



    private bool GetTubeLastChild(TubeController _tubeController)
    {
        return _tubeController.balls.Count > 0;
    }
}
