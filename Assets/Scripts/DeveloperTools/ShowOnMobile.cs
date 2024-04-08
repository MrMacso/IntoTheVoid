using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOnMobile : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(Application.isMobilePlatform);
    }

}
