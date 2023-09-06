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
            if(flashlightScript != null)
            {
                flashlightScript.TurnOff();
            }

            //Ȩ ���̶��
            if (SceneManager.GetActiveScene().name == "Home")
            {
                //���� ���� ���� �� �ķ��� ����
                if (flashlightScript != null && !flashlightScript.isFlashOn)
                {
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