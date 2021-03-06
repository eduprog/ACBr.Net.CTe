// ***********************************************************************
// Assembly         : ACBr.Net.CTe
// Author           : RFTD
// Created          : 10-12-2016
//
// Last Modified By : RFTD
// Last Modified On : 06-22-2018
// ***********************************************************************
// <copyright file="CteProc.cs" company="ACBr.Net">
//		        		   The MIT License (MIT)
//	     		    Copyright (c) 2016 Grupo ACBr.Net
//
//	 Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the "Software"),
// to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense,
// and/or sell copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following conditions:
//	 The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//	 THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
// DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
// ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ComponentModel;
using ACBr.Net.Core.Extensions;
using ACBr.Net.DFe.Core.Attributes;
using ACBr.Net.DFe.Core.Document;
using ACBr.Net.DFe.Core.Serializer;

namespace ACBr.Net.CTe
{
    [DFeRoot(Namespace = "http://www.portalfiscal.inf.br/cte")]
    public sealed class CTeProc : DFeDocument<CTeProc>, INotifyPropertyChanged
    {
        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Events

        #region Constructors

        public CTeProc()
        {
            CTe = new CTe();
            ProtCTe = new CTeProtCTe();

            Versao = CTeVersao.v300;
        }

        #endregion Constructors

        #region Propriedades

        [DFeAttribute(TipoCampo.Enum, "versao", Min = 4, Max = 4, Ocorrencia = Ocorrencia.Obrigatoria)]
        public CTeVersao Versao { get; set; }

        [DFeAttribute(TipoCampo.Str, "ipTransmissor", Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public string IpTransmissor { get; set; }

        [DFeElement("CTe", Ocorrencia = Ocorrencia.Obrigatoria)]
        public CTe CTe { get; set; }

        [DFeElement("protCTe", Ocorrencia = Ocorrencia.Obrigatoria)]
        public CTeProtCTe ProtCTe { get; set; }

        [DFeIgnore]
        public bool Processado => ProtCTe?.InfProt?.CStat.IsIn(100, 110, 150, 301, 302) ?? false;

        #endregion Propriedades

        #region Methods

        private string GetRootName()
        {
            return CTe.InfCTe.Ide.Mod == ModeloCTe.CTe ? "cteProc" : "cteOSProc";
        }

        private static string[] GetRootNames()
        {
            return new[] { "cteProc", "cteOSProc" };
        }

        #endregion Methods
    }
}

#pragma warning restore