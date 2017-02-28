using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterestPoint : MonoBehaviour {

	public enum Types { House, Shop}

    public Types Type;
    [Range(1, 75)]
    public uint MaxPersonsToHold = 3;
    [Range(0f, 1f)]
    public float InterestRate = 0.25f;
}
