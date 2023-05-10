using UnityEngine;

public class JoystickManager : MonoBehaviour
{
    [SerializeField] private Transform _button;
    [SerializeField] private float _maxLenght;

    private Touch _firstTouch;

    private void StartTouch(Vector2 inputPosition)
    {
        _button.localPosition = Vector3.zero;
        this.transform.position = inputPosition;
    }

    private void MovedTouch(Vector3 inputPosition, float maxLenght)
    {
        _button.position = Vector3.ClampMagnitude(inputPosition - this.transform.position, maxLenght) + this.transform.position;
    }

    public Vector2 GetTouchVector()
    {
        var a = Vector2.ClampMagnitude(_firstTouch.position - new Vector2(this.transform.position.x, this.transform.position.y), _maxLenght) / _maxLenght * 100;
        return a;
    }

    private void Update()
    {
        WhileTouch(Input.touches);
    }

    private void WhileTouch(Touch[] touches)
    {
        if (touches.Length > 0)
        {
            _firstTouch = touches[0];
            if (_firstTouch.phase == TouchPhase.Began)
            {
                StartTouch(_firstTouch.position);
            }
            else if (touches[0].phase == TouchPhase.Moved)
            {
                MovedTouch(_firstTouch.position, _maxLenght);
                GetTouchVector();
            }
        }
    }
}