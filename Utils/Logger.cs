using System.Linq;
using FMODUnity;
using KMod;

namespace GlobalUtil
{
	public class Logger
	{
		private static Logger _instance;
		private string _prefix;
		private bool initialized = false;

		public static void Init(UserMod2 mod)
		{
			if (initialized || mod == null) return;
			_instance = new Logger();
			_prefix = $"[{mod.Name}] ";
			initialized = true;
		}

		private void LogInfo(params object[] args)
		{
			Debug.Log(GetMessage(args));
		}

		private void LogWarning(params object[] args)
		{
			Debug.LogWarning(GetMessage(args));
		}

		private void LogError(params object[] args)
		{
			Debug.LogError(GetMessage(args));
		}

		private string GetMessage(object[] args)
		{
			return _prefix + string.Join(" ", args.Select(arg => arg.ToString()));
		}

		public static void Info(params object[] args)
		{
			_instance.LogInfo(args);
		}

		public static void Warning(params object[] args)
		{
			_instance.LogWarning(args);
		}

		public static void Error(params object[] args)
		{
			_instance.LogError(args);
		}
	}
}