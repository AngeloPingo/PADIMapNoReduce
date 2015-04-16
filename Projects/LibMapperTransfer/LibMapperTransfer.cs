using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperTransfer
{
    public interface IMapperTransfer
    {
        IList<KeyValuePair<string, string>> SendMapper(byte[] code, string className, string splited_file_path);
    }
}