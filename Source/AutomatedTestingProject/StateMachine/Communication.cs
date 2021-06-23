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
		#region WAN Type 
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

		private static CommunicationStatus _PPPoEStatus = CommunicationStatus.Idle;
		public CommunicationStatus PPPoEStatus
		{
			get { return _PPPoEStatus; }
			set { _PPPoEStatus = value; }
		}

		private static CommunicationStatus _BridgeStatus = CommunicationStatus.Idle;
		public CommunicationStatus BridgeStatus
		{
			get { return _BridgeStatus; }
			set { _BridgeStatus = value; }
		}

		private static CommunicationStatus _L2TPStatus = CommunicationStatus.Idle;
		public CommunicationStatus L2TPStatus
		{
			get { return _L2TPStatus; }
			set { _L2TPStatus = value; }
		}

		private static CommunicationStatus _PPTPStatus = CommunicationStatus.Idle;
		public CommunicationStatus PPTPStatus
		{
			get { return _PPTPStatus; }
			set { _PPTPStatus = value; }
		}


		#endregion
	}
}
