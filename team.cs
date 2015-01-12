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
using System.Collections.Generic; //List<T>

public class Team 
{
	public List<Player> list;

	public Team() {
		list = new List<Player>();
	}

	public void Add(Player p) {
		list.Add(p);
	}
	
	public void Remove(Player p) { 
		list.Remove(p);
	}


	public void Print(User.Profile profile) 
	{
		Console.WriteLine("Team:");

		string sepNow = "";
		string sep = "";
		if(profile == User.Profile.TRAINER)
			sep = "\n";
		else if(profile == User.Profile.RESEARCHER)
			sep = "\t";

		foreach(Player p in list) {
			Console.Write(sepNow);
		        p.Print(profile);
			sepNow = sep;
		}
		Console.WriteLine("\n");
	}
}
