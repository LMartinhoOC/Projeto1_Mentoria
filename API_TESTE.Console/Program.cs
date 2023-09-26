// See https://aka.ms/new-console-template for more information

using API_TESTE.API.Models;
using Newtonsoft.Json;
using System;

Console.WriteLine("Digite um número:");
int numero = Convert.ToInt32(Console.ReadLine());

const string BaseUrl = "https://localhost:7061/api/Soma";

//GET
using (var client = new HttpClient())
{
    client.BaseAddress = new Uri(BaseUrl);

    var resposta = client.GetStringAsync($"?numero={numero}");
    string resultado = resposta.Result.ToString();

    Console.WriteLine(resultado);
}

//POST
using (var client = new HttpClient())
{
    client.BaseAddress = new Uri(BaseUrl);

    string json = JsonConvert.SerializeObject(new { numero = $"{numero}", nome = "Luiz Martinho", idade = 31 });
    var body = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

    var response = await client.PostAsync("", body);

    var result = await response.Content.ReadAsStringAsync();

    PostNumero num = JsonConvert.DeserializeObject<PostNumero>(result);

    Console.WriteLine(num.numero);
    Console.WriteLine(num.nome);
    Console.WriteLine(num.idade);
}


Console.WriteLine("Pressione qualquer tecla para encerrar");
Console.ReadKey();
