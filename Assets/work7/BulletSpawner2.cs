using UnityEngine;

public class BulletSpawner2 : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject BulletPrefab;
    public float BulletVelocity = 20f;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject newBullet = Instantiate(
                BulletPrefab, transform.position, transform.rotation);
            newBullet.GetComponent<Rigidbody>().linearVelocity =
                transform.forward * BulletVelocity;
            
            audioSource.Play();
        }
    }
}