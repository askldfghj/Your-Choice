using UnityEngine;
using System.Collections;

public class BGScroll : MonoBehaviour
{
    public float _speed;

    Vector3 mBGPosiInit;
    // Use this for initialization
    void Awake()
    {
        mBGPosiInit = new Vector3(810f, 0, 0);
    }

    void Start()
    {
        StartScroll();
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator BackGroundScroll()
    {
        while (true)
        {
            transform.Translate(-_speed * Time.deltaTime, 0, 0);
            if (transform.localPosition.x < -810f)
            {
                transform.localPosition = mBGPosiInit;
            }
            yield return null;
        }
    } 

    public void StopScroll()
    {
        StopCoroutine("BackGroundScroll");
    }

    public void StartScroll()
    {
        StartCoroutine("BackGroundScroll");
    }
}