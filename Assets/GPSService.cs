using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;
using Google.Maps;
using Google.Maps.Coord;

//using System.Numerics;
//using UnityEngine.UIElements;

public class GPSService : MonoBehaviour
{
    public Text textMsg;
    public GameObject markerPrefab; // 마커 프리팹

    private Vector2 lastGPSPosition;
    private GameObject currentMarker;

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
        if (!Input.location.isEnabledByUser)
            yield break;

        //Debug.Log("2");
        //Starts the location service.
        Input.location.Start();
        //Debug.Log("3");

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
                textMsg.text = "Map SET "
                    + Input.location.lastData.latitude + " "
                    + Input.location.lastData.longitude + " "
                    + Input.location.lastData.horizontalAccuracy;

                // 위치가 변경되었을 때 마커를 업데이트합니다.
                UpdateMarkerPosition(new Vector2(Input.location.lastData.latitude, Input.location.lastData.longitude));

                yield return new WaitForSeconds(1);
            }
        }
        //Input.location.Stop();
    }

    // 위치 정보를 업데이트하고 마커를 이동합니다.
    private void UpdateMarkerPosition(Vector2 newPosition)
    {
        if (currentMarker == null)
        {
            // 처음 위치 정보를 받으면 마커를 생성합니다.
            currentMarker = Instantiate(markerPrefab);
        }

        // 현재 위치와 이전 위치를 비교하여 위치가 변경되었을 때만 마커를 이동시킵니다.
        if (newPosition != lastGPSPosition)
        {
            // Unity의 좌표계로 변환하여 마커의 위치를 업데이트합니다.
            currentMarker.transform.position = new Vector3(newPosition.x, newPosition.y, 0);

            // 이전 위치를 현재 위치로 업데이트합니다.
            lastGPSPosition = newPosition;
        }
    }

    public Vector2 GetGPSInfo()
    {
        Vector2 vPos = new Vector2(Input.location.lastData.latitude,
            Input.location.lastData.longitude);

        return vPos;
    }
}