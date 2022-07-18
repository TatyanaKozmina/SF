namespace HomeApi.Data.Queries
{
    /// <summary>
    /// Класс для передачи дополнительных параметров при перезаписи свойств комнаты
    /// </summary>
    public class UpdateRoomQuery
    {
        public int? Area { get; set; }
        public bool? GasConnected { get; set; }
        public int? Voltage { get; set; }

        public UpdateRoomQuery(int? area = null,
                               bool? gasconnected = null,
                               int? voltage = null)
        {
            Area = area;
            GasConnected = gasconnected;
            Voltage = voltage;
        }
    }
}