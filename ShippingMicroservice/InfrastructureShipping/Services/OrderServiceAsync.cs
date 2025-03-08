using System.Text;
using System.Text.Json;
using ApplicationCoreShipping.Contracts.Services;
using ApplicationCoreShipping.Model;

namespace InfrastructureShipping.Services;

public class OrderServiceAsync:IOrderServiceAsync
{
    
        private const string ORDERMICROSERVICE_URL = "http://host.docker.internal:3123/api";
        
        // http://localhost:3123/api/Order/UpdateOrderStatus?orderId=2&status=1 , url from the frontend part after execution
        public async Task<bool> UpdateOrderStatusAsync(int orderId, OrderState status)
        {
            
            // Map OrderState from Shipping microservice to OrderStatus value in Order microservice
            int orderStatusValue;
    
            // Make sure these mappings match between your two enum types
            switch (status)
            {
                case OrderState.Pending:
                    orderStatusValue = 0; // Must match OrderStatus.Pending value
                    break;
                case OrderState.Processing:
                    orderStatusValue = 1; // Must match OrderStatus.Processing value
                    break;
                case OrderState.Shipped:
                    orderStatusValue = 2; // Must match OrderStatus.Shipped value
                    break;
                case OrderState.Delivered:
                    orderStatusValue = 3; // Must match OrderStatus.Delivered value
                    break;
                case OrderState.Completed:
                    orderStatusValue = 4; // Must match OrderStatus.Completed value
                    break;
                case OrderState.Canceled:
                    orderStatusValue = 5; // Must match OrderStatus.Canceled value
                    break;
                case OrderState.Returned:
                    orderStatusValue = 6; // Must match OrderStatus.Returned value
                    break;
                default:
                    orderStatusValue = 0;
                    break;
            }
            
            var url = $"{ORDERMICROSERVICE_URL}/Order/UpdateOrderStatus?orderId={orderId}&status={orderStatusValue}";

            using var client = new HttpClient();
            try
            {
            
                var response = await client.PutAsync(url, null);
                return response.IsSuccessStatusCode;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return false;
            }
            
        }
    
}