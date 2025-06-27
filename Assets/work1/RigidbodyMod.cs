using UnityEngine;

public class RigidbodyMod : MonoBehaviour
{
    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            //_rb.isKinematic = true;
            _rb.mass= 1.0f;
            _rb.linearDamping = 0;
            _rb.angularDamping = 0.05f;
            _rb.useGravity= true;
        }
    }
}

