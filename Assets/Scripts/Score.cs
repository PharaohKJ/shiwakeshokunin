using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;

public class Score {

	public int point { set; get;}

	public void Add(int p = 1){
		this.point += p;
	}
}
