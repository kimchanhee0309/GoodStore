using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

public class ImageTrackingService : MonoBehaviour
{
    public ARTrackedImageManager manager;

    private void OnEnable()
    {
        manager.trackedImagesChanged += OnChanged;
    }

    private void OnDisable()
    {
        manager.trackedImagesChanged -= OnChanged;    
    }

    void OnChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach(ARTrackedImage t in eventArgs.added)
        {

        }
        foreach(ARTrackedImage t in eventArgs.updated)
        {

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
