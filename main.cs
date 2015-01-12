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

		Player p1 = new Player(
				1,3,"soc el 1 de discap 3",
				Player.Positions.GUARD,
				myPositions
				);
		//Console.WriteLine("Imprimir 1er jug");
		//pepe.Print(user.profile);
		

		Player p2 = new Player(
				2,4,"soc el 2 de discap 4",
				Player.Positions.CENTER,
				myPositions
				);
		//Console.WriteLine("Imprimir 2n jug");
		//marta.Print(user.profile);


		Player p3 = new Player(3, 1   );//, "3 discap:1", Player.Positions.CENTER, myPositions);
		Player p4 = new Player(4, 4.5f);//, "4 discap:4.5", Player.Positions.CENTER, myPositions);
		Player p5 = new Player(5, 3   );//, "5 discap:3", Player.Positions.CENTER, myPositions);
		Player p6 = new Player(6, 3.5f);//, "6 discap:3.5", Player.Positions.CENTER, myPositions);
		Player p7 = new Player(7, 1.5f);//, "7 discap:1.5", Player.Positions.CENTER, myPositions);

		Team team = new Team();
		team.Add(p1);
		team.Add(p2);
		team.Add(p3);
		team.Add(p4);
		team.Add(p5);
		team.Add(p6);
		team.Add(p7);

		team.Print(User.Profile.RESEARCHER);
		team.FindAligns(user.discapMax);

		Console.WriteLine("\nRemoving player 6 because he kick the referree on the ass\n");
		p6.status = Player.Status.ELIMINATED;
		
		team.Print(User.Profile.RESEARCHER);
		team.FindAligns(user.discapMax);
		
		Console.WriteLine("\nPlayer 2 want to rest temporarily\n");
		p2.status = Player.Status.WANNAREST;
	
		team.Print(User.Profile.RESEARCHER);
		team.FindAligns(user.discapMax);




/*
		Align align = new Align();
		align.Add(p1);
		align.Add(p2);
		Console.WriteLine("\nImprimir aliniacio:");
		align.Print(user.profile);

		Console.WriteLine("Total Discap:" + align.DiscapTotal().ToString());

		*/

		/*
		Console.WriteLine(String.Format("{0,-10:0.#}", 123.4567) + "hola");
		Console.WriteLine(String.Format("{0,-10:0.#}", 123) + "hola");
		
		Console.WriteLine(String.Format("{0,10:0.#}", 123.4567) + "hola");
		Console.WriteLine(String.Format("{0,10:0.#}", 123) + "hola");
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
