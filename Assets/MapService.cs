//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Networking;
//using UnityEngine.UI;
//using UnityEngine.Android;

//public class MapManager : MonoBehaviour
//{
//    public RawImage mapRawImage;

//    [Header("�� ���� ����")]
//    public string strBaseURL = "https://maps.googleapis.com/maps/api/staticmap?";
//    public int zoom = 14;
//    public int mapWidth = 640; // ���ϴ� �̹��� ũ��� �����ϼ���.
//    public int mapHeight = 480; // ���ϴ� �̹��� ũ��� �����ϼ���.
//    public string strAPIKey = "YOUR_API_KEY"; // ������ Google Maps API Ű�� �����ϼ���.
//    private double latitude;
//    private double longitude;

//    private IEnumerator Start()
//    {
//        // ��ġ ���� ��û
//        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
//        {
//            Permission.RequestUserPermission(Permission.FineLocation);
//        }

//        yield return GetLocation();

//        StartCoroutine(LoadMap());
//    }

//    private IEnumerator GetLocation()
//    {
//        // ��ġ ������ ���εǾ����� Ȯ��
//        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
//        {
//            Debug.LogError("��ġ ������ ���ε��� �ʾҽ��ϴ�.");
//            yield break;
//        }

//        // ��ġ ���� �ʱ�ȭ
//        Input.location.Start();

//        // ��ġ ������ ��ٸ�
//        while (Input.location.status == LocationServiceStatus.Initializing)
//        {
//            yield return new WaitForSeconds(1);
//        }

//        // ��ġ ������ ����
//        if (Input.location.status == LocationServiceStatus.Failed)
//        {
//            Debug.LogError("��ġ ������ ���� �� �����ϴ�.");
//            yield break;
//        }

//        latitude = Input.location.lastData.latitude;
//        longitude = Input.location.lastData.longitude;

//        // ��ġ ���� ����
//        Input.location.Stop();
//    }

//    private IEnumerator LoadMap()
//    {
//        string url = strBaseURL + "center=" + latitude + "," + longitude +
//            "&zoom=" + zoom.ToString() + "&size=" + mapWidth.ToString() + "x" + mapHeight.ToString()
//            + "&key=" + strAPIKey;

//        Debug.Log("URL : " + url);

//        url = UnityWebRequest.UnEscapeURL(url);
//        UnityWebRequest req = UnityWebRequestTexture.GetTexture(url);

//        yield return req.SendWebRequest();

//        if (req.result == UnityWebRequest.Result.Success)
//        {
//            mapRawImage.texture = DownloadHandlerTexture.GetContent(req);
//        }
//        else
//        {
//            Debug.LogError("���� �̹��� �ε� ����: " + req.error);
//        }
//    }

//    public Vector2 GetGPSInfo()
//    {
//        Vector2 vPos = new Vector2(Input.location.lastData.latitude,
//    Input.location.lastData.longitude);

//        return vPos;
//    }
//}
