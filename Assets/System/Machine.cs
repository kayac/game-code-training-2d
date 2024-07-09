using UnityEngine;

public class Machine : IMachine
{
	public int Width { get => width; }
	public int Height { get => (pixels.Length / width); }
	public int SoundChannelCount { get => soundSynthesizer.ChannelCount; }
	public bool Up { get => upOn; }
	public bool Down { get => downOn; }
	public bool Left { get => leftOn; }
	public bool Right { get => rightOn; }
	public bool Space { get => spaceOn; }

	public bool A { get => aOn; }
	public bool S { get => sOn; }
	public bool W { get => wOn; }
	public bool Z { get => zOn; }
	public bool D { get => dOn; }

	public bool J { get => jOn; }
	public bool K { get => kOn; }
	public bool I { get => iOn; }
	public bool M { get => mOn; }
	public bool L { get => lOn; }

	// internal
	public Color32[] Pixels { get => pixels; }

	public Machine(int width, int height, SoundSynthesizer soundSynthesizer)
	{
		this.soundSynthesizer = soundSynthesizer;
		this.width = width;
		pixels = new Color32[width * height];
	}

	public void SetResolution(int width, int height)
	{
		this.width = width;
		pixels = new Color32[width * height];
	}

	public void GetPixel(out byte r, out byte g, out byte b, int x, int y)
	{
		r = g = b = 0;
		if ((x >= 0) && (x < width))
		{
			var index = (y * width) + x;
			if ((index >= 0) && (index < pixels.Length))
			{
				r = pixels[index].r;
				g = pixels[index].g;
				b = pixels[index].b;
			}
		}
	}

	public void Draw(int x, int y, byte r, byte g, byte b)
	{
		if ((x >= 0) && (x < width))
		{
			var index = (y * width) + x;
			if ((index >= 0) && (index < pixels.Length))
			{
				pixels[index] = new Color32(r, g, b, 255);
			}
		}
	}

	public void PlaySound(int channel, float frequency, float dumping, float amplitude)
	{
		soundSynthesizer.Play(
			channel, 
			frequency, 
			Mathf.Clamp01(dumping) * 0.001f, 
			Mathf.Clamp01(amplitude) * 1f);
	}

	public void Update()
	{
		upOn = Input.GetKey(KeyCode.UpArrow);
		downOn = Input.GetKey(KeyCode.DownArrow);
		leftOn = Input.GetKey(KeyCode.LeftArrow);
		rightOn = Input.GetKey(KeyCode.RightArrow);
		spaceOn = Input.GetKey(KeyCode.Space);

		aOn = Input.GetKey(KeyCode.A);
		sOn = Input.GetKey(KeyCode.S);
		wOn = Input.GetKey(KeyCode.W);
		zOn = Input.GetKey(KeyCode.Z);
		dOn = Input.GetKey(KeyCode.D);

		jOn = Input.GetKey(KeyCode.J);
		kOn = Input.GetKey(KeyCode.K);
		iOn = Input.GetKey(KeyCode.I);
		mOn = Input.GetKey(KeyCode.M);
		lOn = Input.GetKey(KeyCode.L);
	}

	public void Log(string message, params object[] args)
	{
		Debug.LogFormat(message, args);
	}

	// non public ----
	Color32[] pixels;
	int width;
	bool upOn;
	bool downOn;
	bool leftOn;
	bool rightOn;
	bool spaceOn;

	bool aOn, sOn, wOn, zOn, dOn;
	bool jOn, kOn, iOn, mOn, lOn;

	SoundSynthesizer soundSynthesizer;
}
