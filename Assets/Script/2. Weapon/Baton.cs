using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baton : MonoBehaviour, IWeapon
{
    //public KeyCode Key => KeyCode.A;
    public float Damage => 5f;
    public Animator playerAnimator;
    public Transform batonTransform;

    public AudioSource audioSource;
    public AudioClip swingClip;

    public void Attack()
    {
        Debug.Log("�ֵθ���");


        if (playerAnimator == null)
        {
            Debug.LogError("playerAnimator�� �Ҵ���� ����");
            return;
        }

        /*
        int dir = playerAnimator.GetInteger("Looking");

        dir -= 1;   // �÷��̾ ���� ���� ���� 1~4�� 0~3���� ��ȯ
        */


        // ���� Ʈ���� �ٲٸ� �޾ƿ� Looking ��
        float looking = playerAnimator.GetFloat("Looking");

        // float ���� ���� �ε����� ��ȯ
        int dir = 0;
        if (Mathf.Approximately(looking, 0.00f))
            dir = 0; // �Ʒ�
        else if (Mathf.Approximately(looking, 1.00f))
            dir = 1; // ��
        else if (Mathf.Approximately(looking, 0.33f))
            dir = 2; // ����
        else if (Mathf.Approximately(looking, 0.66f))
            dir = 3; // ������
        else
            dir = 0; // �⺻��(�Ʒ�)


        Vector3[] positions = {
        new Vector3(0, -0.5f, 0),       // �Ʒ�
        new Vector3(0, 0.4f, 0),        // ��
        new Vector3(-0.2f, -0.3f, 0),   // ����
        new Vector3(0.3f, -0.2f, 0)     // ������
    };

        float[] startZ = { -100f, 100f, -180f, -20f }; // �Ʒ�, ��, ����, ������

        batonTransform.gameObject.SetActive(true);
        batonTransform.localPosition = positions[dir];
        batonTransform.localEulerAngles = Vector3.zero;


        // ������ ���⸸ ����ó�� �ߴ� ��
        //Quaternion startRotation;
        //Quaternion endRotation;

        /*
        if (dir == 3) // ������
        {
            startRotation = Quaternion.Euler(0, 0, -20f);
            endRotation = Quaternion.Euler(0, 0, 100f);
        }
        else
        {
            startRotation = Quaternion.Euler(0, 0, startZ[dir]);
            endRotation = Quaternion.Euler(0, 0, startZ[dir] + 80f);
        }
        */
        Quaternion startRotation = Quaternion.Euler(0, 0, startZ[dir]);
        Quaternion endRotation = Quaternion.Euler(0, 0, startZ[dir] + 100f);
        
        playerAnimator.gameObject.GetComponent<MonoBehaviour>().StartCoroutine(RotateBaton(batonTransform, startRotation, endRotation, 0.1f));
    }
    private IEnumerator RotateBaton(Transform target, Quaternion from, Quaternion to, float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            target.localRotation = Quaternion.Slerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        if(swingClip != null && audioSource != null)
            audioSource.PlayOneShot(swingClip);

        target.localRotation = to;
        target.gameObject.SetActive(false);
    }

    public void PlayAnimaion()
    {
        Debug.Log("���к� �ִϸ��̼� ���");
    }
}
