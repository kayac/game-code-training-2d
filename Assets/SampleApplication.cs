// 1. UnityEngineをUsingしてはならない
// 2. 他の.csを足さずこのファイルのみで完結させること
public class SampleApplication : UserApplication
{
	// 毎フレーム(=1/60秒間隔で)呼ばれる
	public override void Update(IMachine machine)
	{
		// sample code
		if (machine.Up)
		{
			machine.Draw(50, 50, 0, 255, 0);
		}
		else
		{
			machine.Draw(50, 50, 0, 0, 0);
		}
		machine.Log("hey {0}", machine.Down);
	}
}
