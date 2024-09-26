using UserDeviceManager.Business.Interfaces;

namespace UserDeviceManager.Business.Services;

public class LaptopService : IDeviceAction, ILaptopService
{
    public string PerformeAction()
    {
        return "Open Programm...";
    }
}
