using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace postnordTracking
{
	public class Search
	{
		public void start()
		{
			//fungerande kolli id 91997792724SE
			Console.WriteLine("********************************************************");
			Console.WriteLine("                PostNord Kolli sök");
			Console.WriteLine("********************************************************");

			bool loop = true;
			do
			{
				Console.WriteLine("1. Sök med kolli id");
				Console.WriteLine("2. Avsluta");
				int menu = int.Parse(Console.ReadLine());
				switch (menu)
				{

					case 1:
						

						Console.Clear();
						loop = false;
						find();
					break;

					case 2:
						

						loop = false;
						break;

					default:
						Console.WriteLine("Oj något gick fel");

						continue;


				}
			} while (loop);
		}

		public void find()
		{
			//fungerande kolli id 91997792724SE
			Console.WriteLine("********************************************************");
			Console.WriteLine("                PostNord Kolli sök");
			Console.WriteLine("********************************************************");
			Console.Write("\nSkriv in Kolli id: ");
			string kolliId = Console.ReadLine();
			TrackingData tData = new TrackingData();
			tData = Tracking.identyfier(kolliId);
			Console.WriteLine("\n--------------------------------------------------------");
			Console.WriteLine("Avsändare:\n{0}\n{1} {2}\n{3}\n", tData.senderName,  
			                  tData.receiverPostCode, tData.senderCity, tData.senderCountry);
			Console.WriteLine("Tjänst:\n** {0} **", tData.serviceName);
			Console.WriteLine("Status:\n** {0} **", tData.ShipmentStatus);
			Console.WriteLine("--------------------------------------------------------");


			bool loop = true;
			do
			{
				Console.WriteLine("1. Se historik för det här kollit");
				Console.WriteLine("2. Huvud meny");
				int menu = int.Parse(Console.ReadLine());
				switch (menu)
				{
					case 1:
						Console.Clear();
						loop = false;
						dispalyHistory(kolliId);
						break;
					
					case 2:
						Console.Clear();
						loop = false;
						start();
						break;

						default:
						Console.WriteLine("Oj något gick fel");
						Console.Clear();
						continue;
				}

			} while (loop);



		}
			
		public void dispalyHistory(string kolliId)
		{
			Console.WriteLine("********************************************************");
			Console.WriteLine("                PostNord Kolli sök");
			Console.WriteLine("********************************************************");
				List<TrackingEvents> events = new List<TrackingEvents>();
			events = Tracking.tEvents(kolliId);
			Console.WriteLine("\nHistorik");
			Console.WriteLine("--------------------------------------------------------");
			foreach (TrackingEvents history in events)
			{
				Console.WriteLine(history);
				Console.WriteLine("--------------------------------------------------------");

			}

			bool loop = true;
			do
			{
				Console.WriteLine("1. Huvud meny");
				Console.WriteLine("2. Avsluta");
				 int menu = int.Parse(Console.ReadLine());
				switch (menu)
				{
					case 1:

						Console.Clear();
						loop = false;
						start();
						break;
					
					case 2:

						Console.Clear();
						loop = false;
						break;

						default:
						Console.WriteLine("Oj något gick fel");
						Console.Clear();
						continue;
				}

			} while (loop);

		}
	}
}

