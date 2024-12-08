using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static int Health;
    public static int Score;
    public Text HealthText;
    public Text ScoreText;
    // Start is called before the first frame update
    void Start()
    {
        Health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        HealthText.text = Health.ToString() + "%";
        ScoreText.text = Score.ToString();
    }
}
