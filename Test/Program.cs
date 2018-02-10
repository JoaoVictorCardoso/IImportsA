using IImportsA.Models;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
             //int id; id = 0;
             //var chrome = new ChromeDriver() ;
            //  chrome.Navigate().GoToUrl(" ");

            #region NOMEAR E BAIXAR TODAS AS IMAGENS
            var imagens = new IImportsAContext();
            var img = imagens.Items.AsEnumerable().Select(c => c.Imagem ).ToList();

            var query = from o in imagens.Items where o.Imagem != "" select o;

         //   var referencia = imagens.Items.AsEnumerable().Select(c => c.Referencia).ToList();
            
            var NOME_IMAGEM = "";
            int contagem = 0;
            string[] listeNomes = new string[1000];

            foreach (string item in img )
            {
                
                if (item != "")
                {
                    var invertido = item.Reverse();
                    var numero_invertido = "";
                    string palavra_invertida = "";
 
                    foreach (char letra in invertido)
                    {
                        palavra_invertida += letra;
                    }

                    int ponto_posicao = palavra_invertida.IndexOf(".");
                    
                    if (ponto_posicao > 0)
                    {
                        palavra_invertida = palavra_invertida.Remove(0, ponto_posicao + 1);//remove inicio, 4 letras

                        var numeral = palavra_invertida.Remove(0, palavra_invertida.IndexOf("-") + 1);
 

                        while (numeral.Contains("-"))
                        {
                            var index = numeral.IndexOf("-");
                            numeral = numeral.Remove(0, index+1);
                        }
                        

                        numero_invertido = numeral.Remove(numeral.IndexOf("/"));
                     
                        int fim_texto = palavra_invertida.IndexOf("h");
                        int fim_palavra = palavra_invertida.IndexOf( "/");
                        palavra_invertida = palavra_invertida.Remove(fim_palavra);
                    }
                    var NUMERO = numero_invertido.Reverse();

                    var TEXTO = palavra_invertida.Reverse();
                    string nome = "";
                    foreach (var le in TEXTO)
                    {
                        nome += le;
                    }
                    foreach (var it in NUMERO)
                    {
                        nome += it;
                    }
                    
                    NOME_IMAGEM = nome + ".jpg";
                    listeNomes[contagem++] = NOME_IMAGEM;
                   

                    //WebClient cliente = new WebClient();

                    //cliente.DownloadFile(item, imagem);
                }
            }

            contagem = 0;
            foreach(Item elemento in query)
            {
                elemento.Imagem = listeNomes[contagem++];
                Console.WriteLine("\n" + listeNomes[contagem]);
                Thread.Sleep(1000);
            }

            try
            {
                imagens.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            #endregion

            #region Loops para o site
   /*
                 //   var contexto = new IImportsAContext();

                    for (int i = 1; i <= 53; i++)   //ENTRA EM UMA PÁGINA POR VEZ
                    {
                        chrome.Navigate().GoToUrl($"http://www.antaressemijoias.com.br/2-inicio?page={i}");

                        #region LISTA TODOS OS 12 ITENS por PAGE
                        var blocoItem = chrome.FindElementsByClassName("product-thumbnail");
                        string[] lista = new string[13];
                        int co = 0;
                        foreach (var elemento in blocoItem)
                        {
                            var link = elemento.GetAttribute("href").ToString();
                            lista[co] = link;
                            //   Console.WriteLine("LISTA: " + lista[co]);
                            co++;
                        }
                        #endregion


                        foreach (string rotina in lista)
                        {
                            if (String.IsNullOrEmpty(rotina)) break;
                            chrome.Navigate().GoToUrl(rotina);
                            Thread.Sleep(100);

                            //========================================================================================================
                            //pegar a referencia de todo elemento em uma página

                            #region IMAGEM, PREÇO, REFERENCIA, DESCRIÇÃO

                            string foto = "";
                            try
                            {
                                foto = chrome.FindElementByClassName("js-qv-product-cover").GetAttribute("src");
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("erro nao tem foto");
                                foto = "sem foto";
                            }

                            decimal valor = 0;
                            try
                            {
                                var cp = chrome.FindElementByClassName("current-price").Text;
                                cp = cp.Remove(0, 2);
                                valor = decimal.Parse(cp);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("sem preço");
                                valor = 0;
                            }

                            string referencia = "";
                            try
                            {
                                referencia = chrome.FindElementByClassName("product-reference").Text;
                                referencia = referencia.Remove(0, 11);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("sem referencia");
                                referencia = "vazio";
                            }


                            string descricao = "";
                            try
                            {
                                descricao = chrome.FindElementById("product-description-short-18").Text;
                            }
                            catch (Exception e)
                            {
                                descricao = "sem descrição";
                            }

                            #endregion

                            #region LISTA CORES, LISTA QUANTIDADES ESTOQUE

                            string[] listeQuantidade = new string[30];
                            string[] listeCores = new string[30];
                            int[] listeTamanho = new int[10];

                            string cor_elemento = "";
                            try
                            {
                                var bloco = chrome.FindElementsByClassName("color");
                                int count = 0;
                                foreach (var item in bloco)
                                {
                                    cor_elemento = item.GetCssValue("background-color").ToString();
                                    listeCores[count++] = cor_elemento;
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("erro nao tem cores");
                                cor_elemento = "";
                            }

                            string quantidade = "";
                            try
                            {
                                var bloco = chrome.FindElementsByClassName("quantidade-em-estoque");
                                int count = 0;
                                foreach (var item in bloco)
                                {
                                    quantidade = item.Text;
                                    listeQuantidade[count++] = quantidade;
                                }
                            }
                            catch (Exception e)
                            {

                                quantidade = chrome.FindElementByClassName("tag-qnt-em-estoque").Text;
                                listeQuantidade[0] = quantidade;
                            }

                            int tamanho = 0;
                            try
                            {
                                var listaTamanhos = chrome.FindElementsById("group_10");
                                int count = 0;
                                foreach (var item in listaTamanhos)
                                {
                                    if (item != null)
                                    {
                                        tamanho = int.Parse(item.Text);
                                        listeTamanho[count++] = tamanho;
                                    }
                                    else { listeTamanho[count++] = 0; }



                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("sem tamanho");
                            }


                            int total_quantidade = 0;
                            int conte = 0;
                            foreach (var item in listeQuantidade)
                            {
                                if (item != null) { total_quantidade += int.Parse(item); }
                                else { listeQuantidade[conte] = "0"; }
                                conte++;
                            }
                            Console.WriteLine($"a quantidade total é: {total_quantidade}");

                            int contAGE = 0;
                            int cont = 0;
                            foreach (var item in listeCores)
                            {
                                if (item != null)
                                {
                                    Console.WriteLine($"cor : {item} \nQuantidade dessa cor: {listeQuantidade[cont++]}");
                                }
                                else { listeCores[contAGE] = "out"; }
                                contAGE++;
                            }


                            Console.WriteLine($"\n Imagem : {foto} \n Preço : {valor} \n Descricao: {descricao} \n Referencia : {referencia} \n");

                            #endregion

                            var objeto = new Item()
                            {
                                Id = id++,
                                Imagem = foto,
                                Descricao = descricao,
                                Preco = valor,
                                QuantidadeTotal = total_quantidade,
                                Referencia = referencia,
                                Quantidade_Cor_1 = int.Parse(listeQuantidade[0]),
                                Quantidade_Cor_2 = int.Parse(listeQuantidade[1]),
                                Quantidade_Cor_3 = int.Parse(listeQuantidade[2]),
                                Quantidade_Cor_4 = int.Parse(listeQuantidade[3]),
                                Quantidade_Cor_5 = int.Parse(listeQuantidade[4]),
                                Quantidade_Cor_6 = int.Parse(listeQuantidade[5]),
                                Quantidade_Cor_7 = int.Parse(listeQuantidade[6]),
                                Quantidade_Cor_8 = int.Parse(listeQuantidade[7]),
                                Quantidade_Cor_9 = int.Parse(listeQuantidade[8]),
                                Quantidade_Cor_10 = int.Parse(listeQuantidade[9]),
                                Quantidade_Cor_11 = int.Parse(listeQuantidade[10]),
                                Quantidade_Cor_12 = int.Parse(listeQuantidade[11]),
                                Quantidade_Cor_13 = int.Parse(listeQuantidade[12]),
                                Quantidade_Cor_14 = int.Parse(listeQuantidade[13]),
                                Quantidade_Cor_15 = int.Parse(listeQuantidade[14]),
                                Quantidade_Cor_16 = int.Parse(listeQuantidade[15]),
                                Quantidade_Cor_17 = int.Parse(listeQuantidade[16]),
                                Quantidade_Cor_18 = int.Parse(listeQuantidade[17]),
                                Quantidade_Cor_19 = int.Parse(listeQuantidade[18]),
                                Quantidade_Cor_20 = int.Parse(listeQuantidade[19]),

                                Tamanho_1 = listeTamanho[0],
                                Tamanho_2 = listeTamanho[1],
                                Tamanho_3 = listeTamanho[2],
                                Tamanho_4 = listeTamanho[3],
                                Tamanho_5 = listeTamanho[4],
                                Tamanho_6 = listeTamanho[5],
                                Tamanho_7 = listeTamanho[6],
                                Tamanho_8 = listeTamanho[7],
                                Tamanho_9 = listeTamanho[8],
                                Tamanho_10 = listeTamanho[9],



                                Cor_1 = listeCores[0],
                                Cor_2 = listeCores[1],
                                Cor_3 = listeCores[2],
                                Cor_4 = listeCores[3],
                                Cor_5 = listeCores[4],
                                Cor_6 = listeCores[5],
                                Cor_7 = listeCores[6],
                                Cor_8 = listeCores[7],
                                Cor_9 = listeCores[8],
                                Cor_10 = listeCores[9],
                                Cor_11 = listeCores[10],
                                Cor_12 = listeCores[11],
                                Cor_13 = listeCores[12],
                                Cor_14 = listeCores[13],
                                Cor_15 = listeCores[14],
                                Cor_16 = listeCores[15],
                                Cor_17 = listeCores[16],
                                Cor_18 = listeCores[17],
                                Cor_19 = listeCores[18],
                                Cor_20 = listeCores[19]
                            };

                            //contexto.Items.Add(objeto);

                            //========================================================================================================
                            Thread.Sleep(100);
                            chrome.Navigate().GoToUrl($"http://www.antaressemijoias.com.br/2-inicio?page={i}");
                        }
                       // contexto.SaveChanges();
                    }
*/
            #endregion


        }


    }
}
