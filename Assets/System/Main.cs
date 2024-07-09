using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
	[SerializeField] Object applicationScript;
	[SerializeField] int screenHeight;
	[SerializeField] int screenWidth;
	[SerializeField] RawImage rawImage;
	[SerializeField] SoundSynthesizer soundSynthesizer;

	void Start()
	{
		Application.targetFrameRate = 60;
		soundSynthesizer.ManualStart(8);
		screenTexture = new Texture2D(screenWidth, screenHeight, TextureFormat.RGB24, false);
		screenTexture.filterMode = FilterMode.Point;
		
		rawImage.texture = screenTexture;
		machine = new Machine(screenWidth, screenHeight, soundSynthesizer);
		BootApplication();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape) || (currentScript != applicationScript))
		{
			currentScript = applicationScript;
			BootApplication();
		}

		machine.Update();
		if (application != null)
		{
			application.Update(machine);
		}

		if ((machine.Width != screenWidth) || (machine.Height != screenHeight))
		{
			screenWidth = machine.Width;
			screenHeight = machine.Height;
			screenTexture = new Texture2D(screenWidth, screenHeight, TextureFormat.RGB24, false);
			screenTexture.filterMode = FilterMode.Point;
			rawImage.texture = screenTexture;
			Vector2 size;
			var screenAspect = (float)Screen.width / (float)Screen.height;
			var textureAspect = (float)screenWidth / (float)screenHeight;

			if (screenAspect > textureAspect) // 横が余る
			{
				size = new Vector2(screenWidth * 256f / screenHeight, 256f);
			}
			else // 縦が余る
			{
				size = new Vector2(256f, screenHeight * 256f / screenWidth);
			}
			rawImage.rectTransform.sizeDelta = size;
		}

		screenTexture.SetPixels32(machine.Pixels);
		screenTexture.Apply();
	}

	// non public ----
	Texture2D screenTexture;
	Machine machine;
	UserApplication application;
	Object currentScript;

	void BootApplication()
	{
		soundSynthesizer.StopAll();
		for (var y = 0; y < machine.Height; y++)
		{
			for (var x = 0; x < machine.Width; x++)
			{
				machine.Draw(x, y, 0, 0, 0);
			}
		}

		application = UserApplication.Instantiate(applicationScript);
		if (application == null)
		{
			Debug.LogError(applicationScript.name + "という名前のクラスはないようだ。");
		}
	}
}
