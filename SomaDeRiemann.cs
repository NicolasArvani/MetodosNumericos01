using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosNumericos01
{
    internal class SomaDeRiemann
    {
        private Funcao funcao;
        private double inicio;
        private double fim;


        public SomaDeRiemann(String funcao, double inicio, double fim)
        {
            this.funcao = new Funcao(funcao);
            this.inicio = inicio;
            this.fim = fim;
        }
        
        public SomaDeRiemann(String funcao)
        {
            this.funcao = new Funcao(funcao);
        }
        
        public void setFuncao(String Funcao) { this.funcao = new Funcao(Funcao); }
        public void setInicio(double inicio) { this.inicio = inicio; }
        public void setFim(double fim) { this.fim = fim; }

        public void getFuncao() { this.funcao.printFuncao(); }


        public double calcArea(int divisoes)
        {
            double area = 0;
            double Base = (this.fim - this.inicio) / divisoes;
            double mid = Base / 2;
                        
            for(int i = 0; i < divisoes; i++)
            {
                area += Base * funcao.calculaY(this.inicio + Base * i + mid);
            }  

            return area;
        }

    }
}
