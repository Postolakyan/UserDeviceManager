using IDeviceAction = UserDeviceManager.Business.Interfaces.IDeviceAction;

namespace UserDeviceManager.Business.Services;

public class LaptopService : IDeviceAction, ILaptopService
{
    public string PerformeAction()
    {
        return "Open Programm...";
    }
}
