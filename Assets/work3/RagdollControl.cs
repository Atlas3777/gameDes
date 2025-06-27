using UnityEngine;

public class RagdollControl : MonoBehaviour
{
    public Animator animator;
    public Rigidbody[] allRigidbodies;
    
    void Awake()
    {
        for (int i = 0; i < allRigidbodies.Length; i++)
            allRigidbodies[i].isKinematic = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            MakePhysics();
    }

    private void MakePhysics()
    {
        animator.enabled = false;
        for (int i = 0; i < allRigidbodies.Length; i++)
            allRigidbodies[i].isKinematic = false;
    }
}
