using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class Map
{
    Transform mapTransform;
    List<InterestPoint> _IPs = new List<InterestPoint>();
    public List<InterestPoint> IPs
    {
        get
        {
            return _IPs;
        }
    }

    public Map(Transform mapTransform)
    {
        this.mapTransform = mapTransform;
    }

    public void ScanIPs()
    {
        int childCount = mapTransform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            GameObject child = mapTransform.GetChild(i).gameObject;
            if (child.name.Contains("Interest Point"))
                IPs.Add(child.GetComponent<InterestPoint>());
        }
    }
}
