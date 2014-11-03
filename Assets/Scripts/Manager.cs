using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Manager : MonoBehaviour {

	private Papers papers;
	private GameTime gameTime;
	private Score score;
	private static GameObject endLogo;

	// private GUIStyle m_guiStyle;
	public GUISkin guiSkin; //GUISkinを受け取る

	void Awake() {
		this.papers = new Papers(); 
		this.gameTime = new GameTime ();
		this.score = new Score ();
		endLogo = GameObject.Find("EndLogo");
		Debug.Log(endLogo);
	}

	void Reset() {
		this.papers = new Papers(); 
		this.gameTime = new GameTime ();
		this.score = new Score ();
	}

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
		AudioManager.Instance.PlayBGM("MainBGM");
		this.GameStart();
	}
	
	// Update is called once per frame
	void Update () {
		if(this.LimitTime()<=0) {
			if ( endLogo.GetComponent<MeshRenderer>().enabled == false)
				endLogo.GetComponent<MeshRenderer>().enabled = true;
		}
	}

	void OnGUI() {
		var v = this.gameTime.Remain ();
		var score = this.score.point;
		var jamming = this.IsJamming ();
		var lap = this.BestLap ();
		var lap_str = lap < 0 ? "-" : (lap/1000).ToString ("##.##");
		var current_lap_title = "";
		var current_lap_str = "";
		if (this.IsJamming ()) {
			current_lap_title = "LapTime: ";
			current_lap_str = (this.gameTime.CurrentLap () / 1000).ToString ("##.##");
		} else {
			current_lap_title = "LapTime: ";
			var lastLap = this.gameTime.LastLap ();
			if (lastLap > 0)
				current_lap_str = ( lastLap / 1000).ToString ("##.##");
			else
				current_lap_str = "-";
		}

		GUILayout.BeginArea(new Rect(0,0,300,300));
		GUILayout.Label(
						"Remain : " + (v/1000).ToString("##.##") + "\n" +
		                "Score  : " + score + "\n" +
		//                "Jam!   : " + jamming + "\n" + 
			            "BestLap: " + lap_str + "\n" + 
						current_lap_title + current_lap_str + "\n"
		                , guiSkin.label); 
		//GUISkinのLabel要素(GUIStyle)を適用
		GUILayout.EndArea();
	}

	public void GoNext(){
		papers.nextTurn ();
	}

	// Shredder Success
	public void ShredSuccess(){
		this.score.Add();
	}

	// Jam tter
	public void Jam(){
		this.gameTime.Jam();
	}

	// Is Jamming?
	public bool IsJamming() {
		return this.gameTime.IsJamming ();	
	}

	// recovery Jam
	public void ClearJam(){
		this.gameTime.RecoverJam();
	}

	// best Jam Recovery Time
	public double BestLap(){
		return this.gameTime.Best ();
	}

	// Remaining Time
	public double LimitTime(){
		return gameTime.Remain();
	}

	// GameStart
	public void GameStart(){
		gameTime.Start();
	}

	// 
	public int Score(){
		return this.score.point;
	}

	// current Paper
	public Paper CurrentPaper(){
		return papers.current();
	}

	// next Paper
	public Paper NextPaper(){
		return papers.next();
	}

	// next next Paper
	public Paper NextNextPaper() {
		return papers.nextnext ();
	}

}
