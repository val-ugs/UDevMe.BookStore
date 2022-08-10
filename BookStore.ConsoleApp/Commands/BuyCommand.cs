using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BookStore.ConsoleApp.Commands
{
    [Verb("buy", HelpText = "buy a book")]
    public class BuyCommand : ICommand
    {
        [Option("id", Required = true, HelpText = "book id")]
        public int Id { get; set; }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object? parameter)
        {
            Console.WriteLine(BuyAsync(Id).Result);
        }

        /// <summary>
        /// Buy a book
        /// </summary>
        /// <param name="id"> book id </param>
        /// <returns> result </returns>
        private async Task<string> BuyAsync(int id)
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("id", id.ToString())
            });
            
            HttpResponseMessage response = await HttpClientSample.HttpClient.PostAsync("books", content);

            if (response.IsSuccessStatusCode)
                return "The book has been purchased. Congratulations";

            return response.Content.ReadAsStringAsync().Result;
        }
    }
}
