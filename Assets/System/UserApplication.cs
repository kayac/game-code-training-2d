using System;

public abstract class UserApplication
{
	public static UserApplication Instantiate(UnityEngine.Object applicationScriptObject)
	{
		var currentAssembly = System.Reflection.Assembly.GetExecutingAssembly();
		Type type = null;
		foreach (var t in currentAssembly.GetTypes())
		{
			if (t.IsSubclassOf(typeof(UserApplication)))
			{
				if (t.Name.Contains(applicationScriptObject.name))
				{
					type = t;
					break;
				}
			}
		}
		
		UserApplication ret = null;
		if (type != null)
		{
			ret = System.Activator.CreateInstance(type) as UserApplication;
		}

		return ret;
	}

	// 毎フレーム呼ばれる
	public abstract void Update(IMachine machine);
}
