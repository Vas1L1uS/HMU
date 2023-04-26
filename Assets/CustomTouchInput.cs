using System;
using UnityEngine;
using UnityEngine.UI;
using Vector2 = UnityEngine.Vector2;

public class CustomTouchInput : MonoBehaviour
{
    [SerializeField] private Text _touchCount;
    [SerializeField] private Text _touchPosition;
    [SerializeField] private Text _touchDeltaPos;
    [SerializeField] private Text _touchCountFingers;
    [SerializeField] private Text _directionSwipe;
    [SerializeField] private Text _multiGesture;

    [SerializeField] private float _maxTimeSwipe;

    private Vector2 _startTouchPos = Vector2.zero;
    private float _startTouchTime;
    private float _previousDistance = 0;
    private float _startDistance = 0;
    private bool _isMultiGesture;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            _touchCount.text = touch.tapCount.ToString();
            _touchPosition.text = $"{Math.Round(touch.position.x)} : {Math.Round(touch.position.y)}";
            _touchCountFingers.text = Input.touches.Length.ToString();

            var touches = Input.touches;

            if (touch.phase == TouchPhase.Began)
            {
                _startTouchPos = touch.position;
                _startTouchTime = Time.time;
            }
            else if (touch.phase == TouchPhase.Ended && Time.time - _startTouchTime < _maxTimeSwipe)
            {
                _touchDeltaPos.text = $"{Math.Round(touch.position.x - _startTouchPos.x)} : {Math.Round(touch.position.y - _startTouchPos.y)}";

                if (Math.Abs(touch.position.y - _startTouchPos.y) < 50)
                {
                    if (touch.position.x - _startTouchPos.x >= 100)
                    {
                        _directionSwipe.text = "направо";
                    }
                    else if (touch.position.x - _startTouchPos.x <= -100)
                    {
                        _directionSwipe.text = "налево";
                    }
                    else
                    {
                        _directionSwipe.text = "не распознано";
                    }
                }
                else
                {
                    _directionSwipe.text = "не распознано";
                }
                  
            }

            if (touches.Length == 2)
            {
                if (touches[1].phase == TouchPhase.Began)
                {
                    _startDistance = Vector2.Distance(touches[0].position, touches[1].position);
                }

                if (_isMultiGesture == false)
                {
                    var currentDistDifference = Math.Abs(_startDistance - Vector2.Distance(touches[0].position, touches[1].position));
                    if (currentDistDifference > _startDistance * 0.1f)
                    {
                        _isMultiGesture = true;
                    }
                }

                if (_isMultiGesture)
                {
                    if (Vector2.Distance(touches[0].position, touches[1].position) > _previousDistance)
                    {
                        _multiGesture.text = "Увеличение";
                    }
                    else if (Vector2.Distance(touches[0].position, touches[1].position) < _previousDistance)
                    {
                        _multiGesture.text = "Уменьшение";
                    }
                    _previousDistance = Vector2.Distance(touches[0].position, touches[1].position);
                }
                else
                {
                    _isMultiGesture = false;
                    _multiGesture.text = "-";
                }
            }
            else
            {
                _isMultiGesture = false;
            }
        }
        else
        {
            _multiGesture.text = "-";
            _isMultiGesture = false;
        }
    }
}
