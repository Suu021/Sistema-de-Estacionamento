using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static App.Models.Enums;

namespace App.Models;

[Table("Estacionamentos")]
public class Estacionamento
{
    //Atributos
    private Guid _idEstacionamento;
    private Guid idCliente;
    private Guid idVeiculo;
    private DateTime horaInicio;
    private DateTime horaFim;
    private Status statusEstacionamento;
    private double valorCobrado;

    //Propriedades
    public DateTime HoraInicio 
    { 
        get { return horaInicio; } 
        set { horaInicio = DateTime.Now; } 
    }
    public DateTime HoraFim 
    { 
        get { return horaFim; } 
        set { horaFim = DateTime.Now; } 
    }
    public double ValorCobrado { get; set; }

    public Status StatusEstacionamento { get; set; }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid ID { get; set; }

    public Guid IdCliente { get; set; }
    public Guid IdVeiculo { get; set; }
}
