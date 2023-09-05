using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.Android;

public class MapManager : MonoBehaviour
{
    public RawImage mapRawImage;

    [Header("맵 정보 설정")]
    public string strBaseURL = "https://maps.googleapis.com/maps/api/staticmap?";
    public int zoom = 14;
    public int mapWidth = 640; // 원하는 이미지 크기로 변경하세요.
    public int mapHeight = 480; // 원하는 이미지 크기로 변경하세요.
    public string strAPIKey = "YOUR_API_KEY"; // 본인의 Google Maps API 키로 변경하세요.
    private double latitude;
    private double longitude;

    private IEnumerator Start()
    {
        // 위치 권한 요청
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
        }

        yield return GetLocation();

        StartCoroutine(LoadMap());
    }

    private IEnumerator GetLocation()
    {
        // 위치 권한이 승인되었는지 확인
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Debug.LogError("위치 권한이 승인되지 않았습니다.");
            yield break;
        }

        // 위치 서비스 초기화
        Input.location.Start();

        // 위치 정보를 기다림
        while (Input.location.status == LocationServiceStatus.Initializing)
        {
            yield return new WaitForSeconds(1);
        }

        // 위치 정보를 얻음
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.LogError("위치 정보를 얻을 수 없습니다.");
            yield break;
        }

        latitude = Input.location.lastData.latitude;
        longitude = Input.location.lastData.longitude;

        // 위치 서비스 중지
        Input.location.Stop();
    }

    private IEnumerator LoadMap()
    {
        string url = strBaseURL + "center=" + latitude + "," + longitude +
            "&zoom=" + zoom.ToString() + "&size=" + mapWidth.ToString() + "x" + mapHeight.ToString()
            + "&key=" + strAPIKey;

        Debug.Log("URL : " + url);

        url = UnityWebRequest.UnEscapeURL(url);
        UnityWebRequest req = UnityWebRequestTexture.GetTexture(url);

        yield return req.SendWebRequest();

        if (req.result == UnityWebRequest.Result.Success)
        {
            mapRawImage.texture = DownloadHandlerTexture.GetContent(req);
        }
        else
        {
            Debug.LogError("지도 이미지 로드 실패: " + req.error);
        }
    }

    public Vector2 GetGPSInfo()
    {
        Vector2 vPos = new Vector2(Input.location.lastData.latitude,
    Input.location.lastData.longitude);

        return vPos;
    }
}
