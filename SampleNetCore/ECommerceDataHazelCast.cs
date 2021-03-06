using SampleModel;
using Hazelcast;
using Hazelcast.DistributedObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SampleNetCore
{
    public interface IECommerceDataHazelCast
    {
        Task InitializeAsync();
        Task<List<CartItem>> GetCartItemsAsync();
        Task AddCartItemAsync(int productId, string description, decimal unitPrice, int quantity);
        Task ShutdownAsync();
    }

    public class ECommerceDataHazelCast : IECommerceDataHazelCast
    {
        private IHMap<int, CartItem> cartItemsMap;

        public IHazelcastClient hazelcastClient { get; private set; }

        public async Task InitializeAsync()
        {
            StartAsync();

            // Get the Distributed Map from Cluster.
            cartItemsMap = await hazelcastClient.GetMapAsync<int, CartItem>("distributed-cartitem-map");
        }

        private void StartAsync()
        {
            var options = new HazelcastOptions();
            // create an Hazelcast client and connect to a server running on localhost
            hazelcastClient = HazelcastClientFactory.StartNewClientAsync(options).Result;
        }

        public async Task ShutdownAsync()
        {
            // destroy the map
            await hazelcastClient.DestroyAsync(cartItemsMap);

            Debug.WriteLine("ShutdownAsync finished successfully.");
        }

        public async Task<List<CartItem>> GetCartItemsAsync()
        {
            return (await cartItemsMap.GetValuesAsync()).ToList();
        }

        public async Task AddCartItemAsync(int productId, string description, decimal unitPrice, int quantity)
        {
            var newItem = new CartItem(productId, description, unitPrice, quantity);
            await cartItemsMap.PutAsync(newItem.ProductId, newItem);
        }
    }
}
