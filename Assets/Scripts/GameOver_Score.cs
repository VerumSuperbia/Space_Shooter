using UnityEngine;
using TMPro;

public class GameOver_Score : MonoBehaviour
{
    public static GameOver_Score instance;

    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Total Score: " + PlayerPrefs.GetInt("Last Score") + "\nHighScore: " + PlayerPrefs.GetInt("HighScore");
    }
}
