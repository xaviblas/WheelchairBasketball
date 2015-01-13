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

using System.Collections; //ArrayList
using System;
using System.IO;

public class Basquet 
{
	public static void Main() 
	{
		User user = new User("Adria", User.Profile.RESEARCHER, 14);

		ArrayList myPositions = new ArrayList();
		
		myPositions.Add(Player.Positions.GUARD);
		myPositions.Add(Player.Positions.CENTER);

		
		Player p1 = new Player(1, 4);
		Player p2 = new Player(2, 3);
		Player p3 = new Player(3, 2.5f);
		Player p4 = new Player(4, 3);
		Player p5 = new Player(5, 1);
		Player p6 = new Player(6, 3);
		Player p7 = new Player(7, 1);
		Player p8 = new Player(8, 4);
		Player p9 = new Player(9, 4);
		Player p10 = new Player(10, 2);
		Player p11 = new Player(11, 2.5f);
		Player p12 = new Player(12, 1.5f);

		Team team = new Team();
		team.Add(p1);
		team.Add(p2);
		team.Add(p3);
		team.Add(p4);
		team.Add(p5);
		team.Add(p6);
		team.Add(p7);
		team.Add(p8);
		team.Add(p9);
		team.Add(p10);
		team.Add(p11);
		team.Add(p12);

		team.Print(User.Profile.RESEARCHER);
		AlignFind.FindAligns(team.list, user.discapMax, 13);

		Console.WriteLine("\nRemoving player 6 because he kick the referree on the ass\n");
		p6.status = Player.Status.ELIMINATED;
		
		team.Print(User.Profile.RESEARCHER);
		AlignFind.FindAligns(team.list, user.discapMax, 13);
		
		Console.WriteLine("\nPlayer 2 want to rest temporarily\n");
		p2.status = Player.Status.WANNAREST;
	
		team.Print(User.Profile.RESEARCHER);
		AlignFind.FindAligns(team.list, user.discapMax, 13);
		
		Console.WriteLine("\nPlayers 7 and 8 must play\n");
		p7.status = Player.Status.MUSTPLAY;
		p8.status = Player.Status.MUSTPLAY;

		team.Print(User.Profile.RESEARCHER);
		AlignFind.FindAligns(team.list, user.discapMax, 13);


		/*
		Align align = new Align();
		align.Add(p1);
		align.Add(p2);
		Console.WriteLine("\nImprimir aliniacio:");
		align.Print(user.profile);
		*/
	}
}

public class User 
{
	public enum Profile { TRAINER, RESEARCHER }; //TODO: add seleccionador
	public string name;
	public Profile profile;
	public float discapMax; //at different countries can be different. Usually 14

	public User(string name, Profile profile, float discapMax) {
		this.name = name;
		this.profile = profile;
		this.discapMax = discapMax;
	}
}
