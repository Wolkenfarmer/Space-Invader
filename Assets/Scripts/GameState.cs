public static class GameState
{
	public static bool IsEndless;

	// Saves the current level we are in. This is required because otherwise, we would need to pass the level to the gameController somehow before its start method is called.
	static int endlessLevel = 1;
	static int storyLevel = 1;

	public static int Level
	{
		get
		{
			if (IsEndless)
				return endlessLevel;

			return storyLevel;
		}
		set
		{
			if (IsEndless)
				endlessLevel = value;
			else
				storyLevel = value;
		}
	}

	// TODO implement save/load plumbing
}
