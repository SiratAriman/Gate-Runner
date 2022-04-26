using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GateTrigger : MonoBehaviour
{
    [SerializeField] private TextMeshPro TextPro;
    [SerializeField] private int DoorScore;
    [SerializeField] private bool IsReward;
    public GateTriggerCheck ParentTriggerScript;
    private void Start()
    {
        Settext();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!ParentTriggerScript.IsTrigerred)
        {
            if (other.CompareTag("Player"))
            {
                if (IsReward)
                {
                    PlayerManager.instance.Score += DoorScore;
                    PlayerManager.instance.SetScoreText();
                }
                else
                {
                    PlayerManager.instance.Score -= DoorScore;
                    PlayerManager.instance.SetScoreText();
                }
            }
            ParentTriggerScript.SetTriggered();

        }
    }
    public void Settext()
    {
        if (IsReward)
        {
            TextPro.text = "+ " + DoorScore.ToString();
        }
        else
        {
            TextPro.text = "- " + DoorScore.ToString();
        }
    }
}