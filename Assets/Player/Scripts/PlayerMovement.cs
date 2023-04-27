using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    //[SerializeField] private float _maxSpeed;
    [SerializeField] private float _speedCoef;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
    }

    public void SetVectorVelocity(Vector3 vector)
    {
        _rb.velocity = vector * _speedCoef;
    }

    //private Vector3 MaxSpeedVectorLimiter(Vector3 inputVector)
    //{
    //    var outVector = new Vector3();
     
    //    float VarLimiter(float a)
    //    {
    //        if (a > _maxSpeed)
    //        {
    //            return _maxSpeed;
    //        }
    //        return a;
    //    }

    //    outVector.x = VarLimiter(inputVector.x);
    //    outVector.y = VarLimiter(inputVector.y);
    //    outVector.z = VarLimiter(inputVector.z);

    //    return outVector;
    //}
}