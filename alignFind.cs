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

public static class AlignFind 
{

	private static bool canAlign(List<Player> list) 
	{
		int ok = 0;
		foreach(Player p in list)
			if(p.status == Player.Status.CANPLAY)
				ok ++;

		if(ok >= 5)
			return true;
		else
			return false;
	}

	/*
	 * list is double sorted
	 *
	 * main sort is sortByAlignDiscapTotal: this will show aligns from 14 to lower values
	 *
	 * second criteria comes from sort: sortByPlayerDiscapNum
	 * this will make the same rated aligns, be sorted using first the players with more DiscapNum
	 */

	private static List<Player> sortByPlayerDiscapNum(List<Player> list) 
	{
		//http://stackoverflow.com/questions/3309188/how-to-sort-a-listt-by-a-property-in-the-object
		return list.OrderByDescending(o=>o.DiscapNum).ToList();
	}
		
	private static List<Align> sortByAlignDiscapTotal(List<Align> alignsPossible) 
	{
		return alignsPossible.OrderByDescending(o=>o.discapTotal).ToList();
	}


	//discapMax: max value of total discap
	//discapMin: min value of total discap
	public static void FindAligns(List<Player> list, float discapMax, float discapMin) 
	{
		if(! canAlign(list)) {
			Console.WriteLine("Team too short. Need at least five members that can play.");
			return;
		}

		list = sortByPlayerDiscapNum(list);

		List<Align> alignsPossible = new List<Align>();

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

							if(align.IsValid(discapMax, discapMin)) //check align is valid and chech that all players CANPLAY
								alignsPossible.Add(align);
						}

		printAligns(alignsPossible);
	}

	private static void printAligns(List<Align> alignsPossible) 
	{
		//sort aligns by discapTotal
		alignsPossible = sortByAlignDiscapTotal(alignsPossible);
		
		Console.WriteLine("Possible Aligns:");
		
		int count = 1;
		foreach(Align align in alignsPossible) {
			Console.Write(String.Format("{0,3:0.#}", count ++) + ")  ");
			align.Print(User.Profile.RESEARCHER);
		}
	}
}
