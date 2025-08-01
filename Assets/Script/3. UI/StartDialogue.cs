using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class StartDialogue : MonoBehaviour
{

    public GameObject descriptionPanel;
    public GameObject bossHealth;
    public EnemySpawner enemySpawner;
    public bool startGame = false;

    [SerializeField] private TMP_Text startTextUI;
    [SerializeField] private string[] startLines;


    void Start()
    {
        startGame = false;
        if (descriptionPanel != null)
            descriptionPanel.SetActive(true);

        string[] startLines = new string[] {
            "* zŰ�� ���� �����带 ������ �ּ���.\n" +
            "Shift Ű�� ���� ������ ���� ������ ������ �� �ֽ��ϴ�.",

            "* ���� xŰ�� ª�� �뽬�ؼ� ���� �� ������,\n" +
            "Tab Ű�� ���� ���⸦ ������ �� �ֽ��ϴ�."
        };

        DialogueManager.Instance.ShowDialogue(startLines, startTextUI, () => {
            descriptionPanel.SetActive(false);
            bossHealth.SetActive(true);
            startGame = true;
        });
    }

}