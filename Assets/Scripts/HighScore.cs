using UnityEngine;
using System.Collections;
using System;
using System.Data;
using Mono.Data.Sqlite;


public class HighScore : MonoBehaviour {

	private string connectionString;

	void Start () {
		connectionString = "URI=file:" + Application.dataPath + "/HighScore.s3db";
		GetScores ();
	}

	void Update (){
	}

	private void GetScores()
	{
		using (IDbConnection dbConnection = new SqliteConnection(connectionString))
			{
 			dbConnection.Open ();

			using (IDbCommand dbCmd = dbConnection.CreateCommand())
			{
				string sqlQuery = "SELECT * FROM Scores";
				dbCmd.CommandText = sqlQuery;

				using (IDataReader reader = dbCmd.ExecuteReader())
				{
					while(reader.Read())
					{
						Debug.Log (reader.GetString (1));
					}
					dbConnection.Close();
					reader.Close ();
			}
		}
}
	}
}
