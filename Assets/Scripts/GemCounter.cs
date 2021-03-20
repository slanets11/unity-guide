using UnityEngine;
using UnityEngine.UI;

public class GemCounter : MonoBehaviour
{
    public Text scoreText;
    
    private int score;
    
    public int Score
    {
        get => score;
        set
        {
            score = value;
            scoreText.text = $"Score: {score}";
        }
    }
}
