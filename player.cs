/*
 * Copyright 2015 Xavier de Blas  - xaviblas AT gmail DOT com
 *
 *
 * This file is part of WheelchairBasketball. 
 * WheelchairBasketball is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, version 3.
 *
 * WheelchairBasketball is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with WheelchairBasketball.  If not, see <http://www.gnu.org/licenses/>.
 *
*/

using System;
using System.Collections; //ArrayList

public class Player {
	public enum Positions { UNDEF, GUARD, CENTER, FORWARD, OTHER };

	//private string team; //Barcelona. Can be null. Needed by National Coach
	//private string teamCountry; //Spain. Can be null.
	private int numShirt;
	private float discapNum; //1 - 4.5
	private string fullName; //cannot be null
	private Positions positionCurrent;
	private ArrayList positionsPossible;
	//private DateTime dateBorn;
	//private int seasonStart; //1997-1998; will be recorded as 1997
	//private bool gender; //1: male; 0: female
	
	public enum Status { CANPLAY, WANNAREST, ELIMINATED };
	public Status status; //used by trainer during the match

	public Player(int numShirt, float discapNum, string fullName, 
			Positions positionCurrent, ArrayList positionsPossible
			//DateTime dateBorn, int seasonStart, bool gender
			)
	{
		this.numShirt = numShirt;
		this.discapNum = discapNum;
		this.fullName = fullName;
		this.positionCurrent =positionCurrent;
		this.positionsPossible = positionsPossible;
		//this.dateBorn = dateBorn;
		//this.seasonStart = seasonStart;
		//this.gender = gender;
		
		//default CANPLAY
		this.status = Status.CANPLAY;
	}
	
	public Player(int numShirt, float discapNum) {
		this.numShirt = numShirt;
		this.discapNum = discapNum;
		
		//default CANPLAY
		this.status = Status.CANPLAY;
	}

	public void Print(User.Profile profile) 
	{
		/*
		if(profile == User.Profile.TRAINER)
			return numShirt.ToString() + ") " + 
				discapNum.ToString() + 
				" [" + DiscapClasse() + "] " +  
				fullName + " - " + positionCurrent + " " +
				status.ToString() + "\n";
				//TODO DateTime dateBorn, int seasonStart, bool gender;
		else if(profile == User.Profile.RESEARCHER)
		*/
			//return discapNum.ToString();
			//return numShirt.ToString() + "_" + string.Format("{0,-3:0.#}", discapNum);
		
			Console.Write(numShirt.ToString());

			Console.ForegroundColor = ConsoleColor.DarkGray;
		       	Console.Write("[" + discapNum.ToString() + "]");
			Console.ForegroundColor = ConsoleColor.White;

			Console.ForegroundColor = getColorFromStatus();	
			Console.Write(statusChar());
			Console.ForegroundColor = ConsoleColor.White;
		//else
		//	return "";
	}
	
	public string DiscapClasse () {
		if (discapNum <= 1.5)
			return "I";
		else if (discapNum >= 2 && discapNum <= 2.5)
			return "II";
		else if (discapNum >= 3 && discapNum <= 3.5)
			return "III";
		else // (discapNum >= 4)
			return "IV";
	}

	private char statusChar() {
		if(status == Status.CANPLAY)
			return ' ';
		else if(status == Status.WANNAREST)
			return 'R';
		else //(status == Status.ELIMINATED)
			return 'E';
	}
			
	private ConsoleColor getColorFromStatus() {
		if(status == Status.CANPLAY)
			return ConsoleColor.White;
		else if(status == Status.WANNAREST)
			return ConsoleColor.Yellow;
		else //(status == Status.ELIMINATED)
			return ConsoleColor.Red;
	}

	public int NumShirt {
		get { return numShirt; }
	}
	public float DiscapNum {
		get { return discapNum; }
	}
	
}
