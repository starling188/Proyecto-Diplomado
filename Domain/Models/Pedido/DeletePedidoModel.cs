

using System.Text.Json.Serialization;

namespace Domain.Models.Pedido
{
    public class DeletePedidoModel
    {
        [JsonIgnore]
        public int IdPedido { get; set; }
    }
}
