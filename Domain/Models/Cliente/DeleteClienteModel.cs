

using System.Text.Json.Serialization;

namespace Domain.Models.Cliente
{
    public class DeleteClienteModel
    {
        [JsonIgnore]
        public int IdCliente { get; set; }
       
    }
}
