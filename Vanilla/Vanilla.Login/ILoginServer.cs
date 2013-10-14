namespace Vanilla.Login
{
    using System.ServiceModel;

    [ServiceContract]
    public interface ILoginServer
    {
        [OperationContract]
        void RegisterRealm(string name);
    }
}
