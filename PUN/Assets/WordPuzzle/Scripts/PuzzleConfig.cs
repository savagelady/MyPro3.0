/// <summary>
/// Puzzle config. Take a array of string as input, which will be used to construct the puzzle
/// </summary>
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PuzzleConfig : MonoBehaviour {
	public string[] puzzleWords;
	public static int cellSize;
	public static string randString;
	public static string[] searchWords;//for accessing in searcher

	// Use this for initialization
	void Start () {
		searchWords = puzzleWords;


	}

	void Awake(){
		GetPuzzleSize ();
		RandomizeString (puzzleWords);
	}

	// Update is called once per frame
	void Update () {

		if (Application.loadedLevelName == "Stage1") {
			GameObject.Find ("w1").GetComponentInChildren<Text> ().text = puzzleWords [0];
			GameObject.Find ("w2").GetComponentInChildren<Text> ().text = puzzleWords [1];
			GameObject.Find ("w3").GetComponentInChildren<Text> ().text = puzzleWords [2];
			GameObject.Find ("w4").GetComponentInChildren<Text> ().text = puzzleWords [3];
		}
		if (Application.loadedLevelName == "Stage2") {
			GameObject.Find ("w1").GetComponentInChildren<Text> ().text = puzzleWords [0];
			GameObject.Find ("w2").GetComponentInChildren<Text> ().text = puzzleWords [1];
			GameObject.Find ("w3").GetComponentInChildren<Text> ().text = puzzleWords [2];
			GameObject.Find ("w4").GetComponentInChildren<Text> ().text = puzzleWords [3];
			GameObject.Find ("w5").GetComponentInChildren<Text> ().text = puzzleWords [4];
		}
		if (Application.loadedLevelName == "Stage3") {
			GameObject.Find ("w1").GetComponentInChildren<Text> ().text = puzzleWords [0];
			GameObject.Find ("w2").GetComponentInChildren<Text> ().text = puzzleWords [1];
			GameObject.Find ("w3").GetComponentInChildren<Text> ().text = puzzleWords [2];
			GameObject.Find ("w4").GetComponentInChildren<Text> ().text = puzzleWords [3];
			GameObject.Find ("w5").GetComponentInChildren<Text> ().text = puzzleWords [4];
			GameObject.Find ("w6").GetComponentInChildren<Text> ().text = puzzleWords [5];

		}
		if (Application.loadedLevelName == "Stage4") {
			GameObject.Find ("w1").GetComponentInChildren<Text> ().text = puzzleWords [0];
			GameObject.Find ("w2").GetComponentInChildren<Text> ().text = puzzleWords [1];
			GameObject.Find ("w3").GetComponentInChildren<Text> ().text = puzzleWords [2];
			GameObject.Find ("w4").GetComponentInChildren<Text> ().text = puzzleWords [3];
			GameObject.Find ("w5").GetComponentInChildren<Text> ().text = puzzleWords [4];
			GameObject.Find ("w6").GetComponentInChildren<Text> ().text = puzzleWords [5];
			GameObject.Find ("w7").GetComponentInChildren<Text> ().text = puzzleWords [6];

		}
		if (Application.loadedLevelName == "Stage5" || Application.loadedLevelName == "Room for 2") {
			GameObject.Find ("w1").GetComponentInChildren<Text> ().text = puzzleWords [0];
			GameObject.Find ("w2").GetComponentInChildren<Text> ().text = puzzleWords [1];
			GameObject.Find ("w3").GetComponentInChildren<Text> ().text = puzzleWords [2];
			GameObject.Find ("w4").GetComponentInChildren<Text> ().text = puzzleWords [3];
			GameObject.Find ("w5").GetComponentInChildren<Text> ().text = puzzleWords [4];
			GameObject.Find ("w6").GetComponentInChildren<Text> ().text = puzzleWords [5];
			GameObject.Find ("w7").GetComponentInChildren<Text> ().text = puzzleWords [6];

		}


	
		//w6.text = puzzleWords [5];

	}

	//Sums up the letters of the puzzle words to calculate the size of the cells needed to
	//hold the puzzle
	public void GetPuzzleSize()
	{
		//First calculate the total number of letters
		int letterCount = 0;
		foreach (string str in puzzleWords) {
			letterCount += str.Length;
		}
		PlayerPrefs.SetInt ("count", letterCount);
		Debug.Log ("Total letters : " + letterCount.ToString ());

		//For doing a square cell matrix we need to get the square that can hold these cells
		float sqRoot = Mathf.Sqrt((float)letterCount);
		//Extra one cell is added so we have enough room to move blocks around
		cellSize = Mathf.RoundToInt (sqRoot) + 1;

		Debug.Log ("Matrix size : " + cellSize.ToString ());


	}

	//This will shuffle the letters for the puzzle

	void RandomizeString(string[] puzzleStringArray)
	{
		//concatenate the string to make a big string of letters
		string bigstring = "";
		foreach (string str in puzzleStringArray) {
			bigstring +=  str;
		}

		Debug.Log ("Big string is : " + bigstring);


		//Randomize the string
		//make character array
		System.Random rnd = new System.Random();
		char [] strChars = bigstring.ToCharArray();
		Debug.Log (strChars.Length);
		int i = strChars.Length;
		while (i>1) {
			i--;
			int j = rnd.Next (i+1);
			char val = strChars [j];
			strChars [j] = strChars [i];
			strChars [i] = val;
		}

		randString = new string (strChars);

		Debug.Log ("Randomized String : " + randString);

	}


}
