using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace EstudoXML
{
    public partial class frmAgenda : Form
    {
        public frmAgenda()
        {
            InitializeComponent();
        }

        private void FrmAgenda_Load(object sender, EventArgs e)
        {
            CriarContato();
            lblTitulo.Text = CarregarTitulo();
            CarregarContatos();
        }

        private string CarregarTitulo()
        {
            XmlDocument documentoXML = new XmlDocument(); //cria o objeto XML
            documentoXML.Load(@"C:\Users\ariel\Documents\TreinaWeb\C_Sharp_Intermediario\TreinaWeb.CSharpIntermediario\EstudoXML\Agenda.xml"); //carrega o arquivo XML na memoria
            XmlNode noTitulo = documentoXML.SelectSingleNode("/agenda/titulo"); //objeto XML que pega o nó titulo (/agenda/titulo -> expressão xPath)
            return noTitulo.InnerText; //retorna o conteudo do nó
        }

        private void CarregarContatos()
        {
            XmlDocument documentoXML = new XmlDocument(); //cria o objeto XML
            documentoXML.Load(@"C:\Users\ariel\Documents\TreinaWeb\C_Sharp_Intermediario\TreinaWeb.CSharpIntermediario\EstudoXML\Agenda.xml"); //carrega o arquivo XML na memoria
            XmlNodeList contatos = documentoXML.SelectNodes("/agenda/contatos/contato"); //objeto XML que pega o nó contato
            //Para cada contato em contatos, salva cada valor do atributo em uma string
            foreach (XmlNode contato in contatos) 
            {
                string representacaoContato = "";
                string id = contato.Attributes["id"].Value;
                string nome = contato.Attributes["nome"].Value;
                string idade = contato.Attributes["idade"].Value;

                representacaoContato = nome + ", " + idade + ", " + id; //depois concetena os valores salvos
                lbxContatos.Items.Add(representacaoContato); //adiciona na ListBox
            }
        }

        private void CriarContato()
        {
            XmlDocument documentoXML = new XmlDocument(); //cria o objeto XML
            documentoXML.Load(@"C:\Users\ariel\Documents\TreinaWeb\C_Sharp_Intermediario\TreinaWeb.CSharpIntermediario\EstudoXML\Agenda.xml"); //carrega o arquivo XML na memoria
            //Para adicionar mais um contato, primeiro criamos um objeto XmlAttribute para cada atributo e setamos um valor para o mesmo
            XmlAttribute atributoId = documentoXML.CreateAttribute("id");
            atributoId.Value = "5";
            XmlAttribute atributoNome = documentoXML.CreateAttribute("nome");
            atributoNome.Value = "Teste Novo Elemento";
            XmlAttribute atributoIdade = documentoXML.CreateAttribute("idade");
            atributoIdade.Value = "50";
            //Depois criamos o nó contato e adicionamos os atributos criados nele
            XmlNode novoContato = documentoXML.CreateElement("contato");
            novoContato.Attributes.Append(atributoId);
            novoContato.Attributes.Append(atributoNome);
            novoContato.Attributes.Append(atributoIdade);
            //Dai selecionamos o nó pai (contatos) e adicionamos o nó filho (novoContato)
            XmlNode contatos = documentoXML.SelectSingleNode("/agenda/contatos");
            contatos.AppendChild(novoContato);
            //Por fim salvamos o arquivo no caminho desejado
            documentoXML.Save(@"C:\Users\ariel\Documents\TreinaWeb\C_Sharp_Intermediario\TreinaWeb.CSharpIntermediario\EstudoXML\Agenda.xml");
        }
    }
}
