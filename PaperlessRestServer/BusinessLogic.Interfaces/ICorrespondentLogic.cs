using BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public  interface ICorrespondentLogic
    {
        Correspondent CreateCorrespondent(Correspondent newcorrespondent);
        bool DeleteCorrespondent(int id);
        Correspondent GetCorrespondent(int id); 
        Correspondent UpdateCorrespondent(Correspondent correspondent);

    }
}
