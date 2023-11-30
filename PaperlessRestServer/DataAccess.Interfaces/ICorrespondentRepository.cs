
using DataAccess.Entities;


namespace DataAccess.Interfaces
{
    public interface ICorrespondentRepository
    {
        Correspondent GetCorrespondent(long id);
        IEnumerable<Correspondent> GetAllCorrespondents();
        void  AddCorrespondent(Correspondent correspondent);
        Correspondent UpdateCorrespondent(Correspondent correspondent);
        void DeleteCorrespondent(long id);
    }
}