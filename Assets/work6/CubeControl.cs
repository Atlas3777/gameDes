using UnityEngine;

public class CubeControl : MonoBehaviour
{
    private Rigidbody _rb;
    public GameObject go;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void StartButton(){
        _rb.useGravity= true;
        go.SetActive(true);
    }

    public void StopButton(){
        _rb.useGravity= false;
        _rb.linearVelocity = Vector3.zero;
    }

    public void ChangeColorButton(){
        _rb.gameObject.GetComponent<Renderer>().material.color = Color.red;
    }
}