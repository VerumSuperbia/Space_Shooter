using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Life : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 100;
    public Image hpBarImage;
    public Color fullHealthColor = Color.green;
    public Color lowHealthColor = Color.red;
    Vector3 originalPosition;
    private Score_Manager score_Manager;
    private GameObject score;
    public AudioSource lost;
    private void Start()
    {
        originalPosition = hpBarImage.rectTransform.localPosition;
    }
    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            lost.Play();
            score = GameObject.FindWithTag("Score");
            score_Manager = score.GetComponent<Score_Manager>();
            int total = score_Manager.GetScore();
            PlayerPrefs.SetInt("Last Score", total);
            int highScore = PlayerPrefs.GetInt("HighScore");
            if (highScore < total)
            {
                PlayerPrefs.SetInt("HighScore", total);
            }
            PlayerPrefs.Save();
            SceneManager.LoadScene("GameOver");
        }
        // Calculate the current health percentage
        float healthPercentage = (float)currentHealth / (float)maxHealth;
        // Adjust the size of the HP bar image to match the health percentage
        Vector3 newPosition = originalPosition;
        newPosition.x = newPosition.x - (hpBarImage.rectTransform.rect.width* (1 - healthPercentage));
        hpBarImage.rectTransform.localPosition = newPosition; 
        // Adjust the color of the HP bar image based on the current health percentage
        Color newColor = Color.Lerp(lowHealthColor, fullHealthColor, healthPercentage);
        hpBarImage.color = newColor;
    }
    public void UpdateHealth(int newHealth)
    {
        currentHealth = Mathf.Clamp(newHealth, 0, maxHealth);
    }
    
}
