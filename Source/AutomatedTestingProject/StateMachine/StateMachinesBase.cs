using BasicLIbrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebLibrary;
using WindowsControl;

namespace StateMachine
{
	public enum MainState
	{
		stop,
		Auto,
		Pause,
		Error,
	}
	public class StateMachinesBase
	{
		public MainState mainState;
		protected string Name = null;
		private System.Timers.Timer timer = null; //Timer
		private int errorCounter = 0; 
		private bool stop = false; //State Flag
		protected Communication status;
		protected virtual object AutoState { get; set; }
		protected virtual object ErrorState { get; set; }
		protected WebAccountControl webAccount = null;
		protected WebFunctionControl webFunction = null;
		protected WebSystemControl webSystem = null;
		protected WifiControl wifi = null;
		protected NetworkAdapterControl networkAdapter = null;
		protected BrowserControl browser = null;
		protected AccessConfig config = null;
		protected MessageLog msgLog = null;
		public StateMachinesBase(string Name, CommonBase basicTool, BrowserControl browser, WebAccountControl webAccount, WebFunctionControl webFunction,
								 WebSystemControl webSystem, WifiControl wifi, NetworkAdapterControl networkAdapter, Communication status)
		{
			
			this.Name = Name;
			this.browser = browser;
			this.webAccount = webAccount;
			this.webFunction = webFunction;
			this.webSystem = webSystem;
			this.wifi = wifi;
			this.networkAdapter = networkAdapter;
			config = basicTool.accessConfig;
			msgLog = basicTool.messageLog;
			this.status = status;
			//Initial
			stop = true;
			timer = new System.Timers.Timer(1500);
			timer.AutoReset = false;
			timer.Stop();
			timer.Elapsed += new System.Timers.ElapsedEventHandler(ThreadTask);
			mainState = MainState.stop;
		}
		public virtual CommunicationStatus communicationStatus
		{
			get { return CommunicationStatus.Idle; }
			set { }
		}

		#region for Context use 
		/// <summary>
		/// Prepare for the action before start state machine thread
		/// </summary>
		/// <returns></returns>
		public bool IsReady(ref string errStr)
		{
			if (browser.OpenNewWeb(config.URL, 5))
			{
				Thread.Sleep(1000);
				switch (webAccount.CheckLoginStatus())
				{
					case 0:
						if (!webAccount.SettingPwd())
						{
							msgLog.WriteLog(Category.StateMachineBase, "IsReady() is failed, because SettingPwd() error!", Name);
							return false;
						}
						else if (!LoginNPassWarning())
						{
							return false;
						}
						break;
					case 1:
						if (!LoginNPassWarning())
						{
							return false;
						}
						break;
					case 2:
						break;
					default:
						msgLog.WriteLog(Category.StateMachineBase, "IsReady() is failed, because CheckLoginStatus() error!", Name);
						return false;
				}
			}else
				return false;
			return true;
		}
		public void FreedAll()
		{
			timer = null;
			webAccount = null;
			webFunction = null;
			webSystem = null;
			wifi = null;
			networkAdapter = null;
			browser = null;
			config = null;
			msgLog = null;
		}
		public void Start()
		{
			stop = false;
			mainState = MainState.Auto;
			communicationStatus = CommunicationStatus.Busy;
			timer.Start();
		}
		#endregion

		#region for children use
		protected virtual bool VariableSetting()
		{
			return true;
		}
		/// <summary>
		/// Customize auto sequence
		/// </summary>
		protected virtual void AutoSequence()
		{ }
		/// <summary>
		/// Handler when the error occurred
		/// </summary>
		protected virtual void ErrorHandle()
		{ }
		/// <summary>
		/// Write Log when auto mode.
		/// </summary>
		protected virtual void WriteLogWhenAuto(object state, string optionalString) { }
		/// <summary>
		/// Get error information through establish a link between specified error state and error information 
		/// that be searched from error table file (This function name not intuitive)
		/// </summary>
		/// <param name="errorState"> Enter to specified error state </param>
		/// <param name="errInfo"> Error information be saerched form table </param>
		/// <param name="optionalString"> Optional information </param>
		protected virtual void WriteLogWhenError(object errorState, string optionalString)
		{
		}
		/// <summary>
		/// Go back to auto state from error state and sequence state be specified to go
		/// </summary>
		/// <param name="backState"> Specified go back sequence state </param>
		protected void GoBackToAutoFromError(object backState)
		{
			AutoState = backState;
			GoBackToAutoFromError();
		}
		/// <summary>
		/// Set main state machine to error state and specified error state before show error message windows
		/// </summary>
		/// <param name="errorState"> Go to the specified error status </param>
		/// <param name="optionalString"> Optional information </param>
		protected void GoToErrorState(object errorState, string optionalString = "")
		{
			mainState = MainState.Error;
			ErrorState = errorState;
			WriteLogWhenError(errorState, optionalString);
		}
		/// <summary>
		/// Go to next specified state in this state machine thread
		/// </summary>
		/// <param name="state"> Speicfied state to work </param>
		/// <param name="optionalString"> Optional information to log </param>
		protected void GoToNewAutoState(object state, string optionalString = "")
		{
			AutoState = state;
			errorCounter = 0;
			WriteLogWhenAuto(state, optionalString);
		}
		/// <summary>
		/// Go back to auto state from error state and sequence keep the original state
		/// </summary>
		protected void GoBackToAutoFromError()
		{
			mainState = MainState.Auto;
		}

		protected void Stop()
		{
			stop = true;
		}
		#endregion

		#region only owner can use them
		private bool LoginNPassWarning()
		{
			if (!webAccount.Login())
			{
				msgLog.WriteLog(Category.StateMachineBase, "IsReady() is failed, because Login() error!", Name);
				return false;
			}
			else
			{
				Thread.Sleep(200);
				webAccount.LoginWarning();
				Thread.Sleep(100);
				if (webAccount.CheckLoginStatus() != 2)
				{
					msgLog.WriteLog(Category.StateMachineBase, "IsReady() is failed, because CheckLoginStatus() still error!", Name);
					return false;
				}
				return true;
			}
		}
		/// <summary>
		/// Main state machine
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Task()
		{
			try
			{
				switch (mainState)
				{
					case MainState.stop:
						//Do nothing
						break;
					case MainState.Auto:
						//Auto-Processing
						AutoSequence();
						//Go To Error Hanle
						if (mainState == MainState.Error)
						{
							errorCounter++;
						}
						break;
					case MainState.Pause:
						Thread.Sleep(1000);
						break;
					case MainState.Error:
						ErrorHandle();
						//Error Solved, Back to Auto
						if (mainState == MainState.Auto)
						{
							
						}
						break;
				}
				if (errorCounter > 5)
					communicationStatus = CommunicationStatus.Error;
				//Check if stop
				else if ((!stop) && timer != null)
				{
					timer.Start();
				}
			}
			catch (Exception ex)
			{
				msgLog.WriteLog(Category.StateMachineBase, ex.ToString());
			}
		}
		private void ThreadTask(object sender, System.Timers.ElapsedEventArgs e)
		{
			new Thread(() => { Task(); }).Start();
		}
		#endregion
	}
}
