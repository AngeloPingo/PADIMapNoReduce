using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PADIMapNoReduceServices
{
    public interface IPuppetMaster {
        void RegisterWorker(int id, string worker_url);
		void RegisterClient(string NewClientPort);
        string SubmitJob(string textFile);
        string JodResult(string result);
		//IList<KeyValuePair<string, string>> Map(string fileLine);
	}

	public interface IClient {
        void SendResults(string result);
	}
	
	public interface IWorker {
		void DoJob(string fileSplited);
        void SlowW(int secs);
        void FreezeW();
        void UnFreezeW();
        void FreezeC();
        void UnFreezeC();

	}

    public interface IMapper
    {
        IList<KeyValuePair<string, string>> Map(string fileLine);
    }
}
