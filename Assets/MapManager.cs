using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using UnityEngine.Timeline;

public class MapManager : MonoBehaviour
{
    public RawImage mapRawImage;

    [Header("Map SET")]

    public string strBaseURL = "";

    public int zoom = 17;
    public int mapWidth;
    public int mapHeight;
    public string strAPIKey = "";

    //public GPSlocation GPSlocation;
    private double latitude = 37.477355511121274;
    private double longitude = 126.86260087181347;

    private double save_latitude = 0;
    private double save_longitude = 0;

    // Start is called before the first frame update
    void Start()
    {
        mapRawImage = GetComponent<RawImage>();
        StartCoroutine(WaitForSecond());
    }

    private void Update()
    {
        latitude = Input.location.lastData.latitude;
        longitude = Input.location.lastData.longitude;
        //print("location" + latitude + " " + longitude);
    }

    IEnumerator WaitForSecond()
    {
        while (true)
        {

            if (save_latitude != latitude || save_longitude != longitude)
            {
                save_latitude = latitude;
                save_longitude = longitude;
                StartCoroutine(LoadMap());
            }
            yield return new WaitForSeconds(3f);
        }
        
        //yield return new WaitForSeconds(1f);
    }
    IEnumerator LoadMap()
    {
        string url = strBaseURL + "center=" + latitude + "," + longitude +
            "&zoom=" + zoom.ToString() +
            "&size=" + mapWidth.ToString() + "x" + mapHeight.ToString()
            + "&markers=color:green%7Clabel:S%7C" + 37.477355511121274 + "," + 126.86260087181347 +  "&key=" + strAPIKey;

        Debug.Log("URL : " + url);

        url = UnityWebRequest.UnEscapeURL(url);
        UnityWebRequest req = UnityWebRequestTexture.GetTexture(url);

        yield return req.SendWebRequest(); 

        mapRawImage.texture = DownloadHandlerTexture.GetContent(req);
    }
}


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
//    public string strBaseURL = "";
//    private double latitude;
//    private double longitude;
//    //public double latitude;
//    //public double longitude;
//    public int zoom = 14;
//    public int mapWidth;
//    public int mapHeight;
//    public string strAPIKey = "";

//    void Start()
//    {

//        mapRawImage = GetComponent<RawImage>();
//        StartCoroutine(LoadMap());
//    }

//    IEnumerator LoadMap()
//    {
//        string url = strBaseURL + "center=" + Input.location.lastData.latitude + "," + Input.location.lastData.longitude +
//            "&zoom=" + zoom.ToString() + "&size=" + mapWidth.ToString() + "x" + mapHeight.ToString()
//            + "&key=" + strAPIKey;

//        Debug.Log("URL : " + url);

//        url = UnityWebRequest.UnEscapeURL(url);
//        UnityWebRequest req = UnityWebRequestTexture.GetTexture(url);

//        yield return req.SendWebRequest();

//        mapRawImage.texture = DownloadHandlerTexture.GetContent(req);
//    }
//}