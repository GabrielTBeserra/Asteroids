using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    [SerializeField]
    private Text ammos;

    [SerializeField]
    private Text ScoreText;

    [SerializeField]
    private GameObject[] healts;

    public static int Points;


    void Start()
    {
        ammos.text = "Quantidade de municao: 10";
       
    }
    
    public void LifeBar(int life)
    {
        switch (life)
        {
            case 3:
                healts[0].SetActive(true);
                healts[1].SetActive(true);
                healts[2].SetActive(true);
                break;
            case 2:
                healts[2].SetActive(false);
                break;
            case 1:
                healts[1].SetActive(false);
                healts[2].SetActive(false);
                break;
            case 0:
                healts[0].SetActive(false);
                healts[1].SetActive(false);
                healts[2].SetActive(false);
                break;
        }
    }

    public void Score(int score)
    {
       ScoreText.text = "Score: " + score;
    }

    public void Bullets(int count)
    {       
        ammos.text = $"Quantidade de municao: {count}";
    }
}
