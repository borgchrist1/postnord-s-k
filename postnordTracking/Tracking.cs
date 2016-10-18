using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace postnordTracking
{
	class Tracking
	{
		static string apiKey = "8d36fb960e151e38c6ca8345315ae848";

		public static TrackingData identyfier(string identyfier)
		{
			TrackingData tData = new TrackingData();
			XmlDocument xmlTrackingData = new XmlDocument();

				xmlTrackingData.Load(string.Format("https://api2.postnord.com/rest/shipment/v1/trackandtrace/findByIdentifier.xml?id=" + identyfier + "&locale=sv&apikey=" + apiKey));


		
				try
				{
					tData.senderName = xmlTrackingData.SelectSingleNode("TrackingInformationResponse/shipments/Shipment/consignor/name").InnerText;
				}
				catch
				{
					tData.senderName = "Okänd";

				}

				if (tData.senderName == "Okänd")
				{

					tData.receiverCity = xmlTrackingData.SelectSingleNode("TrackingInformationResponse/shipments/Shipment/consignee/address/city").InnerText;
					tData.receiverPostCode = xmlTrackingData.SelectSingleNode("TrackingInformationResponse/shipments/Shipment/consignee/address/postCode").InnerText;
					tData.receiverCountry = xmlTrackingData.SelectSingleNode("TrackingInformationResponse/shipments/Shipment/consignee/address/country").InnerText;
				}


				else {
					tData.senderCity = xmlTrackingData.SelectSingleNode("TrackingInformationResponse/shipments/Shipment/consignor/address/city").InnerText;
					tData.senderPostCode = xmlTrackingData.SelectSingleNode("TrackingInformationResponse/shipments/Shipment/consignor/address/postCode").InnerText;
					tData.senderCountry = xmlTrackingData.SelectSingleNode("TrackingInformationResponse/shipments/Shipment/consignor/address/country").InnerText;
					tData.receiverCity = xmlTrackingData.SelectSingleNode("TrackingInformationResponse/shipments/Shipment/consignee/address/city").InnerText;
					tData.receiverPostCode = xmlTrackingData.SelectSingleNode("TrackingInformationResponse/shipments/Shipment/consignee/address/postCode").InnerText;
					tData.receiverCountry = xmlTrackingData.SelectSingleNode("TrackingInformationResponse/shipments/Shipment/consignee/address/country").InnerText;
				}
				tData.serviceName = xmlTrackingData.SelectSingleNode("TrackingInformationResponse/shipments/Shipment/service/name").InnerText;
				tData.ShipmentStatus = xmlTrackingData.SelectSingleNode("TrackingInformationResponse/shipments/Shipment/statusText/header").InnerText;

			return tData;
		}

		public static List<TrackingEvents> tEvents(string identyfier)
		{
			List<TrackingEvents> trakingEvents = new List<TrackingEvents>();
			XmlDocument xmlTrackingData = new XmlDocument();
			xmlTrackingData.Load(string.Format("https://api2.postnord.com/rest/shipment/v1/trackandtrace/findByIdentifier.xml?id=" + identyfier + "&locale=sv&apikey=" + apiKey));
			foreach (XmlNode node in xmlTrackingData.SelectNodes("/TrackingInformationResponse/shipments/Shipment/items/Item/events/TrackingEvent"))

			{
			TrackingEvents tEvent = new TrackingEvents();
				tEvent.eventTime = node.SelectSingleNode("eventTime").InnerText;
				tEvent.locationName = node.SelectSingleNode("location/name").InnerText;

				  tEvent.eventDiscription = node.SelectSingleNode("eventDescription").InnerText;
				trakingEvents.Add(tEvent);
			}
			return trakingEvents;
		}







	}
}

