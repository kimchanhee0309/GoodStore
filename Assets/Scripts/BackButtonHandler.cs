using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButtonHandler : MonoBehaviour
{
    //�÷��ö���Ʈ �÷����� ��� ����
    public FlashlightPlugin flashlightScript;

    //�ڷΰ��� ���� �� ������ ���� �̸�
    public string ParentSceneName;

    void Update()
    {
        //������ �ڷΰ��� Ű�� ���� ��
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //�ķ��ð� ���� �ִٸ�
            if(flashlightScript != null)
            {
                //�ķ��� ����
                flashlightScript.TurnOff();
            }

            //Ȩ ���̶��
            if (SceneManager.GetActiveScene().name == "Home")
            {
                //���� ���� ���� �ķ��� �����ִ��� Ȯ���ؼ� �����ִٸ�
                if (flashlightScript != null && flashlightScript.isFlashOn)
                {
                    //�� �ķ��� ����
                    flashlightScript.TurnOff();
                }
            }
            //Ȩ ���� �ƴ϶��
            else
            {
                //�ڷΰ��� ���� �� ������ ���� �̸����� �̵�
                SceneManager.LoadScene(ParentSceneName);
            }
        }
    }
}