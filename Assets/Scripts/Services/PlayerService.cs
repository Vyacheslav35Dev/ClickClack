using UnityEngine;

namespace Services
{
    public class PlayerService : MonoBehaviour
    {
        public int Counter { get; private set; }

        public void SetScore(int score)
        {
            Counter = score;
        }
        
        public int GetScore()
        {
            return Counter;
        }
        
        public void SaveScore()
        {
            if (PlayerPrefs.GetInt ("score") < Counter) 
            {
                PlayerPrefs.SetInt ("score", Counter);
            }

            Counter = 0;
        }

        public string GetScoreText()
        {
            var score = PlayerPrefs.GetInt("score", 0);
            return score == 0 ? "" : score.ToString();
        }
    }
}