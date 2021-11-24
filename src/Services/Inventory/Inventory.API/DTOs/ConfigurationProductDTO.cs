namespace Inventory.API.DTOs
{
    public class ConfigurationProductDTO
    {
        public string Id { get; set; }
        public string OperatingSystem { get; set; }
        public string RearCamera { get; set; }
        public string FrontCamera { get; set; }
        public string Chips { get; set; }
        public string RAM { get; set; }
        public string InternalMemory { get; set; }
        public string SIM { get; set; }
        public string Batteries { get; set; }
    }
}