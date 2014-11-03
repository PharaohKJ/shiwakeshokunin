using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Paper {
	public enum Type { Normal, Junk };	
	public Paper.Type type {
				get;
				private set;
	}
	public Paper(Paper.Type t = Type.Normal) {
		this.type = t;
	}
};

public class PaperSet {
	public static int SetCount = 30;
	List<Paper> papers;

	public PaperSet() {
		papers = new List<Paper>();
		for (int i=0; i< PaperSet.SetCount; i++) {
			papers.Add (new Paper());
		}
		Paper junk = new Paper(Paper.Type.Junk);
		Debug.Log ("Junk = " + junk.type);
		papers[generate_next_junk()] = junk;
	}
	
	private int generate_next_junk() {
		int o = Random.Range(0, PaperSet.SetCount);
		Debug.Log ("Junk Index =" + o);
		return o;
	}

	public Paper p(int i) {
		return this.papers[i];
	}
};

public class Papers {
	int total_page = 0;
	int index = 0;
	PaperSet currentSet, nextSet;

	public Papers() {
		this.nextSet = new PaperSet ();
		this.currentSet = new PaperSet ();
	}	

	private void swap_next() {
		this.currentSet = this.nextSet;
		this.nextSet = new PaperSet ();
	}
	
	public void nextTurn(){
		total_page += 1;
		index += 1;
		// if next is overflow then swap next
		if (this.index == PaperSet.SetCount) {
			this.swap_next();
			index = 0;
		}
	}
	
	public Paper current() {
		return this.currentSet.p (this.index);
	}

	public Paper next() {
		if (this.index+1 == PaperSet.SetCount) {
			return nextSet.p(0);
		} else {
			return currentSet.p(this.index+1);
		}
	}

	public Paper nextnext() {
		if (this.index+2 == PaperSet.SetCount) {
			return nextSet.p(0);
		} else {
			return currentSet.p(this.index+2);
		}
	}

}