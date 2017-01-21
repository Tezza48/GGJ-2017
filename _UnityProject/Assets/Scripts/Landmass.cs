using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landmass : MonoBehaviour
{

    [SerializeField][Tooltip("Bitflag for this landmas's tag. \nShould be power of 2")]
    private int landmassFlag;

    public int LandmassFlag { get { return landmassFlag; } }
}
