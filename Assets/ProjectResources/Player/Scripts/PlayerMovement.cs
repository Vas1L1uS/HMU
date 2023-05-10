using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float _currentSpeed;

    public float MaxSpeed { get => _maxSpeed; private set => _maxSpeed = value; }
    private float _maxSpeed;

    public float ForceFactor { get => _forceFactor; private set => _forceFactor = value; }
    private float _forceFactor;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
    }

    public void SetVectorVelocity(Vector2 vector)
    {
        vector /= 100;
        _currentSpeed = _rb.velocity.magnitude;
        _rb.velocity = new Vector3(vector.x * _maxSpeed, _rb.velocity.y, vector.y * _maxSpeed);


        //var newVector = new Vector3(GetSQRNumberWithSaveSign(vector.x), 0, GetSQRNumberWithSaveSign(vector.y));
        //if (_currentSpeed < _maxSpeed)
        //{
        //_rb.AddForce(newVector * _forceFactor);
        //}
    }

    private float GetSQRNumberWithSaveSign(float number)
    {
        if (number == 0)
        {
            return 0;
        }

        var result = Mathf.Pow(number, 2) * (number / Mathf.Abs(number));

        return result;
    }

    public void SetMovementSettings(float maxSpeed, float forceFactor)
    {
        MaxSpeed = maxSpeed;
        ForceFactor = forceFactor;
    }
}