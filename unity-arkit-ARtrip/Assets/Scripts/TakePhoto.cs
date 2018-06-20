using UnityEngine;  
using System.Runtime.InteropServices;  

public class TakePhoto : MonoBehaviour  
{  
	[DllImport("__Internal")]  
	private static extern void _SavePhoto(string readAddr);  

	private string _cptrAddr;  

//	private void OnGUI()  
//	{  
//		if (GUILayout.Button("_SavePhoto!", GUILayout.Height(50), GUILayout.Width(200)))  
//		{  
//			Debug.Log("_SavePhoto");  
//			var readAddr = Application.persistentDataPath + "/" + _cptrAddr;  
//			_SavePhoto(readAddr);  
//		}  
//		if (GUILayout.Button("TakePhoto", GUILayout.Height(50), GUILayout.Width(200)))  
//		{  
//			Debug.Log("TakePhoto");  
//			var cptrAddr = "testpic"; //捕捉地址  
//			var readAddr = Application.persistentDataPath + "/" + cptrAddr;//读取地址，这两个地址在iOS里不一样  
//			Debug.Log("cptr:" + cptrAddr + ", read:" + readAddr);  
//			Application.CaptureScreenshot(cptrAddr);  
//			_cptrAddr = cptrAddr;  
//		}  
//	}  

	public void Screenshot(){
		Debug.Log("TakePhoto");  
		var cptrAddr = "testpic"; //捕捉地址  
		var readAddr = Application.persistentDataPath + "/" + cptrAddr;//读取地址，这两个地址在iOS里不一样  
		Debug.Log("cptr:" + cptrAddr + ", read:" + readAddr);  
		ScreenCapture.CaptureScreenshot(cptrAddr);  
		_cptrAddr = cptrAddr;  
		_SavePhoto(readAddr);  
	}
}  
