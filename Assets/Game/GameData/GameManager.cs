﻿using UnityEngine;
using System.Collections;

public class GameManager {
	/*
	private static GameMananger instance;
	
	private GameMananger() {
		// initialize your game manager here. Do not reference to GameObjects here (i.e. GameObject.Find etc.)
		// because the game manager will be created before the objects
	}    


	
	public static GameManager Instance {
		get {
			if(instance==null) {
				instance = new GameManager();
			}
			
			return instance;
		}
	}
	
	// Add your game mananger members here
	public void Pause(bool paused) {
	}
	*/
}

public enum GameStates {
	Intro,
	Mainmenu,
	LevelSelection
}
