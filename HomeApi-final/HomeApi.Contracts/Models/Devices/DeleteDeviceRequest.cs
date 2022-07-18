namespace HomeApi.Contracts.Models.Devices
{
    /// <summary>
    /// Запрос для удаления подключенного устройства
    /// </summary>
    public class DeleteDeviceRequest
    {
        public string Location { get; set; }
        public string Name { get; set; }
    }
}
