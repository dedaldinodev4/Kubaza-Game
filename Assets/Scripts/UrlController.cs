using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrlController : MonoBehaviour {

	public void GetUrl ( string value )
    {
        Application.OpenURL(value);
    }


}
