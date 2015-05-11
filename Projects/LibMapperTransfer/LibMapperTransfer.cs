using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperTransfer
{
    public interface IMapperTransfer
    {
        bool SendMapper(byte[] code, string className, int num_job, string client_url);
    }
}