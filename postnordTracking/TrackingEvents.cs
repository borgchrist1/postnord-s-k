using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace postnordTracking
{
	class TrackingEvents
	{
		public string eventTime { get; set; }
		public string eventDiscription { get; set; }
		public string locationName { get; set; }

		public override string ToString()
		{
			return string.Format("{0}\n{1}\n{2}", eventTime.Replace("T", " ").Remove(16, 3), eventDiscription, locationName);
		}

	}
}
