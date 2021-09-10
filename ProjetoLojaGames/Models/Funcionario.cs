using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ProjetoLojaGames.Models
{
    public class Funcionario
    {
        [Display(Name = "Código do Funcionário")]
        [Remote("Cod_Func_Uni", "funcionario", ErrorMessage = "Funcionário já cadastrado")]
        [Required(ErrorMessage = "Código de funcionário obrigatório")]
        public int Cod_Func { get; set; }

        [Display(Name = "Nome do Funcionário")]
        [Required(ErrorMessage = "Nome do funcionário é obrigatório")]
        public string Nome_Func { get; set; }

        [Display(Name = "CPF do funcionário")]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "Insira um CPF válido: xxx.xxx.xxx-xx")]
        [Required(ErrorMessage = "CPF obrigatório")]
        public string Cpf_Func { get; set; }

        [Display(Name = "RG do funcionário")]
        [Required(ErrorMessage = "Rg obrigatório")]
        [RegularExpression(@"^\d{2}\.\d{3}\.\d{3}-\d{1}$", ErrorMessage = "Insira um Rg válido: xx.xxx.xxx-x")]
        public string Rg_Func { get; set; }

        [Display(Name = "Data de nascimento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Data de Nascimento Obrigatória")]
        public DateTime DtNasc_Func
        {
            get
            {
                return this.dtNasc_Func.HasValue
                    ? this.dtNasc_Func.Value
                    : DateTime.Now;
            }

            set
            {
                this.dtNasc_Func = value;
            }
        }
        private DateTime? dtNasc_Func = null;

        [Display(Name = "Endereço")]
        [Required(ErrorMessage = "Endereço do funcionário obrigatório")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Mínimo de 5 caracteres e máximo de 100")]
        public string Ende_Func { get; set; }

        [Display(Name = "Celular do funcionário")]
        [Required(ErrorMessage = "Celular do funcionário obrigatório")]
        public string Cell_Func { get; set; }

        [Display(Name = "E-mail do funcionário")]
        [Required(ErrorMessage = "Email do funcionário obrigatório")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Insira um E-mail Válido")]
        public string Email_Func { get; set; }

        [Display(Name = "Cargo")]
        [Required(ErrorMessage = "Cargo do funcionário obrigatório")]
        public string Cargo { get; set; }
    }
}