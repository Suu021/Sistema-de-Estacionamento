<h1 align="center">Sistema de Estacionamento</h1>

[![The MIT License](https://img.shields.io/badge/license-MIT-green.svg?style=flat-square)](http://opensource.org/licenses/MIT)
![Language](https://img.shields.io/badge/.NET_8.0-512BD4?style=flat-square&logo=dotnet&logoColor=white)
![Framework](https://img.shields.io/badge/EF--Core?style=flat-square&label=EF-Core%208.0&labelColor=%233d18b8&color=%233d18b8)
![Database](https://img.shields.io/badge/Sqlite-003B57?style=flat-square&logo=sqlite&logoColor=white)
![Badge em Desenvolvimento](http://img.shields.io/static/v1?label=STATUS&message=EM%20DESENVOLVIMENTO&color=GREEN&style=flat-square)

## Descrição
Um sistema para cadastro de clientes e veículos e registro de estacionamento a partir da data e hora de entrada e de saída, calculando o tempo de permanência e o valor total do estacionamento do veículo na vaga. O valor total fica registrado no histórico de caixa do sistema.

## Detalhes técnicos
O sistema foi desenvolvido em .Net v8.0, com EntittyFramework Core v8.0 para comunicação com o banco de dados, no padrão MVC com orientação a objetos, porém a view é apenas console no momento.

A interface do app cadastra cliente e veículo, ou os busca no banco de dados, e registra o estacionamento com data e hora de entrada e um status "aberto". Quando o cliente quer levar embora o veiculo e encerrar o estacionamento é registrada a data e hora de saída, é calculado o valor do estacionamento, é mudado o status de "aberto" para "finalizado" e é registrado o valor no histórico do caixa.

Todos esses dados são persistidos no banco de dados com SQLite 3. O banco de dados do app contém as tabelas: 

- <b>Clientes</b> - Onde são cadastrados os clientes do estacionamento com os campos id, nome, cpfCnpj, telefone.
- <b>Veiculos</b> - Onde são cadastrados os veículos que usam ou já usaram o estacionamento com os campos id, modelo, placa, tipoVeiculo.
- <b>Estacionamentos</b> - Onde são registrados os estacionamentos dos veículos com os campos id, idCliente, idVeiculo, horaInicio, horaFim, valorTotal, statusEstacionamento.
- <b>HistoricosCaixa</b> - Onde são registrados os estacionamentos com status "finalizado" com o valor total (ou seja, que já foram levados pelo cliente), cujo valor recebido já foi contabilizado no caixa, com os campos id, idEstacionamento, valorAtualCaixa, valorEstacionamento.

O App também permite ver a disponibilidade de vagas para estacionamentos e também vizualizar veículos estacionados.