using IDeviceAction = UserDeviceManager.Business.Interfaces.IDeviceAction;

namespace UserDeviceManager.Business.Services;

public class PhoneService : IDeviceAction, IPhoneService
{
    public string PerformeAction()
    {
        return "Making Call...";
    }
}
