﻿// ***********************************************************************
// Assembly         : ACBr.Net.CTe
// Author           : RFTD
// Created          : 30-07-2018
//
// Last Modified By : RFTD
// Last Modified On : 13-01-2019
// ***********************************************************************
// <copyright file="DistribuicaoDFeServiceClient.cs" company="ACBr.Net">
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

using System.Security.Cryptography.X509Certificates;
using ACBr.Net.CTe.Configuracao;
using ACBr.Net.DFe.Core.Common;
using ACBr.Net.DFe.Core.Extensions;
using ACBr.Net.DFe.Core.Service;

namespace ACBr.Net.CTe.Services
{
    public sealed class DistribuicaoDFeServiceClient : DFeDistribuicaoServiceClient<CTeConfig, ACBrCTe,
        CTeConfigGeral, CTeVersao, CTeConfigWebServices, CTeConfigCertificados, CTeConfigArquivos, SchemaCTe>
    {
        public DistribuicaoDFeServiceClient(CTeConfig config, DFeCodUF uf, X509Certificate2 certificado = null) :
            base(config, CTeServiceManager.GetServiceAndress(config.Geral.VersaoDFe, uf.ToSiglaUF(), TipoServicoCTe.CTeConsultaCadastro, config.Geral.FormaEmissao, config.WebServices.Ambiente),
                "http://www.portalfiscal.inf.br/cte/wsdl/CTeDistribuicaoDFe/cteDistDFeInteresse",
                "http://www.portalfiscal.inf.br/cte/wsdl/CTeDistribuicaoDFe", config.WebServices.UF, certificado, "cteDistDFeInteresse")
        {
            Schema = SchemaCTe.DistDFeInt;
        }
    }
}