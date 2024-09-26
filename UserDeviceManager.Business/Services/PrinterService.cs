using IDeviceAction = UserDeviceManager.Business.Interfaces.IDeviceAction;

namespace UserDeviceManager.Business.Services;

public class PrinterService : IDeviceAction, IPrinterService
{
    public string PerformeAction()
    {
        return "Printing...";
    }
}
