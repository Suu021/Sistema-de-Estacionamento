using App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using static App.Models.Enums;

namespace App.Controllers;
class GaragemController : GaragemContext
{
    protected int capacidade = 50;
    protected double precoHora = 5.00d;    
    public bool disponibilidade;

    public bool AdicionarVeiculo(Veiculo veiculo, Cliente cliente)
    {
        VerificarDisponibilidade();
        if (!disponibilidade) {
            Console.WriteLine("Não há vagas disponíveis nesse momento.");
            Console.ReadLine();
            return false;
        }
        List<Veiculo> lVeiculos;
        using var context = new GaragemContext();

        using(context)
        {
            //pega os veiculos no db
            lVeiculos = [.. from est in context.Estacionamentos
                            join vei in context.Veiculos on est.IdVeiculo equals vei.ID
                            where vei.Placa.Equals(veiculo.Placa)
                            where est.StatusEstacionamento.Equals(Status.Aberto)
                            select vei
                            ];
            
       
            if (lVeiculos.Count != 0)
            {
                Console.WriteLine("Este veículo já está na garagem.");
                Console.ReadLine();
                return false;
            }
            else
            {
                Estacionamento estacionamento = new()
                {
                    ID = Guid.NewGuid(),
                    HoraInicio = DateTime.Today,
                    IdCliente = cliente.ID,
                    IdVeiculo = veiculo.ID,
                    StatusEstacionamento = Status.Aberto
                };

                // Adiciona a entidade ao Data Context            
                context.Estacionamentos.Add(estacionamento);

                // Persiste as mudancas
                context.SaveChanges();
            }
        }

        Console.WriteLine("O veículo foi estacionado.");
        Console.ReadLine();
        return true;        
    }

    public bool RemoverVeiculo(Veiculo veiculo)
    {        
        if (veiculo == null) {
            Console.WriteLine("Não pode levar um veículo que nem está cadastrado.");
            Console.ReadLine();
            return false;
        }
       
        using var context = new GaragemContext();

        Estacionamento estacionamento = 
        (
            from est in context.Estacionamentos
            where est.IdVeiculo.Equals(veiculo.ID)  
            where est.StatusEstacionamento.Equals(Status.Aberto)
            select est
        ).ToList()[0];

        if(estacionamento == null){
            Console.WriteLine("Não pode levar um veículo que não está estacionado.");
            Console.ReadLine();
            return false;
        }
                
        estacionamento.HoraFim = DateTime.Now;

        estacionamento.ValorCobrado = estacionamento.HoraFim.Subtract(estacionamento.HoraInicio).TotalSeconds / 3600 * precoHora;
        Console.WriteLine($"Você deve pagar R${estacionamento.ValorCobrado.ToString("0.00").Replace(".", ",")} pelo estacionamento.");
        AtualizarCaixa(estacionamento.ID, estacionamento.ValorCobrado);

        estacionamento.StatusEstacionamento = Status.Finalizado;

        //salva a alteração no bd
        context.Estacionamentos.Update(estacionamento);
        context.SaveChanges();

        Console.WriteLine("Veículo levado.");
        Console.ReadLine();
        return true;
    }   

    public void ExibirListaVeiculos()
    {
        using var context = new GaragemContext();

        //pega os veiculos no db
        var veiculos = (
                            from est in context.Estacionamentos
                            join vei in context.Veiculos on est.IdVeiculo equals vei.ID
                            where est.StatusEstacionamento.Equals(Status.Aberto)
                            select vei
                        ).ToList();

        foreach (Veiculo vei in veiculos)
            Console.WriteLine("-----------------------------\n" +
                $"Modelo: {vei.Modelo}\n" +
                $"Placa: {vei.Placa}\n");
                //$"Tempo : {vei.TempoEstacionamento} min\n");
    }

     private void AtualizarCaixa(Guid idEst, double valor)
    {
        using var context = new GaragemContext();

        HistoricoCaixa ultimoCaixa = context.HistoricosCaixa.OrderByDescending(x => x.ID).FirstOrDefault();
        HistoricoCaixa caixaAtual = new(); 
        if(ultimoCaixa == null){
            caixaAtual.ID = 1;
            caixaAtual.ValorAtualCaixa = valor;
        }else
        {
            caixaAtual.ID = ultimoCaixa.ID + 1;
            caixaAtual.ValorAtualCaixa = ultimoCaixa.ValorAtualCaixa + valor;
        }

        
        caixaAtual.IdEstacionamento = idEst;
        caixaAtual.TimeStamp = DateTime.Now;

        context.Add(caixaAtual);
        context.SaveChanges();
    }

    internal void VerificarDisponibilidade()
    {
        using var context = new GaragemContext();

        //pega os veiculos no db
        var estacionamentos = context.Estacionamentos.Where(e => e.StatusEstacionamento == Status.Aberto).ToList();
        if(estacionamentos.Count >= capacidade) disponibilidade = false;
        else disponibilidade = true;
    }

    internal static Veiculo ObterVeiculo(string pc2)
    {
        using var context = new GaragemContext();
        
        //retorna o veículo do db
        Veiculo veiLocal = context.Veiculos.FirstOrDefault(v => v.Placa == pc2);
        
        if(veiLocal != null)
        {
            return veiLocal;
        }
        return new Veiculo();
    }

    internal static Cliente ObterCliente(string cpfCnpj)
    {        
       using var context = new GaragemContext();

       //retorna o cliente do db    
       Cliente cliLocal = context.Clientes.FirstOrDefault(c => c.CpfCnpj == cpfCnpj); 

        if(cliLocal != null) 
        {
            return cliLocal;
        }        
        return new Cliente();
    }

    internal static void CadastrarVeiculo(Veiculo veiculo)
    {
        using var context = new GaragemContext();
        // Adiciona a entidade ao Data Context
        context.Veiculos.Add(veiculo);

        // Persiste as mudancas
        context.SaveChanges();
    }

    internal static void CadastrarCliente(Cliente cliente)
    {
        using var context = new GaragemContext();
        context.Clientes.Add(cliente);

        // Persiste as mudancas
        context.SaveChanges();
    }
}
