using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class PlayerDialogue : MonoBehaviour
{

    public GameObject descriptionPanel;

    [SerializeField] private TMP_Text playerTextUI;
    [SerializeField] private string[] playerLines;


    void Start()
    {
        if (descriptionPanel != null)
            descriptionPanel.SetActive(true);


        string[] playerLines = new string[] {
            "������� ����ȿ� ������" +
            "\n������ �ʴ� �� ����.",
            "�ƽ����� ���� ���� �θ��� �־�." +
            "\n� ������!",
        };

        DialogueManager.Instance.ShowDialogue(playerLines, playerTextUI, () =>
        {
            descriptionPanel.SetActive(false);
        });
    }
}