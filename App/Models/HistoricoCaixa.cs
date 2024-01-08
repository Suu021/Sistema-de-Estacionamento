using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models;

[Table("HistoricoCaixa")]
public class HistoricoCaixa
{
    //Atributos
    private int _idHistorico;
    private Guid idEstacionamento;
    private double valorAtualCaixa;

    private DateTime timeStamp;
    
    //Propriedades
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }
    public double ValorAtualCaixa { get; set; }
    public Guid IdEstacionamento { get; set; }
    public DateTime TimeStamp { get; set; }

}