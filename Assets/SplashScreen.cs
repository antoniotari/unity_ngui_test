using UnityEngine;
using System.Collections;
using System;

public class SplashScreen : MonoBehaviour 
{
	public UITexture bgTexture;
	//System.Timers.Timer aTimer = new System.Timers.Timer();

	//------------------------------------------------------------------------------
	void Start()
	{
		if(bgTexture == null)
		{
			bgTexture = GetComponent<UITexture>();
			if(bgTexture == null)
			{
				return;
			}
		}
		ConfigGui config = new ConfigGui (resp);
		StartCoroutine (config.getJson ());
	}

	//------------------------------------------------------------------------------
	void resp(ConfigGui config) {
		Debug.Log("TEST: " + config.appName);
		StartCoroutine (LoadImage (config.bgImageUrl));// "http://images.earthcam.com/ec_metros/ourcams/fridays.jpg"));
	}

	//------------------------------------------------------------------------------
	public IEnumerator LoadImage(string imageUrl)
	{
		WWW loader = new WWW(imageUrl);
		yield return loader;
		
		var texture = loader.texture;
		Shader shader = Shader.Find("Unlit/Transparent Colored");
		if(shader != null)
		{
			var material = new Material(shader);
			material.mainTexture = texture;
			bgTexture.material = material;
			bgTexture.color = Color.white;
			bgTexture.MakePixelPerfect();
			bgTexture.ResetAnchors();
		}
		yield return new WaitForSeconds(2.0f);
		Application.LoadLevel ("ngui02-test"); 
	}
}
