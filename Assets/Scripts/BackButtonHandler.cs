using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButtonHandler : MonoBehaviour
{
    //플래시라이트 플러그인 담는 변수
    public FlashlightPlugin flashlightScript;

    //뒤로가기 했을 때 나오는 씬의 이름
    public string ParentSceneName;

    void Update()
    {
        //폰에서 뒤로가기 키를 누를 때
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(flashlightScript != null)
            {
                flashlightScript.TurnOff();
            }

            //홈 씬이라면
            if (SceneManager.GetActiveScene().name == "Home")
            {
                //앱을 끄기 전에 폰 후레시 끄기
                if (flashlightScript != null && !flashlightScript.isFlashOn)
                {
                    flashlightScript.TurnOff();
                }
            }
            //홈 씬이 아니라면
            else
            {
                //뒤로가기 했을 때 나오는 씬의 이름으로 이동
                SceneManager.LoadScene(ParentSceneName);
            }
        }
    }
}