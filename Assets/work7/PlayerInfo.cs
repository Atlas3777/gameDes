using UnityEngine.SceneManagement;

[System.Serializable]
public class PlayerInfo
{
    private int _score;

    public int Score
    {
        get => _score;
        set
        {
            _score = value;
            if (_score > 100)
            {
                _score = 0;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}