using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class NpcDialogue : MonoBehaviour
{
    public Animator npcAnimation;
    public GameObject descriptionPanel;
    public GameObject timer;
    public EnemySpawner enemySpawner;
    public PlayerHealth playerHealth;

    [SerializeField] private TMP_Text npcTextUI;
    [SerializeField] private string[] npcLines;


    void OnEnable()
    {
        if (descriptionPanel != null)
            descriptionPanel.SetActive(true);

        string[] npcLines = new string[] {
        "���� ��� ��ŷ��" +
        "\n�ð��� �����ּ���!",
        "�׸��� �������" +
        "\n���� �����Կ�!",
        "��ŷ�� �����ϸ� �����忡��" +
        "\n��ȿŸ�� ���� �� �־��!"
    };

        string[] npcLines2 = new string[]
        {
        "��������?" +
        "\n�����̴�!",
        "�ѹ� �� ��ٷ��ּ���." +
        "\n�ٽ� �غ��Կ�!"
        };

        string[] npcLines3 = new string[]
        {
        "���� ������ ��," +
        "\n��û ��ġ�̳׿�...!",
        "���� ���� ���̺ش븦" +
        "\n���Ƶ帱�Կ�!"
        };

        string[] linesToUse;

        if (BossPhaseManager.Instance.currentPhase == 1)
            linesToUse = npcLines;
        else if (BossPhaseManager.Instance.currentPhase == 2)
            linesToUse = npcLines2;
        else
            linesToUse = npcLines3;

        npcAnimation.SetFloat("Looking", 0.66f); // ��ȭ ��� �� ���� �ٶ󺸱�


        DialogueManager.Instance.ShowDialogue(linesToUse, npcTextUI, () =>
        {
            if (playerHealth.CurrentHealth == 1)
            {
                Debug.Log("NPC�� �߰� ��縦 ���� ��� ����");
                DialogueManager.Instance.ShowDialogue(npcLines3, npcTextUI, () =>
                {
                    Debug.Log("NPC�� �߰� ��縦 �������");
                    playerHealth.PlayerHeal(1);
                    Debug.Log($"���ΰ� ü�� ȸ����. ���� ü���� {playerHealth.CurrentHealth}��");

                    // �߰� ��� ���� �ڿ� ��ó��
                    timer.SetActive(true);
                    npcAnimation.SetFloat("Looking", 0.33f);
                    enemySpawner.isSpawning = false; // ��� ���� ���
                    descriptionPanel.SetActive(false);
                });
            }
            else
            {
                // �߰� ��簡 �ʿ� ���� ���� �ٷ� ��ó��
                timer.SetActive(true);
                npcAnimation.SetFloat("Looking", 0.33f);
                descriptionPanel.SetActive(false);
            }
        });
    }


}