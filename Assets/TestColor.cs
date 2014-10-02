using UnityEngine;
using System.Collections;

public class TestColor : MonoBehaviour {

	public void MakeItRed()
	{
		GetComponent<UIWidget> ().color = Color.red;
	}

	public void MakeItBlue()
	{
		GetComponent<UIWidget> ().color = Color.blue;
	}

	public void MakeItGreen()
	{
		GetComponent<UIWidget> ().color = Color.green;
	}
}

