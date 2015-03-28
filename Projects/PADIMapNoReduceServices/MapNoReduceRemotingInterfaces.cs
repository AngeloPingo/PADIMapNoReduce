using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PADIMapNoReduceServices
{
    public interface IPuppetMaster {
        List<string> RegisterWorker(string NewWorkerPort);
		List<string> RegisterClient(string NewClientPort);
		void SubmitJob(File textFile);
		void JodResult(string result);
		//IList<KeyValuePair<string, string>> Map(string fileLine);
	}

	public interface IClient {
        void SendResults(string result);
	}
	
	public interface IWorker {
		void DoJob(string fileSplited);
	}
}
