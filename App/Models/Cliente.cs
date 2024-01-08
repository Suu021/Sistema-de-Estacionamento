using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models;

[Table("Clientes")]
public class Cliente
{
    //Atributos
    private string nomeCliente, cpfCnpj, telefone;
    private Guid _idCliente;

    public Cliente()
    {
        
    }

    public Cliente(string nome, string doc, string tel)
    {
        _idCliente = Guid.NewGuid();
        nomeCliente = nome;
        cpfCnpj = doc;
        telefone = tel;
    }

    //Propriedades
    public string NomeCliente 
    { 
        get { return nomeCliente; } 
        set { nomeCliente = NomeCliente; } 
    }
    public string CpfCnpj 
    { 
        get { return cpfCnpj; } 
        set { cpfCnpj = CpfCnpj; }    
    }
    public string Telefone 
    { 
        get { return telefone; } 
        set { telefone = Telefone; } 
    }
    
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid ID { get; set; }
}
