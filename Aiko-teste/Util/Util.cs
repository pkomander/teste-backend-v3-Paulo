
using System.Xml.Linq;
using Aiko.Dto.Enum;

namespace Aiko_teste.Util
{
    public class Util : IUtil
    {
        private readonly IWebHostEnvironment _env;

        public Util(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<string> CriarArquivo(string conteudo, string nomeArquivo, int formatoArquivo)
        {
            try
            {
                string extensao = "";
                // Definir a pasta correta com base na extensão

                if (formatoArquivo == (int)FormatoArquivo.XML)
                {
                    extensao = "xml";
                }
                else if (formatoArquivo == (int)FormatoArquivo.TXT)
                {
                    extensao = "txt";
                }

                nomeArquivo = await CriaNomeArquivo(nomeArquivo);

                string pastaDestino = extensao;
                string diretorio = Path.Combine(_env.ContentRootPath, "Arquivos", pastaDestino);

                // Criar diretório se não existir
                if (!Directory.Exists(diretorio))
                {
                    Directory.CreateDirectory(diretorio);
                }

                // Caminho completo do arquivo
                string caminhoArquivo = Path.Combine(diretorio, $"{nomeArquivo}.{extensao}");

                if (extensao.ToLower() == "txt")
                {
                    await File.WriteAllTextAsync(caminhoArquivo, conteudo);
                }
                else if (extensao.ToLower() == "xml")
                {
                    await CriarArquivoXml(conteudo, caminhoArquivo);
                }

                // Escrever o conteúdo no arquivo

                return $"Arquivo salvo com sucesso em: {caminhoArquivo}";
            }
            catch (Exception ex)
            {
                return $"Erro ao criar arquivo: {ex.Message}";
            }
        }

        public async Task CriarArquivoXml(string conteudo, string caminhoArquivo)
        {
            try
            {
                var linhas = conteudo.Split('\n'); // Quebra o conteúdo em linhas

                var cliente = linhas[0].Trim(); // "Statement for BigCo"
                var total = linhas[4].Trim(); // "Amount owed is R$ 1.029,30"
                var creditosTotais = linhas[5].Trim(); // "You earned 47 credits"

                var performances = new XElement("Performances");

                // Iterar sobre as linhas das performances
                for (int i = 1; i < linhas.Length - 2; i++)
                {
                    var partes = linhas[i].Trim().Split(':');
                    if (partes.Length == 2)
                    {
                        var nome = partes[0].Trim();
                        var valorEAssentos = partes[1].Trim().Split('(');

                        var valor = valorEAssentos[0].Trim(); // Ex: "R$ 402,50"
                        var assentos = valorEAssentos.Length > 1 ? valorEAssentos[1].Replace(" seats)", "").Trim() : "";

                        var performance = new XElement("Performance",
                            new XElement("Nome", nome),
                            new XElement("Valor", valor),
                            new XElement("Creditos", assentos)
                        );

                        performances.Add(performance);
                    }
                }

                var xml = new XDocument(
                    new XDeclaration("1.0", "utf-8", "yes"),
                    new XElement("Extrato",
                        new XElement("Cliente", cliente),
                        performances,
                        new XElement("Total", total),
                        new XElement("CreditosTotais", creditosTotais)
                    )
                );

                await File.WriteAllTextAsync(caminhoArquivo, xml.ToString(SaveOptions.None));
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao criar o arquivo XML: " + ex.Message);
            }
        }

        public async Task<string> CriaNomeArquivo(string arquivoNome)
        {
            try
            {
                var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                var newArquivoNome = $"{arquivoNome}_{timestamp}";
                return newArquivoNome;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao criar o arquivo XML: " + ex.Message);
            }
        }
    }
}
