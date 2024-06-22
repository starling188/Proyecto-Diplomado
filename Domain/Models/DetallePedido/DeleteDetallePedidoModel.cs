

using System.Text.Json.Serialization;

namespace Domain.Models.DetallePedido
{
    public class DeleteDetallePedidoModel
    {
        [JsonIgnore]
        public int IdDetallePedido { get; set; }

    }
}
