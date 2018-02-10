using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IImportsA.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public string Referencia { get; set; }
        public int QuantidadeTotal { get; set; }
        public decimal Preco { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }

        [Display(Name = " C-1")]
        public string Cor_1 { get; set; }
        [Display(Name = "Quantidade-1")]
        public int Quantidade_Cor_1 { get; set; }

        [Display(Name = " C-2")]
        public string Cor_2 { get; set; }
        [Display(Name = "Quantidade-2")]
        public int Quantidade_Cor_2 { get; set; }

        [Display(Name = " C-3")]
        public string Cor_3 { get; set; }
        [Display(Name = "Quantidade-3")]
        public int Quantidade_Cor_3 { get; set; }

        [Display(Name = " C-4")]
        public string Cor_4 { get; set; }
        [Display(Name = "Quantidade-4")]
        public int Quantidade_Cor_4 { get; set; }

        [Display(Name = " C-5")]
        public string Cor_5 { get; set; }
        [Display(Name = "Quantidade-5")]
        public int Quantidade_Cor_5 { get; set; }

        [Display(Name = " C-6")]
        public string Cor_6 { get; set; }
        [Display(Name = "Quantidade-6")]
        public int Quantidade_Cor_6 { get; set; }

        [Display(Name = " C-7")]
        public string Cor_7 { get; set; }
        [Display(Name = "Quantidade-7")]
        public int Quantidade_Cor_7 { get; set; }

        [Display(Name = " C-8")]
        public string Cor_8 { get; set; }
        [Display(Name = "Quantidade-8")]
        public int Quantidade_Cor_8 { get; set; }

        [Display(Name = " C-9")]
        public string Cor_9 { get; set; }
        [Display(Name = "Quantidade-9")]
        public int Quantidade_Cor_9 { get; set; }

        [Display(Name = " C-10")]
        public string Cor_10 { get; set; }
        [Display(Name = "Quantidade-10")]
        public int Quantidade_Cor_10 { get; set; }

        [Display(Name = " C-11")]
        public string Cor_11 { get; set; }
        [Display(Name = "Quantidade-11")]
        public int Quantidade_Cor_11 { get; set; }

        [Display(Name = " C-12")]
        public string Cor_12 { get; set; }
        [Display(Name = "Quantidade-12")]
        public int Quantidade_Cor_12 { get; set; }

        [Display(Name = " C-13")]
        public string Cor_13 { get; set; }
        [Display(Name = "Quantidade-13")]
        public int Quantidade_Cor_13 { get; set; }

        [Display(Name = " C-14")]
        public string Cor_14 { get; set; }
        [Display(Name = "Quantidade-14")]
        public int Quantidade_Cor_14 { get; set; }

        [Display(Name = " C-15")]
        public string Cor_15 { get; set; }
        [Display(Name = "Quantidade-15")]
        public int Quantidade_Cor_15 { get; set; }

        [Display(Name = " C-16")]
        public string Cor_16 { get; set; }
        [Display(Name = "Quantidade-16")]
        public int Quantidade_Cor_16 { get; set; }

        [Display(Name = " C-17")]
        public string Cor_17 { get; set; }
        [Display(Name = "Quantidade-17")]
        public int Quantidade_Cor_17 { get; set; }

        [Display(Name = "C-18")]
        public string Cor_18 { get; set; }
        [Display(Name = "Quantidade-18")]
        public int Quantidade_Cor_18 { get; set; }

        [Display(Name = " C-19")]
        public string Cor_19 { get; set; }
        [Display(Name = "Quantidade-19")]
        public int Quantidade_Cor_19 { get; set; }

        [Display(Name = " C-20")]
        public string Cor_20 { get; set; }
        [Display(Name = "Quantidade-20")]
        public int Quantidade_Cor_20 { get; set; }

        [Display(Name = "T-1")]
        public int Tamanho_1 { get; set; }

        [Display(Name = "T-2")]
        public int Tamanho_2 { get; set; }

        [Display(Name = "T-3")]
        public int Tamanho_3 { get; set; }

        [Display(Name = "T-4")]
        public int Tamanho_4 { get; set; }

        [Display(Name = "T-5")]
        public int Tamanho_5 { get; set; }

        [Display(Name = "T-6")]
        public int Tamanho_6 { get; set; }

        [Display(Name = "T-7")]
        public int Tamanho_7 { get; set; }

        [Display(Name = "T-8")]
        public int Tamanho_8 { get; set; }

        [Display(Name = "T-9")]
        public int Tamanho_9 { get; set; }

        [Display(Name = "T-10")]
        public int Tamanho_10 { get; set; }

    }
}