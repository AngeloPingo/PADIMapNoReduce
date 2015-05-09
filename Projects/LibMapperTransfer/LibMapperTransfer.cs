using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperTransfer
{
    public interface IMapperTransfer
    {
        bool SendMapper(byte[] code, string className, string splited_file_path);
    }
}