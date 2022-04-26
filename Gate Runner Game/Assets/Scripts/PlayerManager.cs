using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _ScoreText;
    public int Score = 0;
    public PlayerMovement PlayerMovementScript;
    public static PlayerManager instance;
    #region Singleton;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    private void Start()
    {
        _ScoreText.text = "Score";
    }
    public void SetScoreText()
    {
        if (Score > 0)
        {
            _ScoreText.text = Score.ToString();
        }
        else
        {
            _ScoreText.text = "0";
            PlayerMovementScript.enabled = false;
            CharacterAnim.Anim.SetTrigger("Dead");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            Score++;
            SetScoreText();
        }
    }
}