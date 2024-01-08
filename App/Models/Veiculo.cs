using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static App.Models.Enums;

namespace App.Models;

[Table("Veiculos")]
public class Veiculo
{
    //Atributos
    private Guid _idVeiculo;
    protected TipoVeiculo tipoVeiculo;
    protected string placa, modelo;

    public Veiculo()
    {
        
    }

    public Veiculo(string pc, string mod, char tipo)
    {
        _idVeiculo = Guid.NewGuid();
        placa = pc;
        modelo = mod;
        tipoVeiculo = (TipoVeiculo)tipo;
    }

    //Propriedades com get e set para preencher os atributos
    public TipoVeiculo TipoVeiculo 
    { 
        get { return tipoVeiculo; } 
        set { tipoVeiculo = TipoVeiculo; } 
    }
    public string Placa 
    { 
        get { return placa; } 
        set { placa = Placa; } 
    }
    public string Modelo 
    { 
        get { return modelo; } 
        set { modelo = Modelo; } 
    }
    
    [Key]
    public Guid ID { get; set; }
}
