using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightPlugin : MonoBehaviour
{
    //후레시에 접근할 자바 라이브러리를 불러오는 변수
    public AndroidJavaClass javaObject;

    //후레시 켜졌는지 꺼졌는지 체크하는 불타입 변수
    public bool isFlashOn = false;

    void Start()
    {
        //후레시 자바 라이브러리를 불러옴
        javaObject = new AndroidJavaClass("com.myflashlight.flashlightlib.Flashlight");
    }

    //후레시를 켜는 클래스
    public void TurnOn()
    {
        //후레시를 켠다
        javaObject.CallStatic("on", GetUnityActivity());

        //후레시를 켰다고 체크하는 isFlashOn의 상태를 true로 바꾼다.
        isFlashOn = true;
    }

    //후레시를 끄는 클래스
    public void TurnOff()
    {
        //후레시를 끈다
        javaObject.CallStatic("off", GetUnityActivity());
        //후레시를 켰다고 체크하는 isFlashOn의 상태를 false로 바꾼다.
        isFlashOn = false;
    }

    //토글을 누를 때 나오는 클래스
    public void Tougletriggered()
    {
        
        //토글을 눌렀을 때 후레시가 켜져있다면
        if (isFlashOn)
        {
            //후레시 끄는 클래스를 켠다
            TurnOff();
        }
        //토글을 눌렀을 때 후레시가 꺼져있다면
        else
        {
            //후레시 켜는 클래스를 켠다
            TurnOn();
        }
    }

    //안드로이드 네이티브 코드를 유니티에서 켜기
    AndroidJavaObject GetUnityActivity(){
         using ( var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
         {
             return unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
         }
     }
}
