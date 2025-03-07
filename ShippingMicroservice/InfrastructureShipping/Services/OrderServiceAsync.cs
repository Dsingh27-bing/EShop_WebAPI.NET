using System.Text;
using System.Text.Json;
using ApplicationCoreShipping.Contracts.Services;
using ApplicationCoreShipping.Model;

namespace InfrastructureShipping.Services;

public class OrderServiceAsync:IOrderServiceAsync
{
    
        private const string ORDERMICROSERVICE_URL = "http://host.docker.internal:3123/api/";
        public async Task<bool> UpdateOrderStatusAsync(int orderId, OrderState status)
        {
            var url = $"{ORDERMICROSERVICE_URL}/UpdateOrderStatus/{orderId}";

            var content = new StringContent(JsonSerializer.Serialize(status), Encoding.UTF8, "application/json");
            using var client = new HttpClient();
            try
            {
                var response = await client.PutAsync(url, content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception e)
            {
                // Log the exception if necessary
                Console.WriteLine("Exception: " + e.Message);
                return false;
            }
        }
    
}