/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.Android;

public class MapManager : MonoBehaviour
{
    public RawImage mapRawImage;

    [Header("¸Ê Á¤º¸ ¼³Á¤")]
    public string strBaseURL = "";
    private double latitude;
    private double longitude;
    //public double latitude;
    //public double longitude;
    public int zoom = 14;
    public int mapWidth;
    public int mapHeight;
    public string strAPIKey = "";

    void Start()
    {
        
        mapRawImage = GetComponent<RawImage>();
        StartCoroutine(LoadMap());
    }

    IEnumerator LoadMap()
    {
        string url = strBaseURL + "center=" + Input.location.lastData.latitude + "," + Input.location.lastData.longitude +
            "&zoom=" + zoom.ToString() + "&size=" + mapWidth.ToString() + "x" + mapHeight.ToString()
            + "&key=" + strAPIKey;

        Debug.Log("URL : " + url);

        url = UnityWebRequest.UnEscapeURL(url);
        UnityWebRequest req = UnityWebRequestTexture.GetTexture(url);

        yield return req.SendWebRequest();

        mapRawImage.texture = DownloadHandlerTexture.GetContent(req);
    }
}
*/