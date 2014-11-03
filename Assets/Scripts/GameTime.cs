using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;

public class JamRecord {

	public DateTime Start{ set; get;}
	public DateTime End{ set; get; }
	public Boolean Cleard{ set; get; }

	public double Duration(){
		if (this.Cleard)
			return (this.End - this.Start).TotalMilliseconds;
		else
			return 99999999999999;
	}

	public JamRecord(){
		this.Start = DateTime.Now;
		this.Cleard = false;
	}

	public void Finish(){
		this.Cleard = true;
		this.End = DateTime.Now;
	}
}

public class GameTime {

	DateTime start{ set; get; }
	DateTime end{ set; get; }
	double bestLap = -1;
	double lastLap = -1;

	List<JamRecord> jam_records = new List<JamRecord> ();

	public void Start(double gameDuration = 60) {
		this.start = DateTime.Now;
		this.end = this.start.AddSeconds(gameDuration);
	}

	public double Remain() {
		double o = (this.end - DateTime.Now).TotalMilliseconds;
		if (o<=0) return 0;
		return o;
	}

	public void Jam() {
		jam_records.Add (new JamRecord ());
	}

	public Boolean IsJamming() {
		if (this.jam_records.Count == 0) return false;
		return !jam_records [jam_records.Count - 1].Cleard;
	}

	public void RecoverJam() {
		var target = jam_records [jam_records.Count - 1];
		target.Finish ();
		var current = target.Duration ();
		this.lastLap = current;
		if (bestLap < 0) {
			bestLap = current;
		} else {
			if (bestLap > current) {
				bestLap = current;
			}
		}
	}

	public int JamCount() {
		return jam_records.Count ();
	}

	// need IsJamming is True
	public double CurrentLap() {
		return (DateTime.Now - jam_records [jam_records.Count - 1].Start).TotalMilliseconds;
	}

	public double LastLap() {
		return this.lastLap;
	}
	public double Best() {
		return this.bestLap;
	}

	public double BestSort() {
		var sorted = jam_records.OrderBy (delegate(JamRecord jmr) {
				return jmr.Duration ();
		}
		).ToList ();
		return sorted [0].Duration ();
	}
}
