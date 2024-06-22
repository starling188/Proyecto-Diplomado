

using System.Text.Json.Serialization;

namespace Domain.Models.Cliente
{
    public class UpdateClienteModel
    {
        [JsonIgnore]
        public int IdCliente { get; set; }
        public string? Nombre { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
    }
}
