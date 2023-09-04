using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashController : MonoBehaviour
{
    public bool isOn = false;

    public void OnFlash()
    {
        if (isOn)
        {
            isOn = false;
        }
        else
        {
            isOn = true;
            LibTorch.TorchOn();
            LibTorch.StartTorch();
        }
    }
}

