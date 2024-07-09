public interface IMachine
{
	public void SetResolution(int width, int height); // スクリーン解像度設定
	public int Width { get; } // スクリーン横解像度
	public int Height { get; } // スクリーン縦解像度
	public void Draw(int x, int y, byte red, byte green, byte blue); // 点を描画する
	public void GetPixel(out byte red, out byte green, out byte blue, int x, int y); // 点の色を取得する

	// キーボード検出
	public bool Up { get; }
	public bool Down { get; }
	public bool Left { get; }
	public bool Right { get; }
	public bool Space { get; }

	// 音
	public int SoundChannelCount { get; }
	public void PlaySound(int channel, float frequency, float dumping, float amplitude);

	// デバグ用 UnityEngine.Debug.LogFormat相当品
	public void Log(string message, params object[] args);
}
