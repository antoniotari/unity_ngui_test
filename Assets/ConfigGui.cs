using System;
using MiniJSON;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class ConfigGui
{
	public string appName;
	public string bgImageUrl;

	public delegate void callback(ConfigGui cg);
	public event callback Callback;

	//------------------------------------------------------------------------------
	public ConfigGui (callback c)
	{
		this.Callback = c;
	}

	//------------------------------------------------------------------------------
	public IEnumerator getJson()
	{
		string url = "http://s3.amazonaws.com/digiflare/videa/android/config/config-v1.6.json";
		WWW www = new WWW(url);
		//Load the data and yield (wait) till it's ready before we continue executing the rest of this method.
		yield return www;
		if (www.error == null)
		{  
			var stuff = Json.Deserialize(www.text)as Dictionary<string,object>;
			appName = ((Dictionary<string,object>)stuff["appConfig"])["title"].ToString();
			string imagesUrl=((Dictionary<string,object>)stuff["images"])["mappingUrl"].ToString();
			WWW wwwImg = new WWW(imagesUrl);
			yield return wwwImg;
			var stuffImg = Json.Deserialize(wwwImg.text)as Dictionary<string,object>;
			List<object> imgL = stuffImg["images"] as List<object>;
			Dictionary<string,object> imgElem = imgL[0] as Dictionary<string,object>;
			bgImageUrl =imgElem["url"].ToString();

			if(Callback != null)
			{
				Callback(this);
			}
			//return config;
		}
		else
		{
			Debug.Log ("ERROR: " + www.error);
		}
	}	
}


