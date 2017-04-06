using UnityEngine;

public static class Data	
{
	//Static function for saving data
	//levelIndex - index of current scene;
	//isFinished - if true - next level will be unlock;
	//starsCount - how much stars we gained (3 is max);

	public static void SaveData(int levelIndex, bool isFinished, int starsCount,int highScoreCount)
	{
		PlayerPrefsX.SetBool("isFinished"+levelIndex.ToString(), isFinished);

		if (!PlayerPrefs.HasKey("startsCount"+levelIndex.ToString()))				
			PlayerPrefs.SetInt("startsCount"+levelIndex.ToString(), starsCount);

		else if(starsCount > PlayerPrefs.GetInt("startsCount"+levelIndex.ToString()))
				PlayerPrefs.SetInt("startsCount"+levelIndex.ToString(), starsCount);
        //highScoreCount
        if (!PlayerPrefs.HasKey("highScoreCount" + levelIndex.ToString()))
            PlayerPrefs.SetInt("highScoreCount" + levelIndex.ToString(), highScoreCount);

        else if (highScoreCount > PlayerPrefs.GetInt("highScoreCount" + levelIndex.ToString()))
            PlayerPrefs.SetInt("highScoreCount" + levelIndex.ToString(), highScoreCount);
    }

}