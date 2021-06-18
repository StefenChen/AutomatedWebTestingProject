using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachine
{
	public enum CommunicationStatus
	{
		Idle = 0,
		Busy,
		Done,
		Error,
	}
	public class Communication
	{
		private static CommunicationStatus _DHCPStatus = CommunicationStatus.Idle;
		public CommunicationStatus DHCPStatus
		{
			get { return _DHCPStatus; }
			set { _DHCPStatus = value; }
		}
		private static CommunicationStatus _StaticIPStatus = CommunicationStatus.Idle;
		public CommunicationStatus StaticIPStatus
		{
			get { return _StaticIPStatus; }
			set { _StaticIPStatus = value; }
		}
	}
}
