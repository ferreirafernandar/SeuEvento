using System.Collections.Generic;

namespace SeuEvento.Application.ViewModels
{
  public class EstadoViewModel
  {
    public string Uf { get; set; }
    public string Nome { get; set; }

    public static List<EstadoViewModel> ListarEstados()
    {
      return new List<EstadoViewModel>
            {
                new EstadoViewModel {Uf = "AC", Nome = "Acre"},
                new EstadoViewModel {Uf = "AL", Nome = "Alagoas"},
                new EstadoViewModel {Uf = "AP", Nome = "Amapá"},
                new EstadoViewModel {Uf = "AM", Nome = "Amazonas"},
                new EstadoViewModel {Uf = "BA", Nome = "Bahia"},
                new EstadoViewModel {Uf = "CE", Nome = "Ceará"},
                new EstadoViewModel {Uf = "DF", Nome = "Distrito Federal"},
                new EstadoViewModel {Uf = "ES", Nome = "Espírito Santo"},
                new EstadoViewModel {Uf = "GO", Nome = "Goiás"},
                new EstadoViewModel {Uf = "MA", Nome = "Maranhão"},
                new EstadoViewModel {Uf = "MT", Nome = "Mato Grosso"},
                new EstadoViewModel {Uf = "MS", Nome = "Mato Grosso do Sul"},
                new EstadoViewModel {Uf = "MG", Nome = "Minas Gerais"},
                new EstadoViewModel {Uf = "PA", Nome = "Pará"},
                new EstadoViewModel {Uf = "PB", Nome = "Paraíba"},
                new EstadoViewModel {Uf = "PR", Nome = "Paraná"},
                new EstadoViewModel {Uf = "PE", Nome = "Pernambuco"},
                new EstadoViewModel {Uf = "PI", Nome = "Piauí"},
                new EstadoViewModel {Uf = "RJ", Nome = "Rio de Janeiro"},
                new EstadoViewModel {Uf = "RN", Nome = "Rio Grande do Norte"},
                new EstadoViewModel {Uf = "RS", Nome = "Rio Grande do Sul"},
                new EstadoViewModel {Uf = "RO", Nome = "Rondônia"},
                new EstadoViewModel {Uf = "RR", Nome = "Roraima"},
                new EstadoViewModel {Uf = "SC", Nome = "Santa Catarina"},
                new EstadoViewModel {Uf = "SP", Nome = "São Paulo"},
                new EstadoViewModel {Uf = "SE", Nome = "Sergipe"},
                new EstadoViewModel {Uf = "TO", Nome = "Tocantins"}
            };
    }
  }
}