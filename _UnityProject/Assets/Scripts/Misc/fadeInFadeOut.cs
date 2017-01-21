using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class fadeInFadeOut : MonoBehaviour {


    Image _img;

	[SerializeField] bool isFadeIn;
    public bool IsFadeIn
    {
        get { return isFadeIn; }
        set { isFadeIn = value; }
    }
    [SerializeField] float fadeSpeed;


    void Awake()
    {
        _img = GetComponent<Image>();
    }

    void Update()
    {
        if (!IsFadeIn && _img.color.a > 0)
        {
            _img.color -= new Color(0, 0, 0, Time.deltaTime * fadeSpeed);
        }
        else if (IsFadeIn && _img.color.a < 1)
        {
            _img.color += new Color(0, 0, 0, Time.deltaTime * fadeSpeed);

        }

    }





}
