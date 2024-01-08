using App.Controllers;
using App.Models;

GaragemController minhaGaragem = new();
Veiculo veiculo = new();
Cliente cliente = new();
Boolean sair = false;

while (!sair)
{
    try
    {
        //Console.Clear();
        Console.WriteLine("-=-=-=-=Estacionamento SeuCarro+Seguro=-=-=-=-\n" +
        "1 - Verificar disponibilidade\n" +
        "2 - Estacionar veículo\n" +
        "3 - Reaver veículo\n" +
        "4 - Ver veículos estacionados\n" +
        "5 - Sair da aplicação\n" +
        "Opção: ");
        string? opcao = Console.ReadLine();
        switch (opcao)
        {
            case "1":
                minhaGaragem.VerificarDisponibilidade();
                if(minhaGaragem.disponibilidade == true) Console.WriteLine("Há vagas disponíveis.");
                else Console.WriteLine("Não há vagas disponíveis.");
                Console.ReadLine();
                break;
            case "2":
                string? op;
                //obtendo cliente
                Console.WriteLine("Cliente já cadastrado? s/n: ");
                string? clienteCadastrado = Console.ReadLine();
                if(clienteCadastrado.Trim().ToUpper().Equals("S")){
                    BuscarCliente();
                    if(cliente.NomeCliente == null){
                        Console.WriteLine("Esse cliente não está cadastrado. Deseja fazer um cadastro? s/n: ");
                        op = Console.ReadLine();
                        if(op.Trim().ToUpper().Equals("S")) CadastrarCliente();
                        else break;
                    }
                }else if(clienteCadastrado.Trim().ToUpper().Equals("N"))
                    CadastrarCliente();
                else
                {
                    Console.WriteLine("Resposta inválida, tente de novo.");
                    Console.ReadLine();
                    break;
                }

                //obtendo o veículo
                Console.WriteLine("Veículo já cadastrado? s/n: ");
                string? veiculoCadastrado = Console.ReadLine();
                if(veiculoCadastrado.Trim().ToUpper().Equals("S")){
                    BuscarVeiculo();
                    if(veiculo.Placa == null)
                    {
                        Console.WriteLine("Esse veículo não está cadastrado. Deseja fazer um cadastro? s/n: ");
                        op = Console.ReadLine();
                        if(op.Trim().ToUpper().Equals("S")) CadastrarVeiculo();
                        else break;
                    }
                }else if(veiculoCadastrado.Trim().ToUpper().Equals("N"))
                    CadastrarVeiculo();
                else
                {
                    Console.WriteLine("Resposta inválida, tente de novo.");
                    Console.ReadLine();
                    break;
                }                
                
                minhaGaragem.AdicionarVeiculo(veiculo, cliente);
                break;

            case "3":
                BuscarVeiculo();
                minhaGaragem.RemoverVeiculo(veiculo);
                Console.ReadLine();
                break;

            case "4":
                minhaGaragem.ExibirListaVeiculos();
                Console.ReadLine();
                break;

            case "5":
                Console.WriteLine("Saindo da aplicação...");
                Console.ReadLine();
                sair = true;
                break;

            default:
                Console.WriteLine("opção inválida, tente de novo.");
                Console.ReadLine();
                break;
        }
    }
    catch (IOException ioE)
    {
        System.Console.WriteLine(ioE.Message);
    }
    catch (OutOfMemoryException omE)
    {
        System.Console.WriteLine(omE.Message);
    }
    catch (ArgumentOutOfRangeException aorE)
    {
        System.Console.WriteLine(aorE.Message);
    }
    catch (Exception e)
    {
        System.Console.WriteLine(e.Message);
    }
}

void CadastrarVeiculo()
{
    Console.WriteLine("modelo: ");
    string? mod = Console.ReadLine();
    Console.WriteLine("placa: ");
    string? pc = Console.ReadLine();
    Console.WriteLine("tipo de veiculo, carro ou moto (digite C ou M): ");
    string? tipo = Console.ReadLine();
    veiculo = new(pc, mod, Convert.ToChar(tipo));
    GaragemController.CadastrarVeiculo(veiculo);
}

void BuscarVeiculo()
{
    veiculo = new();
    Console.WriteLine("placa: ");
    string? pc2 = Console.ReadLine();
    if(pc2 != null) veiculo = GaragemController.ObterVeiculo(pc2);
}

void BuscarCliente()
{
    cliente = new();
    Console.WriteLine("cpf ou cnpj: ");
    string? cpfCnpj = Console.ReadLine();
    if(cpfCnpj != null) cliente = GaragemController.ObterCliente(cpfCnpj);
}

void CadastrarCliente()
{    
    Console.WriteLine("Seu nome: ");
    string? nome = Console.ReadLine();
    Console.WriteLine("cpf ou cnpj: ");
    string? cpfCnpj = Console.ReadLine();
    Console.WriteLine("telefone: ");
    string? tel = Console.ReadLine();
    cliente = new Cliente(nome, cpfCnpj, tel);
    GaragemController.CadastrarCliente(cliente);
}