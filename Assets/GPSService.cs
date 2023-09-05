/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;
//using System.Numerics;
//using UnityEngine.UIElements;

public class GPSService : MonoBehaviour
{
    public Text textMsg;

    IEnumerator Start()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);

            while (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
            {
                yield return null;
            }

        }

        //Debug.Log("1");
        //Check if the user has location service enabled.
        if (!Input.location.isEnabledByUser) //위치 정보 접근을 허용한 상태여야만 다음으로 넘어가짐(위치 서비스 액세스 허용, 위치 서비스 시작)
            yield break;

        //Debug.Log("2");
        //Starts the location service.
        Input.location.Start();
        //Debug.Log("3");

        //Waits until the location service initializes , 서비스 초기화 대기
        int maxWait = 20;
        while (Input.location.status ==
            LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        //If the service didn't initialize in 20 seconds this cancels location service use.
        if (maxWait < 1)
        {
            textMsg.text = "Timed out";
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            textMsg.text = "Unable to determine device location";
            yield break;
        }
        else
        {
            while (true)
            {
                textMsg.text = "위치: "
                    + Input.location.lastData.latitude + " "
                    + Input.location.lastData.longitude + " "
                    + Input.location.lastData.horizontalAccuracy;

                yield return new WaitForSeconds(1);
            }
        }
        //Input.location.Stop();
    }

    public Vector2 GetGPSInfo()
    {
        Vector2 vPos = new Vector2(Input.location.lastData.latitude,
            Input.location.lastData.longitude);

        return vPos;
    }
}
*/