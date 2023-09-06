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
            //Ȩ ���̶��
            if (SceneManager.GetActiveScene().name == "Home")
            {
                //���� ���� ���� �� �ķ��� ����
                if (flashlightScript != null && !flashlightScript.isFlashOn)
                {
                    flashlightScript.TurnOn();
                }
                //���� ����
                Application.Quit();
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