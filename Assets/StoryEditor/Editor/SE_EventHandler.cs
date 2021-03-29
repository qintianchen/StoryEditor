using UnityEngine;

public static class SE_EventHandler
{
	public static void HandleEvent(Event e)
	{
		switch (e.type)
		{
			case EventType.MouseDrag:
				OnDrag(e.delta);
				break;
			case EventType.ScrollWheel:
				OnScrollWheel(e.delta);
				break;
		}
	}

	private static void OnDrag(Vector2 delta)
	{
		SE_Window.offset += delta;
		GUI.changed = true;
	}

	private static void OnScrollWheel(Vector2 delta)
	{
		SE_Window.scale -= delta.y / 10;
		SE_Window.scale = SE_Window.scale < 0.1f ? 0.1f : SE_Window.scale;
		// Debug.Log($"scale = {SE_Window.scale}");
		GUI.changed = true;
	}
}