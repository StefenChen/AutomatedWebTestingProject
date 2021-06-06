using AutomatedTestingProject;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace BasicLIbrary
{
    public class MessageLog
    {
        private static MessageLog singtonMessageLog = null;
        private Mutex logMutex = new Mutex();
        private string logFile;
        private string logPath;
		AutomatedWebTestingForm mainFormBase;
		public static MessageLog SetMessageLog(string logPath, AutomatedWebTestingForm mainFormBase)
        {
            if (singtonMessageLog == null)
            {
				singtonMessageLog = new MessageLog(logPath, mainFormBase);
            }
            return singtonMessageLog;
        }
        private MessageLog(string logPath, AutomatedWebTestingForm mainFormBase)
        {
            DateTime insitialTime = DateTime.Now;
            this.logPath = logPath;
			this.mainFormBase = mainFormBase;
			
			if (!Directory.Exists(logPath))
                Directory.CreateDirectory(logPath);
            logFile = string.Format(@"{0}\{1}.log", logPath, insitialTime.ToString("yyyy-MM-dd_HH-mm-ss"));
        }
        public void WriteLog(Enum category, string msg, string description="")
        {
            Log(DateTime.Now, category, msg, description);
        }
        private void Log(DateTime occurTime,object category, string msg, string description)
        {
            logMutex.WaitOne();
            try
            {
				ShowInGUI(description, msg);

                File.AppendAllText(logFile, String.Format("{0}\t{1}\t{2}\t{3}\t{4}\t\r\n",
                                                      occurTime.ToString("yyyy-MM-dd HH:mm:ss"),
                                                      category.ToString(),
                                                      category.ToString().Length < 8 ? "\t" : "",
                                                      description,
                                                      msg));
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                logMutex.ReleaseMutex();
            }
        }
		private void ShowInGUI(string name, string msg)
		{
			mainFormBase.Invoke(new EventHandler(delegate
			{
				mainFormBase.WriteMsg(null, name, msg);
			}));
		}
    }
}
