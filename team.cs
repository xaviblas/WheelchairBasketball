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
using System.Linq; //sort list

public class Team 
{
	private List<Player> list;

	public Team() {
		list = new List<Player>();
	}

	public void Add(Player p) {
		list.Add(p);
	}
	
	public void Remove(Player p) { 
		list.Remove(p);
	}

	private bool canAlign() {
		int ok = 0;
		foreach(Player p in list)
			if(p.status == Player.Status.CANPLAY)
				ok ++;
		
		if(ok >= 5)
			return true;
		else
			return false;
	}

	private void sortList() {
		//sort the list. If do it by DiscapNum then the FindAligns list will be also sorted by DiscapTotal

		//http://stackoverflow.com/questions/3309188/how-to-sort-a-listt-by-a-property-in-the-object
		list = list.OrderByDescending(o=>o.DiscapNum).ToList();
		
	}

	public Align alignNow;
	public List<Align> alignsPossible;

	//without means: if you want to change one player temporarily, but you don't want to delete it
	//just have the aligns without that player
	public void FindAligns(float discapMax) 
	{
		if(! canAlign()) {
			Console.WriteLine("Team too short. Need at least five members that can play.");
			return;
		}

		sortList();

		alignsPossible = new List<Align>();

		Console.WriteLine("Possible Aligns:");
		int members = 5;

		//as aligns have 5 members it's easier to write 5 'for' instead of do a nice recursivity
		for(int i = 0 ; i <= (list.Count - members); i++)
			for(int j = i+1 ; j <= (list.Count - (members -1)); j++)
				for(int k = j+1 ; k <= (list.Count - (members -2)); k++)
					for(int l = k+1 ; l <= (list.Count - (members -3)); l++)
						for(int m = l+1 ; m <= (list.Count - (members -4)); m++) {
							Align align = new Align(new List<Player> {
									(Player) list[i],
									(Player) list[j],
									(Player) list[k],
									(Player) list[l],
									(Player) list[m]
									} );

							//if(align.DiscapTotal() <= discapMax) {
							if(align.IsValid(discapMax)) { //check align is valid and chech that all players CANPLAY
								align.Print(User.Profile.RESEARCHER);
								alignsPossible.Add(align);
							}
						}
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
