using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour {

    public GameObject MapGO;

	void Start () {
        Map map = new Map(MapGO.transform);
        map.ScanIPs();
        foreach(InterestPoint IP in map.IPs)
        {
            Debug.Log("Found IP (" + IP.gameObject.name + ") with value of " + IP.InterestRate);
        }
	}
	
}
