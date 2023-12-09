using DataAccess.Entities;


namespace DataAccess.Interfaces
{
    public  interface IDManagementRepository
    {
       Document AddDocument(Document doc);
       Document GetDocument(int id);
       void DeleteDocument(int id);

       Document UpdateDocument(Document doc);
    }
}
