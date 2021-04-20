using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace WebApi.Models
{
    public class Vacinado
    {
        public int Sid { get; set; }
        public string Snome { get; set; }
        public string Scpf { get; set; }
        public string Stelefone { get; set; }
        public string Semail { get; set; }
        public int Sidade { get; set; }

        public List<Vacinado> ListaVacinados()
        {
            var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data\base.json");
            var json = File.ReadAllText(caminhoArquivo);
            var listaVacinados = JsonConvert.DeserializeObject<List<Vacinado>>(json);

            return listaVacinados;
        }
        public bool ReescreverArquivo(List<Vacinado> listaVacinados)
        {
            var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data\base.json");
            var json = JsonConvert.SerializeObject(listaVacinados, Formatting.Indented);
            File.WriteAllText(caminhoArquivo, json);
            return true;

        }
        public Vacinado Inserir(Vacinado vacinado)
        {
            var ListaVacinados = this.ListaVacinados();
            var maxId = ListaVacinados.Max(vacinados => vacinado.Sid);
            vacinado.Sid = maxId + 1;
            ListaVacinados.Add(vacinado);
            ReescreverArquivo(ListaVacinados);
            return vacinado;

        }
        public Vacinado Atualizar(int id, Vacinado vacinado)
        {
            var ListaVacinados = this.ListaVacinados();
            var itemIndex = ListaVacinados.FindIndex(p => p.Sid == id);
            if (itemIndex >= 0)
            {
                vacinado.Sid = id;
                ListaVacinados[itemIndex] = vacinado;

            }
            else
            {
                return null;
            }
            ReescreverArquivo(ListaVacinados);
            return vacinado;
        }
        public bool Deletar(int id)
        {
            var ListaVacinados = this.ListaVacinados();
            var itemIndex = ListaVacinados.FindIndex(p => p.Sid == id);
            if (itemIndex >= 0)
            {
                ListaVacinados.RemoveAt(itemIndex);

            }
            else
            {
                return false;
            }
            ReescreverArquivo(ListaVacinados);
            return true;
        }
    }
}
