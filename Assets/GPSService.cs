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
    public GameObject markerPrefab; // ��Ŀ ������

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

                // ��ġ�� ����Ǿ��� �� ��Ŀ�� ������Ʈ�մϴ�.
                UpdateMarkerPosition(new Vector2(Input.location.lastData.latitude, Input.location.lastData.longitude));

                yield return new WaitForSeconds(1);
            }
        }
        //Input.location.Stop();
    }

    // ��ġ ������ ������Ʈ�ϰ� ��Ŀ�� �̵��մϴ�.
    private void UpdateMarkerPosition(Vector2 newPosition)
    {
        if (currentMarker == null)
        {
            // ó�� ��ġ ������ ������ ��Ŀ�� �����մϴ�.
            currentMarker = Instantiate(markerPrefab);
        }

        // ���� ��ġ�� ���� ��ġ�� ���Ͽ� ��ġ�� ����Ǿ��� ���� ��Ŀ�� �̵���ŵ�ϴ�.
        if (newPosition != lastGPSPosition)
        {
            // Unity�� ��ǥ��� ��ȯ�Ͽ� ��Ŀ�� ��ġ�� ������Ʈ�մϴ�.
            currentMarker.transform.position = new Vector3(newPosition.x, newPosition.y, 0);

            // ���� ��ġ�� ���� ��ġ�� ������Ʈ�մϴ�.
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