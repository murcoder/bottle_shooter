using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device device;

    private LineRenderer lineRenderer;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    private void Update()
    {
        device = SteamVR_Controller.Input((int)trackedObj.index);
        lineRenderer.SetPosition(0, transform.position);

        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
        {
            if(hit.transform.tag == "Teleport")
            {
                lineRenderer.SetPosition(1, hit.point);
                if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
                {
                    // Move player to pointed position
                    transform.parent.position = hit.point;
                }
            }
        } else
        {
            lineRenderer.SetPosition(1, transform.position);
        }
    }


}
