namespace Movie.Data.Engine.Interface
{
    using System.Data;
    public interface ISqlConnect
    {
        IDbConnection GetDbConnection();
    }
}
