﻿// ***********************************************************************
// Assembly         : ACBr.Net.CTe
// Author           : RFTD
// Created          : 11-10-2016
//
// Last Modified By : RFTD
// Last Modified On : 10-22-2017
// ***********************************************************************
// <copyright file="CTeConsultaServiceClient.cs" company="ACBr.Net">
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

using System;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using ACBr.Net.Core.Exceptions;
using ACBr.Net.Core.Extensions;

namespace ACBr.Net.CTe.Services
{
    public sealed class CTeConsultaServiceClient : CTeServiceClient<ICTeConsulta>, ICTeConsulta
    {
        #region Constructors

        public CTeConsultaServiceClient(CTeConfig config, X509Certificate2 certificado = null) :
            base(config, ServicoCTe.CTeConsultaProtocolo, certificado)
        {
        }

        #endregion Constructors

        #region Methods

        public ConsultaCTeResposta Consulta(CTeWsCabecalho cabecalho, string mensagem, string fileName)
        {
            Guard.Against<ArgumentNullException>(cabecalho == null, nameof(cabecalho));
            Guard.Against<ArgumentNullException>(mensagem.IsEmpty(), nameof(mensagem));
            Guard.Against<ArgumentNullException>(fileName.IsEmpty(), nameof(fileName));

            lock (serviceLock)
            {
                xmlFileName = fileName;

                var xml = new XmlDocument();
                xml.LoadXml(mensagem);

                var inValue = new ConsultaCTeRequest(cabecalho, xml);
                var retVal = ((ICTeConsulta)this).ConsultaCTe(inValue);

                var retorno = new ConsultaCTeResposta(xmlEnvio, xmlRetorno)
                {
                    Resultado = ConsultaCTeResult.Load(retVal.Result.OuterXml)
                };

                xmlEnvio = string.Empty;
                xmlRetorno = string.Empty;
                xmlFileName = string.Empty;

                return retorno;
            }
        }

        ConsultaResponse ICTeConsulta.ConsultaCTe(ConsultaCTeRequest request)
        {
            return Channel.ConsultaCTe(request);
        }

        #endregion Methods
    }
}