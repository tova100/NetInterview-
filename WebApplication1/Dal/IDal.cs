
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Dal;

public interface IDal
{
    public Task<ListModel> GetNewsList();
    //פונקציה לשליפת נתונים מהמטמון עפ כותרת שנשלחה אליה 
    public NewsModel TryGetCachedNewsList(string title);
}
