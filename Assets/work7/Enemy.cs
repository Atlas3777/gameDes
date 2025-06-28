using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject cubePiecePrefab;
    public float explodeForce = 500f;
    public AudioSource explodeSoundSource;
    [SerializeField] TMP_Text textScore;
    private int count;

    private void Awake()
    {
        explodeSoundSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            AddScore();
            AudioSource.PlayClipAtPoint(explodeSoundSource.clip, transform.position);
            ExplodeCube();
        }
    }

    void Start()
    {
        textScore.text = "Score: " + Progress.Instance.PlayerInfo.Score.ToString();   
    }

    private void AddScore()
    {
        Progress.Instance.PlayerInfo.Score += 10;
        textScore.text = "Score: " + Progress.Instance.PlayerInfo.Score.ToString();
    }


    private void ExplodeCube()
    {
        for (int x = 0; x < 4; x++)
        {
            for (int y = 0; y < 4; y++)
            {
                for (int z = 0; z < 4; z++)
                {
                    Vector3 piecePosition = transform.position + new Vector3(x, y, z) * 0.5f;
                    GameObject piece = Instantiate(cubePiecePrefab, piecePosition, Quaternion.identity);
                    Rigidbody pieceRigidbody = piece.GetComponent<Rigidbody>();
                    pieceRigidbody.AddExplosionForce(explodeForce, transform.position, 5f);
                }
            }
        }

        Destroy(gameObject);
    }
}