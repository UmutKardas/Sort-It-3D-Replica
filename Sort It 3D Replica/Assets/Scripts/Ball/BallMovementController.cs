using UnityEngine;
using DG.Tweening;

public class BallMovementController : MonoBehaviour
{

    [SerializeField] private Ease ease;
    [SerializeField] private float ballEndYValue;
    [SerializeField] private float duration;



    public void SetBallUpMovement(GameObject _ball)
    {
        _ball.transform.DOLocalMoveY(ballEndYValue, duration).SetEase(ease);
    }



    public void SetBallMoveNewTube(GameObject _ball, Vector3 _tube)
    {
        _ball.transform.DOLocalMoveX(_tube.x, duration).OnComplete(() => SetBallRigidbody(_ball));
    }



    private void SetBallRigidbody(GameObject _ball)
    {
        _ball.GetComponent<Rigidbody>().useGravity = true;
    }
}
