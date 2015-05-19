using System;
using System.Collections;
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
        string JobResult(string result);
        Hashtable getWorkers();
	}	

    public interface IMapper
    {
        IList<KeyValuePair<string, string>> Map(string fileLine);
    }

    public interface IMapperTransfer
    {
        bool SendMapper(byte[] code, string className, int num_job, string client_url);
    }

    public interface IClient
    {
        void SendSplitResults(IList<KeyValuePair<string, string>> result, string file_name);
        string GetJobById(int job_id);
        void status();
    }

    public interface IWorker : IMapperTransfer
    {
        void SlowW(int secs);
        void FreezeW();
        void UnFreezeW();
        void RegisterJobTracker(int id, string url_JobTracker);
        string getJobTrackerUrl();
        Hashtable getJobTrackerUrls();
        void status();
    }
    public interface IJobTracker
    {
        bool registerNewWorker(int worker_id, string worker_url);
        void spreadJobs(byte[] code, string imap_name_class, int num_jobs, string client_url);
        Hashtable sendWorkers();
        void getWorkers(string job_tracker_url);
        void FreezeC();
        void UnFreezeC();

    }

}
